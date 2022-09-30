using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _153502_Kochergov_Lab4
{
	class Program
	{
		static void Main(string[] args)
		{
			IFileService<Customer> s = new CustomerFileService();
			List<Customer> lst = new List<Customer>();
			lst.Add(new Customer() { Name = "1" });
			lst.Add(new Customer() { Name = "3" });
			lst.Add(new Customer() { Name = "2" });
			lst.Sort(new MyCustomComparer());
			Console.WriteLine(string.Join(Environment.NewLine, lst.Select(x => x.Name)));
		}
	}
}
