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
		static void Main(string[] args)
		{
			int threadsNumber = 5;
			ConsoleWriter.StartRefreshCycle();

			IntegralCalculator calculator = new();
			calculator.CalculationFinished += PrintResult;

			List<Thread> threads = new();
			for (int i = 0; i < threadsNumber; i++)
			{
				threads.Add(new Thread(calculator.CalculateIntegral));

				threads.Last().Priority = (i % 2 == 0) ? ThreadPriority.Highest : ThreadPriority.Lowest;
			}
			foreach (var thread in threads)
			{
				thread.Start();
				//Thread.Sleep(10);
			}
			threads.ForEach(thread => thread.Join());
			ConsoleWriter.StopRefreshCycle();
		}

		static void PrintResult(IntegralCalculationData data)
		{
			int lineIndex = data.IndexOfBarLine + 1;
			ConsoleWriter.SetLine(lineIndex, $"Thread with id: {data.ThreadId:D2} finished.");
			ConsoleWriter.SetLine(lineIndex + 1, $"Result: {data.Result}, elapsed time: {data.Elapsed}");
		}
	}
}
