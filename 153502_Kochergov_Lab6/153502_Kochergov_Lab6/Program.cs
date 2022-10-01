using System;
using System.IO;
using System.Reflection;

namespace _153502_Kochergov_Lab6
{
	class Program
	{
		static void Main(string[] args)
		{
			Assembly assembly = Assembly.LoadFile(Path.GetFullPath("FileService.dll"));
			Type type = assembly.GetTypes()[0];
			var fileService = Activator.CreateInstance(type.MakeGenericType(typeof(Employee))) as IFileService<Employee>;
			
		}
	}
}
