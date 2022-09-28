using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab2.Entities
{
	class Journal
	{
		public Journal()
		{
			History = "";
		}

		public string History { get; private set; }

		public void AddToHistory(string eventString)
		{
			History += eventString + '\n';
		}

		public void PrintHistory()
		{
			Console.WriteLine(History);
		}
	}
}
