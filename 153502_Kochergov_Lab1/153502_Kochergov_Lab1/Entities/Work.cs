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

		public override string ToString()
		{
			string str = "Name:" + Name + " Salary:" + Salary +" ";
			switch (Type)
			{
				case WorkType.InOffice:
					str += "Type:InOffice";
					break;
				case WorkType.OutsideOffice:
					str += "Type:OutsideOffice";
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			return str;
		}
	}
}
