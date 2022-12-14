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
			if (!File.Exists(fileName))
			{
				yield break;
			}
			using BinaryReader binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open));

			while (true)
			{
				Customer customer;
				try
				{
					customer = new Customer
					{
						Name = binaryReader.ReadString(),
						Age = binaryReader.ReadInt32(),
						IsEmployed = binaryReader.ReadBoolean()
					};
				}
				catch (EndOfStreamException)
				{
					yield break;
				}
				catch (Exception e)
				{
					Console.WriteLine($"Caught: {e.Message}");
					yield break;
				}

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
				try
				{
					binaryWriter.Write(customer.Name);
					binaryWriter.Write(customer.Age);
					binaryWriter.Write(customer.IsEmployed);
				}
				catch (Exception e)
				{
					Console.WriteLine($"Caught: {e.Message}");
					return;
				}
			}
		}
	}
}
