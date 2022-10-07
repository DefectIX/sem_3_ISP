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

			ConsoleWriter.StartConsoleRefreshing();


			IntegralCalculator calculator = new();
			calculator.ProgressUpdated += BarsManager.UpdateBarLineInConsole;
			calculator.CalculationFinished += PrintResult;

			List<Thread> threads = new();
			for (int i = 0; i < threadsNumber; i++)
			{
				threads.Add(new Thread(calculator.CalculateIntegral));
				
				if (i % 2 == 0)
					threads.Last().Priority = ThreadPriority.Highest;
				else
					threads.Last().Priority = ThreadPriority.Lowest;
			}
			foreach (var thread in threads)
			{
				thread.Start();
				Thread.Sleep(10);
			}
			threads.ForEach(thread => thread.Join());
			
			ConsoleWriter.StopConsoleRefreshing();
		}

		static void PrintResult(IntegralCalculationData data)
		{
			BarsManager.UpdateBarLineInConsole(data.ThreadId, 1.0);
			int lineIndex = data.IndexOfBarLine + 1;
			ConsoleWriter.SetLine(lineIndex, $"Thread with id: {data.ThreadId:D2} finished.");
			ConsoleWriter.SetLine(lineIndex + 1, $"Result: {data.Result}, elapsed time: {data.Elapsed}");
		}
	}
}
