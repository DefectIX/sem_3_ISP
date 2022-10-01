using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _153502_Kochergov_Lab5.Domain
{
	[Serializable]
	public class LuggageOffice
	{
		[XmlAttribute("WorkersNumber")]
		public int WorkersNumber { get; set; }
		[XmlAttribute("ContainersNumber")]
		public int ContainersNumber { get; set; }
		[XmlAttribute("PhoneNumber")]
		public string PhoneNumber { get; set; }
	}
}
