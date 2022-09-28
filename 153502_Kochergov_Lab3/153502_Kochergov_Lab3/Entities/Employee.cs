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
		public ICustomCollection<Work> LstWorksOfEmployee { get; } = new MyCustomCollection<Work>();
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
			LstWorksOfEmployee.Add(work);
		}

		public long GetPayment()
		{
			long result = 0;
			foreach (var work in LstWorksOfEmployee)
				result += work.Payment;
			return result;
		}

		public override string ToString()
		{
			return $"Surname: {Surname}";
		}
	}
}
