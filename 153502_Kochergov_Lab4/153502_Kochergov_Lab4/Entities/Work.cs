using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab3.Entities
{
	public class Work
	{
		public enum WorkType
		{
			InOffice,
			OutsideOffice
		}
		public string Name { get; set; }
		public long Payment { get; set; }
		public WorkType Type { get; set; }

		public Work()
		{
			Name = "Undefined";
		}

		public Work(string name, long payment, WorkType type)
		{
			Name = name;
			Payment = payment;
			Type = type;
		}

		public override string ToString()
		{
			string str = $"Name: {Name} Payment: {Payment} ";
			switch (Type)
			{
				case WorkType.InOffice:
					str += "Type:InOffice";
					break;
				case WorkType.OutsideOffice:
					str += "Type:OutsideOffice";
					break;
			}
			return str;
		}
	}
}
