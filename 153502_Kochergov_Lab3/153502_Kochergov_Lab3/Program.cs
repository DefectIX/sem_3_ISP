using System;
using System.Linq;
using _153502_Kochergov_Lab3.Collections;
using _153502_Kochergov_Lab3.Entities;

namespace _153502_Kochergov_Lab3
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
			department.EmployeeReceivedWork += (str) => Console.WriteLine(str);

			department.AddEmployee("Surname1");
			department.AddEmployee("Surname2");
			department.AddEmployee("Surname3");

			department.AddWork("Work1", 100, Work.WorkType.OutsideOffice);
			department.AddWork("Work2", 20, Work.WorkType.OutsideOffice);
			department.AddWork("Work3", 3000, Work.WorkType.InOffice);

			department.AddWorkForEmployee("Surname1", "Work1");
			department.AddWorkForEmployee("Surname1", "Work2");
			department.AddWorkForEmployee("Surname2", "Work2");
			department.AddWorkForEmployee("Surname2", "Work3");
			department.AddWorkForEmployee("Surname3", "Work3");

			Console.WriteLine(string.Join(Environment.NewLine, department.GetSortedWorkNamesList()));
			Console.WriteLine($"\nSurname1 payment: {department.GetEmployeePayment("Surname1")}");
			Console.WriteLine($"Surname2 payment: {department.GetEmployeePayment("Surname2")}");
			Console.WriteLine($"Surname3 payment: {department.GetEmployeePayment("Surname3")}");
			Console.WriteLine($"Total payment: {department.GetTotalPayment()}");
			Console.WriteLine($"Employee with max payment: {department.FindEmployeeWithMaxPayment()}");

			int minPayment = 3000;
			Console.WriteLine($"Employee with payment more than {minPayment}: {department.GetNumberOfWorkersWithPaymentGreaterThan(minPayment)}");


			var workerWorksPayments = department.GetWorkerWorksPayments("Surname2");
			Console.WriteLine("\n\n");

			Console.WriteLine(string.Join(Environment.NewLine, workerWorksPayments.Select(x => $"{x.Surname} {x.Payment}")));




			//Console.WriteLine($"\n\n{department}\n\n");
			//Console.WriteLine("\n");
			//journal.PrintHistory();

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
