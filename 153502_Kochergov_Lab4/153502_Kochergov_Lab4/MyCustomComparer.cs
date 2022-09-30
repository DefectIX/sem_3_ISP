using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab4
{
	class MyCustomComparer : IComparer<Customer>
	{
		public int Compare(Customer x, Customer y)
		{
			return string.CompareOrdinal(x.Name, y.Name);
		}
	}
}
