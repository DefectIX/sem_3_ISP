using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab1.Entities
{
	public class Work
	{
		public enum WorkType
		{
			InOffice,
			OutsideOffice
		}
		public string Name { get; set; }
		public long Salary { get; set; }
		public WorkType Type { get; set; }

		public Work()
		{
		}

		public Work(string name, long salary, WorkType type)
		{
			Name = name;
			Salary = salary;
			Type = type;
		}
	}
}
