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
			List<Customer> list1 = new()
			{
				new() { Name = "Name1", Age = 34, IsEmployed = true },
				new() { Name = "Name3", Age = 35, IsEmployed = false },
				new() { Name = "Name2", Age = 32, IsEmployed = true },
				new() { Name = "Name5", Age = 31, IsEmployed = false },
				new() { Name = "Name4", Age = 31, IsEmployed = true }
			};
			
			string path1 = "FileName1", path2 = "FileName2";
			IFileService<Customer> fileService = new CustomerFileService();
			
			fileService.SaveData(list1, path1);
			
			File.Move(path1, path2, true);
			
			List<Customer> list2 = new();
			
			foreach (var customer in fileService.ReadFile(path2))
			{
				list2.Add(customer);
			}
			list2.Sort(new MyCustomComparer());
			Console.WriteLine("Sorted by name with MyCustomComparer:");
			Console.WriteLine(string.Join(Environment.NewLine, list2));

			list2.Sort((x, y) => x.Age.CompareTo(y.Age));
			Console.WriteLine("\nSorted by age with lambda expression:");
			Console.WriteLine(string.Join(Environment.NewLine, list2));

			File.Delete(path2);
		}
	}
}
