using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateUtilities {

	public static class ExtensionMethods {

		public static int ToInt32( this Months.Month month ) {

			return Convert.ToInt32( month );
		}
	}
}
