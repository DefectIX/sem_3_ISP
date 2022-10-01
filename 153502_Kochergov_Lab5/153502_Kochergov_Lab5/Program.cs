//
// ReSharper disable JoinDeclarationAndInitializer
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using _153502_Kochergov_Lab5.Domain;
using _Serializer;

namespace _153502_Kochergov_Lab5
{
	class Program
	{
		static void Main(string[] args)
		{
			bool shouldDelete = true;

			ISerializer serializer = new Serializer();
			List<Station> list = new List<Station>();
			list.Add(new Station(new LuggageOffice { ContainersNumber = 1, PhoneNumber = "111-11-11", WorkersNumber = 1 }));
			list.Add(new Station(new LuggageOffice { ContainersNumber = 4, PhoneNumber = "444-44-44", WorkersNumber = 4 }));
			list.Add(new Station(new LuggageOffice { ContainersNumber = 3, PhoneNumber = "333-33-33", WorkersNumber = 3 }));
			list.Add(new Station(new LuggageOffice { ContainersNumber = 2, PhoneNumber = "222-22-22", WorkersNumber = 2 }));
			list.Add(new Station(new LuggageOffice { ContainersNumber = 5, PhoneNumber = "555-55-55", WorkersNumber = 5 }));

			IEnumerable<Station> list2;

			string linqPath = "linq.xml";
			string xmlPath = "xml.xml";
			string jsonPath = "json.json";

			Console.WriteLine("====================Serialization by LINQ to XML:===================");
			serializer.SerializeByLINQ(list, linqPath);
			Console.WriteLine("Created file:");
			Console.WriteLine(File.ReadAllText(linqPath));
			list2 = serializer.DeSerializeByLINQ(linqPath);
			Console.WriteLine("\nDeserialized collection:");
			Console.WriteLine(string.Join("\n", list2) + "\n\n\n");
			if (shouldDelete) File.Delete(linqPath);

			Console.WriteLine("====================Serialization by XmlSerializer class:===========");
			serializer.SerializeXML(list, xmlPath);
			Console.WriteLine("Created file:");
			Console.WriteLine(File.ReadAllText(xmlPath));
			list2 = serializer.DeSerializeXML(xmlPath);
			Console.WriteLine("\nDeserialized collection:");
			Console.WriteLine(string.Join("\n", list2) + "\n\n\n");
			if (shouldDelete) File.Delete(xmlPath);

			Console.WriteLine("====================Serialization by JsonSerializer class:==========");
			serializer.SerializeJSON(list, jsonPath);
			Console.WriteLine("Created file:");
			Console.WriteLine(File.ReadAllText(jsonPath));
			list2 = serializer.DeSerializeJSON(jsonPath);
			Console.WriteLine("\nDeserialized collection:");
			Console.WriteLine(string.Join("\n", list2) + "\n\n\n");
			if (shouldDelete) File.Delete(jsonPath);
		}
	}
}
