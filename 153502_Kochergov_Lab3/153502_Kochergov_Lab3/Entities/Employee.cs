using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Kochergov_Lab3.Collections;
using _153502_Kochergov_Lab3.Interfaces;

namespace _153502_Kochergov_Lab3.Entities
{
	public class Employee
	{
		private readonly List<Work> _lstWorksOfEmployee = new();

		public string Surname { get; set; }

		public Employee()
		{
			Surname = "Undefined";
		}

		public Employee(string surname)
		{
			Surname = surname;
		}

		public void AddWork(Work work)
		{
			_lstWorksOfEmployee.Add(work);
		}

		public long GetPayment()
		{
			return _lstWorksOfEmployee.Sum(x => x.Payment);
		}

		public override string ToString()
		{
			return $"Surname: {Surname}";
		}
	}
}
