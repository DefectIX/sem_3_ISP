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
			var query = from x in Enumerable.Range(1, 10)
						from y in Enumerable.Range(1, 10)
						select $"{x * y} " + ((y == 10) ? "\n" : "") + ((y != 10 && x * y / 10 == 0) ? " " : "");

			string res = "";
			for (int i = 1; i <= 10; i++)
				for (int j = 1; j <= 10; j++)
					res += $"{i * j} " + ((j == 10) ? "\n" : "") + ((j != 10 && i * j / 10 == 0) ? " " : "");

			//Console.WriteLine(string.Join("", query));
			Console.WriteLine(res);
			ISerializer serializer = new Serializer();
			List<Station> list = new List<Station>();
			list.Add(new Station(new LuggageOffice { ContainersNumber = 1, PhoneNumber = "111-11-11", WorkersNumber = 12}));
			list.Add(new Station(new LuggageOffice { ContainersNumber = 321, PhoneNumber = "8-800-555-3535", WorkersNumber = 12}));


			serializer.SerializeByLINQ(list, "file.xml");
			File.Move("file.xml", "file2.xml", true);

			var list2 = serializer.DeSerializeByLINQ("file2.xml");
			Console.WriteLine(string.Join("\n", list2));

			File.Delete("file2.xml");
		}
	}
}
