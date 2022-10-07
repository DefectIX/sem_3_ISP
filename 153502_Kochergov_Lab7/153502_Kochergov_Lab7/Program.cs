using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using _IntegralCalculator;

namespace _153502_Kochergov_Lab7
{
	class Program
	{
		private static ProgressBarsManager _barsManager;

		static void Main(string[] args)
		{
			_barsManager = new ProgressBarsManager();

			IntegralCalculator calculator = new();

			calculator.ProgressUpdated += _barsManager.UpdateProgressBar;
			calculator.CalculationFinished += PrintResult;

			List<Thread> threads = new();

			for (int i = 0; i < 10; i++)
			{
				threads.Add(new Thread(calculator.CalculateIntegral));
				_barsManager.AddProgressBar(threads.Last().ManagedThreadId);
				if (i % 2 == 0)
					threads.Last().Priority = ThreadPriority.Highest;
				else
					threads.Last().Priority = ThreadPriority.Lowest;
			}

			//Thread thread1 = new Thread(calculator.CalculateIntegral);
			//Thread thread2 = new Thread(calculator.CalculateIntegral);
			//Thread thread3 = new Thread(calculator.CalculateIntegral);

			//thread1.Priority = ThreadPriority.Lowest;
			//thread2.Priority = ThreadPriority.Highest;

			//_barsManager.AddProgressBar(thread1.ManagedThreadId);
			//_barsManager.AddProgressBar(thread2.ManagedThreadId);
			//_barsManager.AddProgressBar(thread3.ManagedThreadId);

			_barsManager.StartBarsPrinting();
			threads.ForEach(thread => thread.Start());
			//thread1.Start();
			//Thread.Sleep(1000);
			//thread2.Start();
			//thread3.Start();
			//Thread.Sleep(20000);
		}

		static void PrintResult(double result, Stopwatch elapsedTime, int threadId)
		{
			_barsManager.UpdateProgressBar(threadId, 1.0);
			int lineNumber = _barsManager.GetBarId(threadId) * ProgressBarsManager.LinesForBar + 1;
			ConsoleWriter.SetLine(lineNumber, $"Thread with id: {threadId} finished.");
			ConsoleWriter.SetLine(lineNumber + 1, $"Result: {result}, elapsed time: {elapsedTime.Elapsed}");
			ConsoleWriter.UpdateConsole();
		}
	}
}
