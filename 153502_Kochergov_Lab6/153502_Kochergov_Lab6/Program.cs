using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace _153502_Kochergov_Lab6
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Employee> list = new()
			{
				new() { Name = "Name1", Age = 34, IsOutsourcer = true },
				new() { Name = "Name3", Age = 35, IsOutsourcer = false },
				new() { Name = "Name2", Age = 32, IsOutsourcer = true },
				new() { Name = "Name5", Age = 31, IsOutsourcer = false },
				new() { Name = "Name4", Age = 31, IsOutsourcer = true }
			};

			Assembly assembly = Assembly.LoadFile(Path.GetFullPath("FileService.dll"));
			Type type = assembly.GetType("_FileService.FileService`1")!.MakeGenericType(typeof(Employee));
			var fileService = Activator.CreateInstance(type) as IFileService<Employee>;
			fileService!.SaveData(list, "list.json");
			var list2 = fileService.ReadFile("list.json");
			Console.WriteLine(string.Join("\n", list2));
		}
	}
}
