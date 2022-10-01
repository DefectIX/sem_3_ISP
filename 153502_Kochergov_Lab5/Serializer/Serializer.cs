using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _153502_Kochergov_Lab5.Domain;

namespace _Serializer
{
	public class Serializer : ISerializer
	{
		public IEnumerable<Station> DeSerializeByLINQ(string fileName)
		{
			XDocument document = XDocument.Load(fileName);
			//var a = document.Element("Stations").Elements("Station").First().Element("LuggageOffice");
			return document.Element("Stations")?
				.Elements("Station")
				.Select(e => new Station(new LuggageOffice
				{
					ContainersNumber = (int) e.Element("LuggageOffice")?.Attribute("ContainersNumber"),
					WorkersNumber = (int) e.Element("LuggageOffice")?.Attribute("WorkersNumber"),
					PhoneNumber = (string) e.Element("LuggageOffice")?.Attribute("PhoneNumber")
				}));
		}

		public IEnumerable<Station> DeSerializeXML(string fileName)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Station> DeSerializeJSON(string fileName)
		{
			throw new NotImplementedException();
		}

		public void SerializeByLINQ(IEnumerable<Station> stations, string fileName)
		{
			XDocument document = new XDocument(
				new XElement("Stations",
					stations.Select(s => new XElement("Station",
						new XElement("LuggageOffice",
							new XAttribute("ContainersNumber", s.LuggageOffice.ContainersNumber),
							new XAttribute("WorkersNumber", s.LuggageOffice.WorkersNumber),
							new XAttribute("PhoneNumber", s.LuggageOffice.PhoneNumber))))));
			document.Save(fileName);
		}

		public void SerializeXML(IEnumerable<Station> stations, string fileName)
		{
			throw new NotImplementedException();
		}

		public void SerializeJSON(IEnumerable<Station> stations, string fileName)
		{
			throw new NotImplementedException();
		}
	}
}
