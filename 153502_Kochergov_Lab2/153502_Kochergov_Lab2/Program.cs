using System;
using _153502_Kochergov_Lab2.Collections;
using _153502_Kochergov_Lab2.Entities;

namespace _153502_Kochergov_Lab2
{
	//Variant 6
	class Program
	{
		static void Main(string[] args)
		{
			PayrollDepartment department = new PayrollDepartment();
			Journal journal = new Journal();

			department.EmployeeListChanged += journal.AddToHistory;
			department.WorksListChanged += journal.AddToHistory;
			department.EmployeeRecievedWork += (str) => Console.WriteLine(str);

			department.AddEmployee("Surname1");
			department.AddEmployee("Surname2");

			department.AddWork("Work1", 10, Work.WorkType.OutsideOffice);
			department.AddWork("Work2", 200, Work.WorkType.OutsideOffice);
			department.AddWork("Work3", 3000, Work.WorkType.InOffice);

			department.AddWorkForEmployee("Surname1", "Work1");
			department.AddWorkForEmployee("Surname1", "Work2");
			department.AddWorkForEmployee("Surname2", "Work2");
			department.AddWorkForEmployee("Surname2", "Work3");

			//Console.WriteLine($"\nSurname1 payment: {department.GetPaymentBySurname("Surname1")}");
			//Console.WriteLine($"Surname2 payment: {department.GetPaymentBySurname("Surname2")}");
			//Console.WriteLine($"Total payment: {department.GetTotalPayment()}");
			//Console.WriteLine($"\n\n{department}\n\n");

			Console.WriteLine("\n");
			journal.PrintHistory();


			//Exceptions demonstration
			MyCustomCollection<int> collection = new();
			collection.Add(1);
			collection.Add(2);
			collection.Add(3);
			//Console.WriteLine(collection[10]); //OutOfRangeException
			//collection.Remove(5); //ArgumentException

		}
	}
}
