using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundscapesParser.Data {

	public class Concert {

		public string Band { get; set; }
		public string Venue { get; set; }
		public DateTime Date { get; set; }
		public string Price { get; set; }



		public override string ToString() {
			return this.Band + " " + this.Venue + " " + this.Date + " " + this.Price;
		}
	}
}
