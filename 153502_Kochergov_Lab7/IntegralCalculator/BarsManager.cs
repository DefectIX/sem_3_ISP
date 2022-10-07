//
// ReSharper disable CompareOfFloatsByEqualityOperator
// ReSharper disable CheckNamespace
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public static class BarsManager
	{
		public static int LinesPerBar = 4;

		private static Dictionary<int, ProgressBar> DctThreadIdBars = new();

		public static int GetIndexOfBarLine(int threadId)
		{
			return DctThreadIdBars[threadId].LineIndex;
		}

		public static void AddProgressBar(int threadId)
		{
			lock (DctThreadIdBars)
			{
				if (DctThreadIdBars.TryAdd(threadId, new ProgressBar(threadId, 0, ConsoleWriter.LinesCount)))
					ConsoleWriter.AddLines(LinesPerBar);
				var bar = DctThreadIdBars[threadId];
				ConsoleWriter.SetLine(bar.LineIndex, bar.ToString());
			}
		}

		public static void UpdateBarLineInConsole(int threadId, double progress)
		{
			ProgressBar bar = DctThreadIdBars[threadId];
			bar.Progress = progress;
			ConsoleWriter.SetLine(bar.LineIndex, bar.ToString());
		}
	}
}
