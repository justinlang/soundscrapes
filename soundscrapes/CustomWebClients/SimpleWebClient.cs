using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace CustomWebClients {

	public class SimpleWebClient {

		public delegate void DownloadStringCompletedHandler( object sender, string downloadedString );
		public event DownloadStringCompletedHandler OnDownloadStringCompleted;

		private readonly WebClient _webclient;



		public SimpleWebClient() {
			_webclient = new WebClient();
		}



		public string DownloadString( string uri ) {

			return _webclient.DownloadString( new Uri( uri ) );
		}



		public void DownloadStringAsync( string uri ) {

			_webclient.DownloadStringCompleted += ( sender, e ) => {

				if( OnDownloadStringCompleted != null ) {
					OnDownloadStringCompleted( this, e.Result ); 
				}

				// Remove the handler in case the object persists
				OnDownloadStringCompleted = null;
			};

			_webclient.DownloadStringAsync( new Uri( uri ) );
		}
	}
}
