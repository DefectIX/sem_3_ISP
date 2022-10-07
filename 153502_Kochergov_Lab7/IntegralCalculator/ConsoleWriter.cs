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
			_consoleThread = new Thread(DoRefreshCycle);
			_consoleThread.Priority = ThreadPriority.AboveNormal;
			_refreshStopFlag = false;
			_consoleThread.Start();
		}

		public static void StopConsoleRefreshing()
		{
			_refreshStopFlag = true;
		}

		private static void DoRefreshCycle()
		{
			while (true)
			{
				Refresh();
				if (_refreshStopFlag)
					break;
				Thread.Sleep(10);
			}
		}

		public static void Refresh()
		{
			lock (_linesList)
			{
				Console.CursorVisible = false;
				Console.SetCursorPosition(0, 0);
				Console.Write(string.Join('\n', _linesList));
				Console.CursorVisible = true;
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

		public static void SetLine(int lineIndex, string value)
		{
			lock (_linesList)
			{
				_linesList[lineIndex] = value;
			}
		}
	}
}
