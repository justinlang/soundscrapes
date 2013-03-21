using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoundscapesParser.Data;
using System.Xml.Linq;
using DateUtilities;

namespace SoundscapesParser.Parser {

	/// <summary>
	/// IMPORTANT NOTE:
	/// 
	/// This parser assumes a LOT about the HTML formatting of the table on the concert page
	/// on www.soundscapesmusic.com/tickets .
	/// 
	/// Some assumptions are:
	/// 
	/// 1. The first row in the table always contains the headers for the table;
	/// 2. The table is enclosed with the tbody tag;
	/// 3. There are always four columns in each row which map to the Band, Venue, Date and Price;
	/// 4. There is a final closing tr tag which does not have a matching opening tr tag
	/// 
	/// There are some other assumptions about the presence of characters which need to be XML encoded.
	/// </summary>
	public class ConcertPageParser {

		private readonly string _concertPage;
		private readonly string _concertTable;



		public ConcertPageParser( string concertPage ) {
			_concertPage = concertPage;
			_concertTable = this.ParseConcertTableFromPage( _concertPage );
		}



		public IEnumerable<Concert> Concerts {
			get { return this.ParseConcertsFromTable( _concertTable ); }
		}



		public IEnumerable<string> Venues {
			get {
				return this.Concerts
					.GroupBy( concert => concert.Venue )
					.Select( group => group.Key );
			}
		}



		private string ParseConcertTableFromPage( string concertPage ) {

			string startTag = @"<tbody>";
			string endTag = @"</tbody>";

			var startIndex = concertPage.IndexOf( startTag );
			var endIndex = concertPage.IndexOf( endTag ) + endTag.Length;

			var concertTable = concertPage.Substring( startIndex, endIndex - startIndex );

			return concertTable;
		}



		private IEnumerable<Concert> ParseConcertsFromTable( string table ) {

			table = this.SanitizeConcertTable( table );
			XElement concerts = XElement.Parse( table );

			bool skipRow = true;

			foreach( var tr in concerts.Elements( XName.Get( "tr" ) ) ) {

				// Skip only the FIRST row in the table which should be the headers
				if( skipRow ) { skipRow = false; continue; }

				var tds = tr.Elements( XName.Get( "td" ) ).ToArray();

				Concert concert;
				if( this.TryConstructConcert( tds, out concert ) ) {
					yield return concert;
				}
			}
		}



		private bool TryConstructConcert( XElement[] tdColumns, out Concert concert ) {

			if( tdColumns.Length == 4 ) {

				concert = new Concert();
				concert.Band = tdColumns[ 0 ].Value;
				concert.Venue = tdColumns[ 1 ].Value;
				concert.Price = tdColumns[ 3 ].Value;

				// Only return true if we can parse the date
				DateTime date;
				if (this.TryParseDate( tdColumns[ 2 ].Value, out date ) ) {
					concert.Date = date;
					return true;
				}
			}

			concert = default( Concert );
			return false;
		}



		private bool TryParseDate( string dateString, out DateTime date ) {

			DateParser dateParser = new DateParser( dateString );

			if( dateParser.TryConvertToDateTime( out date ) ) {
				return true;
			}

			date = default( DateTime );
			return false;
		}



		private string SanitizeConcertTable( string concertTable ) {

			concertTable = this.RemoveOpenBrTags( concertTable );
			concertTable = this.RemoveLastClosingTrTag( concertTable );
			concertTable = this.RemoveInvalidXmlCharacters( concertTable );
			return concertTable;
		}



		private string RemoveOpenBrTags( string text ) {

			string brTag = @"<br>";
			return text.Replace( brTag, string.Empty );
		}



		private string RemoveLastClosingTrTag( string text ) {

			string trTag = @"</tr>";
			return text.Remove( text.LastIndexOf( trTag ), trTag.Length );
		}



		public string RemoveInvalidXmlCharacters( string text ) {

			char[] invalidChars = new[] { '&' };
			var validXmlChars = text.Where( ch => !invalidChars.Contains( ch ) );
			return new string( validXmlChars.ToArray() );
		}
	}
}
