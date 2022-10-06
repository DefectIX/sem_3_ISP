﻿using System;
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

			barsManager.AddProgressBar(thread1.ManagedThreadId);
			calculator.ProgressUpdated += barsManager.UpdateProgressBar;
			calculator2.ProgressUpdated += barsManager.UpdateProgressBar;


			Thread thread2 = new Thread(calculator2.CalculateIntegral);
			barsManager.AddProgressBar(thread2.ManagedThreadId);

			thread1.Start();
			thread2.Start();

			Console.WriteLine();
		}

		static void PrintResult(double result, Stopwatch elapsedTime, int threadId)
		{
			barsManager.UpdateProgressBar(threadId, 1.0);
			Console.WriteLine($"Thread with id: {threadId} finished.\n" +
							  $"Result: {result}, elapsed time: {elapsedTime.Elapsed}");
		}

		static void FinishProgressBar(double result, Stopwatch elapsedTime, int threadId)
		{
			barsManager.UpdateProgressBar(threadId, 1.0);
		}
	}
}