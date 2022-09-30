//
// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab5.Domain
{
	public interface ISerializer
	{
		IEnumerable<Station> DeSerializeByLINQ(string fileName);
		IEnumerable<Station> DeSerializeXML(string fileName);
		IEnumerable<Station> DeSerializeJSON(string fileName);
		void SerializeByLINQ(IEnumerable<Station> xxx, string fileName);
		void SerializeXML(IEnumerable<Station> xxx, string fileName);
		void SerializeJSON(IEnumerable<Station> xxx, string fileName);
	}
}
