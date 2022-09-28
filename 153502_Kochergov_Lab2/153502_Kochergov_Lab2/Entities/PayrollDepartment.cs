using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Kochergov_Lab2.Collections;
using _153502_Kochergov_Lab2.Entities;
using _153502_Kochergov_Lab2.Interfaces;

namespace _153502_Kochergov_Lab2.Entities
{
	public class PayrollDepartment
	{
		public delegate void MessageHandler(string message);

		public event MessageHandler WorksListChanged;
		public event MessageHandler EmployeeListChanged;
		public event MessageHandler EmployeeRecievedWork;

		private readonly ICustomCollection<Employee> _lstEmployees = new MyCustomCollection<Employee>();
		private readonly ICustomCollection<Work> _lstWorks = new MyCustomCollection<Work>();

		public void AddEmployee(string surname)
		{
			_lstEmployees.Add(new Employee(surname));
			EmployeeListChanged?.Invoke($"Employee {surname} registered");
		}

		public void AddWork(string workName, long payment, Work.WorkType type)
		{
			_lstWorks.Add(new Work(workName, payment, type));
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
			foreach (var work in _lstWorks)
			{
				if (work.Name == workName)
				{
					return work;
				}
			}
			return default;
		}

		public void AddWorkForEmployee(string employeeSurname, string workName)
		{
			Employee employee = FindEmployee(employeeSurname);
			Work work = FindWork(workName);
			employee.AddWork(work);
			EmployeeRecievedWork?.Invoke($"Employee {employeeSurname} recieved work {workName}");
		}

		public long GetPaymentBySurname(string surname)
		{
			return FindEmployee(surname).GetPayment();
		}

		public long GetTotalPayment()
		{
			long total = 0;
			foreach (var curEmployee in _lstEmployees)
			{
				total += curEmployee.GetPayment();
			}

			return total;
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

			if (_lstWorks.Count == 0)
			{
				str += "No works\n";
			}
			else
			{
				str += "Works:\n";
				foreach (var work in _lstWorks)
				{
					str += work + "\n";
				}
			}
			return str;
		}
	}
}
