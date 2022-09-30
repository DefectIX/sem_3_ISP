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

			throw new NotImplementedException();
		}

		public void SaveData(IEnumerable<Customer> data, string fileName)
		{
			using (BinaryWriter bw = new BinaryWriter(File.Open("path", FileMode.OpenOrCreate)))
			{
				w.Write
			}

			throw new NotImplementedException();
		}
	}
}
