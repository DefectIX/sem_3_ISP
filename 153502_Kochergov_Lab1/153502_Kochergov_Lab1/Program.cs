using System;
using _153502_Kochergov_Lab1.Collections;
using _153502_Kochergov_Lab1.Entities;

namespace _153502_Kochergov_Lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			PayrollDepartment department = new PayrollDepartment();
			department.AddEmployee("Surname1");
			department.AddEmployee("Surname2");

			department.AddWork("Work1", 10, Work.WorkType.OutsideOffice);
			department.AddWork("Work2", 200, Work.WorkType.OutsideOffice);
			department.AddWork("Work3", 3000, Work.WorkType.InOffice);

			department.AddWorkForEmployee("Surname1", "Work1");
			department.AddWorkForEmployee("Surname1", "Work2");
			department.AddWorkForEmployee("Surname2", "Work2");
			department.AddWorkForEmployee("Surname2", "Work3");

			Console.WriteLine(department.GetSalaryBySurname("Surname1"));
			Console.WriteLine(department.GetSalaryBySurname("Surname2"));
			Console.WriteLine(department.GetTotalPayment());
		}
	}
}
