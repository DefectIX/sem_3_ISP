using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public static class ConsoleWriter
	{
		private static List<string> _linesList = new();

		private static object _block = new();

		public static void UpdateConsole()
		{
			lock (_block)
			{
				Console.SetCursorPosition(0, 0);
				Console.Write(string.Join('\n', _linesList));
			}
		}

		public static void AddLines(int number)
		{
			lock (_block)
			{
				_linesList.AddRange(new string[number]);
			}
		}

		public static void RemoveLines(int number)
		{
			lock (_block)
			{
				_linesList.RemoveRange(_linesList.Count - number, number);
			}
		}

		public static void SetLine(int lineNumber, string newValue)
		{
			lock (_block)
			{
				_linesList[lineNumber] = newValue;
			}
		}
	}
}
