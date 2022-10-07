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

		private Dictionary<int, ProgressBar> bars = new();

		private Thread _printerThread;

		public ConsoleWriter Writer;

		public ProgressBarsManager(ConsoleWriter writer)
		{
			_printerThread = new Thread(UpdateConsole);
			Writer = writer;
		}

		private void UpdateConsole()
		{
			while (true)
			{
				bool allFinished = true;

				foreach (var bar in bars)
				{
					if (bar.Value.IsFinished)
						continue;

					allFinished = false;
					if (bar.Value.Progress == 1.0)
						bar.Value.IsFinished = true;
					Writer.LinesList[bar.Value.InstanceId * LinesForBar] = bar.Value.ToString();
					Writer.UpdateConsole();
				}

				if (allFinished)
					break;

				Thread.Sleep(5);
			}
		}

		public void StartBarsPrinting()
		{
			_printerThread.Start();
		}

		public int GetBarId(int threadId)
		{
			return bars[threadId].InstanceId;
		}

		public void AddProgressBar(int threadId)
		{
			bars.Add(threadId, new ProgressBar(threadId, 0));
			Writer.AddLines(LinesForBar);
		}

		public void UpdateProgressBar(int threadId, double progress)
		{
			bars[threadId].Progress = progress;
		}
	}
}
