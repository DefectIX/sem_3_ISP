using System;
using System.IO;

namespace _153502_Kochergov_Lab4
{
	class Program
	{
		static void Main(string[] args)
		{
			IFileService<Customer> s = new CustomerFileService();
			Console.WriteLine("Hello World!");
		}
	}
}
