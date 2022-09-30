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
			using (BinaryReader binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open)))
			{
				while (binaryReader.PeekChar() > -1)
				{
					Customer customer = new();
					customer.Name = binaryReader.ReadString();
					customer.Age = binaryReader.ReadInt32();
					customer.IsEmployed = binaryReader.ReadBoolean();
					yield return customer;
				}
			}
		}

		public void SaveData(IEnumerable<Customer> data, string fileName)
		{
			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(fileName, FileMode.Create)))
			{
				foreach (var customer in data)
				{
					binaryWriter.Write(customer.Name);
					binaryWriter.Write(customer.Age);
					binaryWriter.Write(customer.IsEmployed);
				}
			}
		}
	}
}
