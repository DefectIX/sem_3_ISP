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
	public class ProgressBarsManager
	{
		public static int LinesForBar = 5;

		private readonly Dictionary<int, ProgressBar> _dctThreadIdBars;

		private readonly Thread _printerThread;

		public ProgressBarsManager()
		{
			_printerThread = new Thread(UpdateConsole);
			_dctThreadIdBars = new Dictionary<int, ProgressBar>();
		}

		private void UpdateConsole()
		{
			while (true)
			{
				bool allFinished = true;

				foreach (var pair  in _dctThreadIdBars)
				{
					ProgressBar bar = pair.Value;
					if (bar.IsFinished)
						continue;
					allFinished = false;
					if (bar.Progress == 1.0)
						bar.IsFinished = true;
					int lineNumber = bar.Id * LinesForBar;
					ConsoleWriter.SetLine(lineNumber, bar.ToString());
					ConsoleWriter.UpdateConsole();
				}

				if (allFinished)
					break;

				//Thread.Sleep(100);
			}
		}

		public void StartBarsPrinting()
		{
			_printerThread.Start();
		}

		public int GetBarId(int threadId)
		{
			return _dctThreadIdBars[threadId].Id;
		}

		public void AddProgressBar(int threadId)
		{
			_dctThreadIdBars.Add(threadId, new ProgressBar(threadId, 0));
			ConsoleWriter.AddLines(LinesForBar);
		}

		public void UpdateProgressBar(int threadId, double progress)
		{
			_dctThreadIdBars[threadId].Progress = progress;
		}
	}
}
