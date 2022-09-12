using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Kochergov_Lab1.Collections;

namespace _153502_Kochergov_Lab1.Entities
{
	class Employee
	{
		public MyCustomCollection<Work> LstWorksOfEmployee { get; set; } = new MyCustomCollection<Work>();
		public string Surname { get; set; }

		public Employee()
		{
		}

		public Employee(string surname)
		{
			Surname = surname;
		}
		
		public void AddWork(string name, long salary, Work.WorkType type)
		{
			LstWorksOfEmployee.Add(new Work(name, salary, type));
		}

		public long GetSalary()
		{
			long result = 0;
			foreach(var work in LstWorksOfEmployee)
				result += work.Salary;
			return result;
		}
	}
}
