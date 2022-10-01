﻿using System;
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
			ISerializer serializer = new Serializer();
			List<Station> list = new List<Station>();
			list.Add(new Station(new LuggageOffice { ContainersNumber = 7, PhoneNumber = "111-11-11", WorkersNumber = 5}));
			list.Add(new Station(new LuggageOffice { ContainersNumber = 220, PhoneNumber = "777", WorkersNumber = 11238}));
			list.Add(new Station(new LuggageOffice { ContainersNumber = 35, PhoneNumber = "8-800-555-3535", WorkersNumber = 78}));


			serializer.SerializeByLINQ(list, "file.xml");
			File.Move("file.xml", "file2.xml", true);

			var list2 = serializer.DeSerializeByLINQ("file2.xml");
			Console.WriteLine(string.Join("\n", list2) + "\n\n");

			//File.Delete("file2.xml");

			serializer.SerializeXML(list, "xml.xml");
			list2 = serializer.DeSerializeXML("xml.xml");
			Console.WriteLine(string.Join("\n", list2) + "\n\n");

			//File.Delete("xml.xml");
			serializer.SerializeJSON(list, "json.json");
			list2 = serializer.DeSerializeJSON("json.json");
			Console.WriteLine(string.Join("\n", list2));
		}
	}
}
