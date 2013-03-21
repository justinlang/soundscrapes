using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logger {

	public static class FileWriter {

		public static void WriteStringToFile( string text, string path ) {

			using( StreamWriter writer = new StreamWriter( path ) ) {
				writer.Write( text );
			}
		}
	}
}
