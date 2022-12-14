using System;
using _153502_Kochergov_Lab1.Collections;
using _153502_Kochergov_Lab1.Entities;

namespace _153502_Kochergov_Lab1
{
	//Variant 6
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

			Console.WriteLine("Surname1 salary: " + department.GetSalaryBySurname("Surname1"));
			Console.WriteLine("Surname2 salary: " + department.GetSalaryBySurname("Surname2"));
			Console.WriteLine("Total payment: " + department.GetTotalPayment());
			Console.WriteLine("\n\n" + department);
		}
	}
}
