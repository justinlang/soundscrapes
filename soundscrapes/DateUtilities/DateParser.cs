using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateUtilities {

	/// <summary>
	/// IMPORTANT NOTE:
	/// 
	/// All dates from www.soundscapesmusic.com/tickets are assumed to be in the form:
	/// 
	/// dayOfWeek month day
	/// 
	/// Where:
	/// 
	/// 1. dayOfWeek is a three letter abbreviation for the day of the week, followed by a period;
	/// 2. month is a three letter abbreviation for the month;
	/// 3. day is a number from 1 to 31;
	/// 4. dayOfWeek, month and day are separated each by a space character
	/// 
	/// </summary>
	public class DateParser {

		private readonly string _originalDateString;



		public DateParser(
			string dateString
			) {

			_originalDateString = dateString;
		}



		public string OriginalDateString {
			get { return _originalDateString; }
		}



		public bool TryConvertToDateTime( out DateTime dateTime ) {

			int day, month, year;

			year = DateTime.Now.Year;

			if ( this.TryParseMonth( _originalDateString, out month )
				&& this.TryParseDay( _originalDateString, out day ) ) {

				dateTime = new DateTime( year, month, day );
				return true;
			}

			dateTime = default( DateTime );
			return false;
		}



		private bool TryParseMonth( string dateString, out int month ) {

			string[] dateComponents = dateString.Split( new[] { ' ' } );

			if( dateComponents.Length == 3 ) {

				string monthAbbreviation = dateComponents[ 1 ];

				if( Months.MonthAbbreviationDictionary.TryGetValue( monthAbbreviation, out month ) ) {
					return true;
				}
			}

			month = default( int );
			return false;
			
		}



		private bool TryParseDay( string dateString, out int day ) {

			string[] dateComponents = dateString.Split( new[] { ' ' } );

			if( dateComponents.Length == 3 ) {

				string dayString = dateComponents[ 2 ];

				if( Int32.TryParse( dayString, out day ) ) {
					return true;
				}
			}

			day = default( int );
			return false;
		}
		
	}
}
