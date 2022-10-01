using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _153502_Kochergov_Lab5.Domain
{
	public class Station
	{
		[XmlElement("LuggageOffice")]
		public LuggageOffice LuggageOffice { get; set; }

		public Station()
		{
		}

		public Station(LuggageOffice luggageOffice)
		{
			LuggageOffice = luggageOffice;
		}

		public override string ToString()
		{
			return $"Luggage office:\t{LuggageOffice}";
		}
	}
}
