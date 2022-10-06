using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using _IntegralCalculator;

namespace _153502_Kochergov_Lab7
{
	class Program
	{
		private static ProgressBarsManager barsManager = new();

		static void Main(string[] args)
		{
			IntegralCalculator calculator = new();
			IntegralCalculator calculator2 = new();

			calculator.CalculationFinished += PrintResult;
			calculator2.CalculationFinished += PrintResult;

			Thread thread1 = new Thread(calculator.CalculateIntegral);
			Thread thread2 = new Thread(calculator2.CalculateIntegral);

			calculator.ProgressUpdated += barsManager.UpdateProgressBar;
			calculator2.ProgressUpdated += barsManager.UpdateProgressBar;



			barsManager.AddProgressBar(thread1.ManagedThreadId);
			barsManager.AddProgressBar(thread2.ManagedThreadId);

			thread1.Start();
			//Thread.Sleep(20);
			thread2.Start();

			Console.WriteLine();
		}

		static void PrintResult(double result, Stopwatch elapsedTime, int threadId)
		{
			lock (ProgressBarsManager._lockObject)
			{
				barsManager.UpdateProgressBar(threadId, 1.0);
				Console.SetCursorPosition(0, barsManager.GetBarId(threadId) * 6+1);
				Console.WriteLine($"Thread with id: {threadId} finished.\n" +
				                  $"Result: {result}, elapsed time: {elapsedTime.Elapsed}");
			}
		}
	}
}
