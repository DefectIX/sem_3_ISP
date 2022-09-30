using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Kochergov_Lab5.Domain;

namespace Serializer
{
	class Serializer : ISerializer
	{
		public IEnumerable<Station> DeSerializeByLINQ(string fileName)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Station> DeSerializeXML(string fileName)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Station> DeSerializeJSON(string fileName)
		{
			throw new NotImplementedException();
		}

		public void SerializeByLINQ(IEnumerable<Station> xxx, string fileName)
		{
			throw new NotImplementedException();
		}

		public void SerializeXML(IEnumerable<Station> xxx, string fileName)
		{
			throw new NotImplementedException();
		}

		public void SerializeJSON(IEnumerable<Station> xxx, string fileName)
		{
			throw new NotImplementedException();
		}
	}
}
