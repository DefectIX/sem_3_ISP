using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using _IntegralCalculator;

namespace _153502_Kochergov_Lab7
{
	class Program
	{
		private static ProgressBarsManager _barsManager;
		private static ConsoleWriter _writer;

		static void Main(string[] args)
		{
			_writer = new ConsoleWriter();
			_barsManager = new ProgressBarsManager(_writer);

			IntegralCalculator calculator = new();

			Thread thread1 = new Thread(calculator.CalculateIntegral);
			Thread thread2 = new Thread(calculator.CalculateIntegral);

			calculator.ProgressUpdated += _barsManager.UpdateProgressBar;
			calculator.CalculationFinished += PrintResult;

			_barsManager.AddProgressBar(thread1.ManagedThreadId);
			_barsManager.AddProgressBar(thread2.ManagedThreadId);

			_barsManager.StartBarsPrinting();

			thread1.Start();
			//Thread.Sleep(1000);
			thread2.Start();
			//Thread.Sleep(20000);
		}

		static void PrintResult(double result, Stopwatch elapsedTime, int threadId)
		{
			_barsManager.UpdateProgressBar(threadId, 1.0);
			int line_number = _barsManager.GetBarId(threadId) * ProgressBarsManager.LinesForBar + 1;
			_writer.LinesList[line_number] = $"Thread with id: {threadId} finished.";
			_writer.LinesList[line_number + 1] = $"Result: {result}, elapsed time: {elapsedTime.Elapsed}";
			_writer.UpdateConsole();
		}
	}
}
