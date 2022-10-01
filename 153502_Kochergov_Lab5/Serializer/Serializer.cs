using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using _153502_Kochergov_Lab5.Domain;

namespace _Serializer
{
	public class Serializer : ISerializer
	{
		public IEnumerable<Station> DeSerializeByLINQ(string fileName)
		{
			XDocument document = XDocument.Load(fileName);
			return document.Element("Stations")?
				.Elements("Station")
				.Select(e => e.Element("LuggageOffice"))
				.Select(e => new Station(new LuggageOffice
				{
					ContainersNumber = (int)e?.Attribute("ContainersNumber"),
					WorkersNumber = (int)e?.Attribute("WorkersNumber"),
					PhoneNumber = (string)e?.Attribute("PhoneNumber")
				}));
		}

		public IEnumerable<Station> DeSerializeXML(string fileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Station[]));
			using FileStream fileStream = new FileStream(fileName, FileMode.Open);
			return xmlSerializer.Deserialize(fileStream) as IEnumerable<Station>;
		}

		public IEnumerable<Station> DeSerializeJSON(string fileName)
		{
			throw new NotImplementedException();
		}

		public void SerializeByLINQ(IEnumerable<Station> stations, string fileName)
		{
			XDocument document = new XDocument(
				new XElement("Stations",
					stations.Select(s => s.LuggageOffice).Select(o => new XElement("Station",
						new XElement("LuggageOffice",
							new XAttribute("ContainersNumber", o.ContainersNumber),
							new XAttribute("WorkersNumber", o.WorkersNumber),
							new XAttribute("PhoneNumber", o.PhoneNumber))))));
			document.Save(fileName);
		}

		public void SerializeXML(IEnumerable<Station> stations, string fileName)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(stations.GetType());
			using FileStream fileStream = new FileStream(fileName, FileMode.Create);
			xmlSerializer.Serialize(fileStream, stations);
		}

		public void SerializeJSON(IEnumerable<Station> stations, string fileName)
		{
			throw new NotImplementedException();
		}
	}
}
