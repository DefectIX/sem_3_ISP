using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StreamServiceLibrary
{
	public static class ConsoleWriter
	{
		private static readonly string EmptyLine = new(' ', Console.WindowWidth);

		private static readonly List<string> LinesList = new();

		private static bool _refreshStopFlag = false;

		public static int LinesCount
		{
			get
			{
				lock (LinesList)
				{
					return LinesList.Count;
				}
			}
		}

		public static async void StartRefreshCycleAsync()
		{
			_refreshStopFlag = false;
			await Task.Run(DoRefreshCycle);
		}

		public static void StopRefreshCycle()
		{
			_refreshStopFlag = true;
			Console.CursorVisible = true;
		}

		private static void DoRefreshCycle()
		{
			Thread.CurrentThread.IsBackground = false;
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
			lock (LinesList)
			{
				Console.CursorVisible = false;
				Console.SetCursorPosition(0, 0);
				Console.Write(string.Join('\n', LinesList));
			}
		}

		public static void AddLines(int number)
		{
			lock (LinesList)
			{
				LinesList.AddRange(new string[number]);
			}
		}

		public static void RemoveLines(int number)
		{
			lock (LinesList)
			{
				LinesList.RemoveRange(LinesList.Count - number, number);
			}
		}

		public static void SetLine(int lineIndex, string value)
		{
			lock (LinesList)
			{
				LinesList[lineIndex] = value.PadRight(Console.WindowWidth);
			}
		}
	}
}
