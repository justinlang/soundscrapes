using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateUtilities {

	public static class Months {

		public enum Month {
			JAN = 1,
			FEB,
			MAR,
			APR,
			MAY,
			JUN,
			JUL,
			AUG,
			SEP,
			OCT,
			NOV,
			DEC
		}


		/// <summary>
		/// Case insensitive keys.
		/// </summary>
		public static Dictionary<string, int> MonthAbbreviationDictionary {
			get {
				return new Dictionary<string, int>( StringComparer.OrdinalIgnoreCase ) {
					{ "Jan", Month.JAN.ToInt32() },
					{ "Feb", Month.FEB.ToInt32() },
					{ "Mar", Month.MAR.ToInt32() },
					{ "Apr", Month.APR.ToInt32() },
					{ "May", Month.MAY.ToInt32() },
					{ "Jun", Month.JUN.ToInt32() },
					{ "Jul", Month.JUL.ToInt32() },
					{ "Aug", Month.AUG.ToInt32() },
					{ "Sep", Month.SEP.ToInt32() },
					{ "Oct", Month.OCT.ToInt32() },
					{ "Nov", Month.NOV.ToInt32() },
					{ "Dec", Month.DEC.ToInt32() },
				};
			}
		}
	}
}
