﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CustomCollections {

	/// <summary>
	/// Cut and pasted from:
	/// http://www.codeproject.com/Articles/31418/Implementing-a-Sortable-BindingList-Very-Very-Quic
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SortableBindingList<T> : BindingList<T> {

		// reference to the list provided at the time of instantiation
		private List<T> _originalList;
		private ListSortDirection _sortDirection;
		private PropertyDescriptor _sortProperty;

		// function that refereshes the contents
		// of the base classes collection of elements
		Action<SortableBindingList<T>, List<T>> populateBaseList = ( a, b ) => a.ResetItems( b );

		// a cache of functions that perform the sorting
		// for a given type, property, and sort direction
		static Dictionary<string, Func<List<T>, IEnumerable<T>>>
		   cachedOrderByExpressions = new Dictionary<string, Func<List<T>,
													 IEnumerable<T>>>();

		public SortableBindingList() {
			_originalList = new List<T>();
		}

		public SortableBindingList( IEnumerable<T> enumerable ) {
			_originalList = enumerable.ToList();
			populateBaseList( this, _originalList );
		}

		public SortableBindingList( List<T> list ) {
			_originalList = list;
			populateBaseList( this, _originalList );
		}

		protected override void ApplySortCore( PropertyDescriptor prop,
								ListSortDirection direction ) {
			/*
			 Look for an appropriate sort method in the cache if not found .
			 Call CreateOrderByMethod to create one. 
			 Apply it to the original list.
			 Notify any bound controls that the sort has been applied.
			 */

			_sortProperty = prop;

			var orderByMethodName = _sortDirection ==
				ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
			var cacheKey = typeof( T ).GUID + prop.Name + orderByMethodName;

			if( !cachedOrderByExpressions.ContainsKey( cacheKey ) ) {
				CreateOrderByMethod( prop, orderByMethodName, cacheKey );
			}

			ResetItems( cachedOrderByExpressions[ cacheKey ]( _originalList ).ToList() );
			ResetBindings();
			_sortDirection = _sortDirection == ListSortDirection.Ascending ?
							ListSortDirection.Descending : ListSortDirection.Ascending;
		}


		private void CreateOrderByMethod( PropertyDescriptor prop,
					 string orderByMethodName, string cacheKey ) {

			/*
			 Create a generic method implementation for IEnumerable<T>.
			 Cache it.
			*/

			var sourceParameter = Expression.Parameter( typeof( List<T> ), "source" );
			var lambdaParameter = Expression.Parameter( typeof( T ), "lambdaParameter" );
			var accessedMember = typeof( T ).GetProperty( prop.Name );
			var propertySelectorLambda =
				Expression.Lambda( Expression.MakeMemberAccess( lambdaParameter,
								  accessedMember ), lambdaParameter );
			var orderByMethod = typeof( Enumerable ).GetMethods()
										  .Where( a => a.Name == orderByMethodName &&
													   a.GetParameters().Length == 2 )
										  .Single()
										  .MakeGenericMethod( typeof( T ), prop.PropertyType );

			var orderByExpression = Expression.Lambda<Func<List<T>, IEnumerable<T>>>(
										Expression.Call( orderByMethod,
												new Expression[] { sourceParameter, 
                                                               propertySelectorLambda } ),
												sourceParameter );

			cachedOrderByExpressions.Add( cacheKey, orderByExpression.Compile() );
		}

		protected override void RemoveSortCore() {
			ResetItems( _originalList );
		}

		private void ResetItems( List<T> items ) {

			base.RaiseListChangedEvents = false;
			base.ClearItems();

			for( int i = 0; i <= items.Count - 1; i++ ) {
				base.InsertItem( i, items[ i ] );
			}

			base.RaiseListChangedEvents = true;
			base.ResetBindings();
		}

		protected override bool SupportsSortingCore {
			get {
				// indeed we do
				return true;
			}
		}

		protected override ListSortDirection SortDirectionCore {
			get {
				return _sortDirection;
			}
		}

		protected override PropertyDescriptor SortPropertyCore {
			get {
				return _sortProperty;
			}
		}

		protected override void OnListChanged( ListChangedEventArgs e ) {
			_originalList = base.Items.ToList();
		}
	}
}
