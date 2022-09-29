using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Kochergov_Lab3.Collections;
using _153502_Kochergov_Lab3.Entities;
using _153502_Kochergov_Lab3.Interfaces;

namespace _153502_Kochergov_Lab3.Entities
{
	public class PayrollDepartment
	{
		public delegate void MessageHandler(string message);

		public event MessageHandler WorksListChanged;
		public event MessageHandler EmployeeListChanged;
		public event MessageHandler EmployeeReceivedWork;

		private readonly Dictionary<string, Work> _dctWorks = new();
		private readonly List<Employee> _lstEmployees = new();

		public void AddEmployee(string surname)
		{
			_lstEmployees.Add(new Employee(surname));
			EmployeeListChanged?.Invoke($"Employee {surname} registered");
		}

		public void AddWork(string workName, long payment, Work.WorkType type)
		{
			_dctWorks.Add(workName, new Work(workName, payment, type));
			WorksListChanged?.Invoke($"Work {workName} registered");
		}

		public Employee FindEmployee(string surname)
		{
			foreach (var employee in _lstEmployees)
			{
				if (employee.Surname == surname)
				{
					return employee;
				}
			}
			return default;
		}

		public Work FindWork(string workName)
		{
			foreach (var work in _dctWorks)
			{
				if (work.Key == workName)
				{
					return work.Value;
				}
			}
			return default;
		}

		public void AddWorkForEmployee(string employeeSurname, string workName)
		{
			Employee employee = FindEmployee(employeeSurname);
			Work work = FindWork(workName);
			employee.AddWork(work);
			EmployeeReceivedWork?.Invoke($"Employee {employeeSurname} received work {workName}");
		}

		public override string ToString()
		{
			string str = "";
			if (_lstEmployees.Count == 0)
			{
				str += "No employees\n";
			}
			else
			{
				str += "Employees:\n";
				foreach (var employee in _lstEmployees)
				{
					str += employee + "\n";
				}
			}

			str += "\n";

			if (_dctWorks.Count == 0)
			{
				str += "No works\n";
			}
			else
			{
				str += "Works:\n";
				foreach (var work in _dctWorks)
				{
					str += work + "\n";
				}
			}
			return str;
		}


		//LINQ Methods
		public List<string> GetSortedWorkNamesList()
		{
			return _dctWorks.OrderBy(x => x.Value.Payment).Select(x => x.Key).ToList();
		}

		public long GetTotalPayment()
		{
			return _lstEmployees.Sum(x => x.GetPayment());
		}

		public long GetEmployeePayment(string surname)
		{
			return FindEmployee(surname).GetPayment();
		}

		public string FindEmployeeWithMaxPayment()
		{
			long max = _lstEmployees.Max(x => x.GetPayment());
			return _lstEmployees.First(x => x.GetPayment().Equals(max)).Surname;
		}

		public int GetNumberOfWorkersWithPaymentGreaterThan(long minPayment)
		{
			return _lstEmployees.Aggregate(0, (number, employee) => number += employee.GetPayment() > minPayment ? 1 : 0);
		}

		public IEnumerable<(string Surname, long Payment)> GetWorkerWorksPayments(string surname)
		{
			return FindEmployee(surname).GetWorksPayments();
		}
	}
}
