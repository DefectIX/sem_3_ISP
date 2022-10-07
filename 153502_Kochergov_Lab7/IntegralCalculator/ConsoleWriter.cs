using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public static class ConsoleWriter
	{
		private static List<string> _linesList = new();

		private static Thread _consoleThread;

		private static bool _refreshStopFlag = false;

		public static int LinesCount
		{
			get
			{
				lock (_linesList)
					return _linesList.Count;
			}
		}

		public static void StartConsoleRefreshing()
		{
			Console.CursorVisible = false;
			_consoleThread = new Thread(Refresh);
			_refreshStopFlag = false;
			_consoleThread.Start();
		}

		public static void StopConsoleRefreshing()
		{
			_refreshStopFlag = true;
			Console.CursorVisible = true;
		}

		private static void Refresh()
		{
			while (true)
			{
				lock (_linesList)
				{
					Console.SetCursorPosition(0, 0);
					Console.Write(string.Join('\n', _linesList));
				}
				if (_refreshStopFlag)
					break;
				Thread.Sleep(10);
			}
		}

		public static void AddLines(int number)
		{
			lock (_linesList)
			{
				_linesList.AddRange(new string[number]);
			}
		}

		public static void RemoveLines(int number)
		{
			lock (_linesList)
			{
				_linesList.RemoveRange(_linesList.Count - number, number);
			}
		}

		public static void SetLine(int lineNumber, string newValue)
		{
			lock (_linesList)
			{
				_linesList[lineNumber] = newValue;
			}
		}
	}
}
