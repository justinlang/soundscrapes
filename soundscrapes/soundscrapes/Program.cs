using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using SoundscapesParser.Data;
using SoundscapesParser.Parser;
using CustomWebClients;

namespace soundscrapes {
	class Program {

		static void Main( string[] args ) {

			string page = Program.DownloadPage( @"http://www.soundscapesmusic.com/tickets/" );

			IEnumerable<Concert> concerts = Program.ParseConcerts( page );

			foreach( var concert in concerts ) {
				Console.WriteLine( concert.ToString() );
			}
			Console.Read();
		}



		private static IEnumerable<Concert> ParseConcerts( string page ) {

			ConcertPageParser parser = new ConcertPageParser( page );
			return parser.Concerts;
		}



		private static string DownloadPage( string uri ) {

			SimpleWebClient client = new SimpleWebClient();

			Console.WriteLine( "Downloading..." );
			var page = client.DownloadString( uri );

			Console.WriteLine( "Done." );
			return page;
		}
	}
}
