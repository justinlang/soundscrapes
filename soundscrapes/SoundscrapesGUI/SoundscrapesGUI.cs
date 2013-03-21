using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoundscapesParser.Parser;
using SoundscapesParser.Data;
using CustomCollections;
using CustomWebClients;

namespace SoundscrapesGUI {

	public partial class mainForm : Form {

		private SimpleWebClient _client;
		private IEnumerable<Concert> _concerts;
		private IEnumerable<string> _venues;
		private readonly string TICKET_URI = @"http://www.soundscapesmusic.com/tickets/";



		public mainForm() {

			InitializeComponent();
			InitializePrivateFields();
		}



		private void InitializePrivateFields() {

			_client = new SimpleWebClient();
			_concerts = new List<Concert>();
			_venues = new List<string>();
		}



		private void SoundscrapesGUI_Load( object sender, EventArgs e ) {
			this.RefreshList();
		}



		#region Control Event Handlers

		private void refreshButton_Click( object sender, EventArgs e ) {
			this.RefreshList();
		}



		private void searchBandButton_Click( object sender, EventArgs e ) {
			this.SearchBands();
		}



		private void searchVenueButton_Click( object sender, EventArgs e ) {
			this.SearchVenues();
		}



		// Force focus for mousewheel scrolling
		private void concertsDataGridView_MouseEnter( object sender, EventArgs e ) {
			concertsDataGridView.Focus();
		}

		#endregion



		#region Data Binding

		private void RefreshList() {

			this.BindConcertsAsync( () => {
				this.FormatDateColumn();
				this.BindVenuesToComboBox();
			} );
		}



		private void BindConcertsAsync( Action callback ) {

			_client.OnDownloadStringCompleted += ( sender, downloadedString ) => {

				// Pass downloadedString to Invoke,
				// so when the delegate is called it is passed as page
				this.Invoke(
					( Action<string> )( page => {
						this.ParseAndBindPage( page );
						callback();
					} ),
					downloadedString );
			};

			_client.DownloadStringAsync( TICKET_URI );
		}



		private void BindConcerts() {

			string page = _client.DownloadString( TICKET_URI );
			this.ParseAndBindPage( page );
		}



		private void ParseAndBindPage( string page ) {

			ConcertPageParser parser = new ConcertPageParser( page );
			_concerts = parser.Concerts;
			_venues = parser.Venues;
			this.BindWithSortableBindingList( _concerts );
		}



		private void BindWithSortableBindingList( IEnumerable<Concert> concerts ) {
			concertsDataGridView.DataSource = new SortableBindingList<Concert>( concerts );
		}



		private void BindWithList( IEnumerable<Concert> concerts ) {
			concertsDataGridView.DataSource = concerts.ToList();
		}



		private void BindVenuesToComboBox() {

			List<string> venues = _venues.ToList();
			venues.Sort();
			venueComboBox.DataSource = venues;
		}

		#endregion



		#region Search

		private void SearchBands() {

			string query = bandSearchTextBox.Text;
			IEnumerable<Concert> searchResults;

			if( startsWithRadioButton.Checked ) {
				searchResults = this.SearchBandsStartingWith( query );
			} else { // Assume containsRadioButton is checked
				searchResults = this.SearchBandsContaining( query );
			}

			this.BindWithSortableBindingList( searchResults );
		}



		private void SearchVenues() {

			string query = venueComboBox.SelectedItem.ToString();
			IEnumerable<Concert> searchResults;

			searchResults = this.SearchVenuesContaining( query );

			this.BindWithSortableBindingList( searchResults );
		}



		private IEnumerable<Concert> SearchVenuesContaining( string query ) {

			IEnumerable<Concert> searchResults = this.SearchConcerts(
				concert => -1 != concert.Venue.IndexOf( query, StringComparison.OrdinalIgnoreCase )
			);

			return searchResults;
		}



		private IEnumerable<Concert> SearchBandsContaining( string query ) {

			IEnumerable<Concert> searchResults = this.SearchConcerts(
				concert => -1 != concert.Band.IndexOf( query, StringComparison.OrdinalIgnoreCase )
			);

			return searchResults;
		}



		private IEnumerable<Concert> SearchBandsStartingWith( string query ) {

			IEnumerable<Concert> searchResults = this.SearchConcerts(
				concert => concert.Band.StartsWith( query, StringComparison.OrdinalIgnoreCase )
			);

			return searchResults;
		}



		private IEnumerable<Concert> SearchConcerts( Func<Concert, bool> condition ) {
			return _concerts.Where( condition );
		}

		#endregion



		#region Other

		private void FormatDateColumn() {
			concertsDataGridView.Columns[ "Date" ].DefaultCellStyle.Format = "ddd MMM d";
		}

		#endregion
	}
}
