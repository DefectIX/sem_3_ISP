using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab6
{
	public class Employee
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public bool IsOutsourcer { get; set; }
		public override string ToString()
		{
			return $"Name:{Name} Age:{Age} Is outsourcer:{IsOutsourcer}";
		}
	}
}
