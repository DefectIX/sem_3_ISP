using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public class ConsoleWriter
	{
		public List<string> Lines = new();

		private object block = new();

		public void UpdateConsole()
		{
			lock (block)
			{
				Console.SetCursorPosition(0, 0);
				Console.Write(string.Join('\n', Lines));
			}
		}

		public void AddLines(int number)
		{
			Lines.AddRange(new string[number]);
		}
	}
}
