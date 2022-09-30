using System;
using System.Linq;
using System.Xml.Linq;

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
			XElement
		}
	}
}
