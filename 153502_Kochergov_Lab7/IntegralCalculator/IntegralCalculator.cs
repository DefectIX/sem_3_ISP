﻿using System;
using System.Diagnostics;
using System.Threading;

namespace _IntegralCalculator
{
	public class IntegralCalculator
	{
		public delegate void ProgressUpdateHandler(int threadId, double progress);
		public delegate void ResultHandler(double result, Stopwatch elapsedTime, int threadId);

		public event ProgressUpdateHandler ProgressUpdated;
		public event ResultHandler CalculationFinished;

		private static double F(double x)
		{
			return Math.Sin(x);
		}

		public void CalculateIntegral()
		{
			Stopwatch sw = new();
			sw.Start();

			double result = 0;
			double start = 0, end = 1;
			double step = 0.00000001;
			double x = start + step / 2;
			long steps = (long)(Math.Abs(end - start) / step);
			int counter = 0;
			for (long i = 0; i < steps; i++, counter++)
			{
				result += F(x) * step;
				x += step;
				if (counter == 1e6)
				{
					ProgressUpdated?.Invoke(Thread.CurrentThread.ManagedThreadId, (i + 1.0) / steps);
					counter = 0;
				}
			}	

			sw.Stop();
			CalculationFinished?.Invoke(result, sw, Thread.CurrentThread.ManagedThreadId);
		}
	}
}
