using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateUtilities;
using SoundscapesParser.Data;
using SoundscapesParser.Parser;

namespace DateUtilitiesTests {

	[TestClass]
	public class DateParserTest {

		[TestInitialize()]
		public void Setup() {

		}



		[TestCleanup()]
		public void Cleanup() {

		}



		/// <summary>
		///A test for ConvertToDateTime
		///</summary>
		[TestMethod()]
		public void TryConvertToDateTime_ShouldConvertValidStringToDateTime1() {

			string dateString = "Wed. Mar 20";
			DateParser target = new DateParser( dateString );
			DateTime actual;
			target.TryConvertToDateTime( out actual );

			DateTime expected = new DateTime( 2013, 3, 20 );
			
			Assert.IsTrue( actual == expected );
		}
	}
}
