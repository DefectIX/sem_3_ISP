using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab4
{
	class CustomerFileService : IFileService<Customer>
	{
		public IEnumerable<Customer> ReadFile(string fileName)
		{
			using BinaryReader binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open));
			while (binaryReader.PeekChar() > -1)
			{
				Customer customer = new()
				{
					Name = binaryReader.ReadString(),
					Age = binaryReader.ReadInt32(),
					IsEmployed = binaryReader.ReadBoolean()
				};
				yield return customer;
			}
		}

		public void SaveData(IEnumerable<Customer> data, string fileName)
		{
			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}
			using BinaryWriter binaryWriter = new BinaryWriter(File.Open(fileName, FileMode.Create));
			foreach (var customer in data)
			{
				binaryWriter.Write(customer.Name);
				binaryWriter.Write(customer.Age);
				binaryWriter.Write(customer.IsEmployed);
			}
		}
	}
}
