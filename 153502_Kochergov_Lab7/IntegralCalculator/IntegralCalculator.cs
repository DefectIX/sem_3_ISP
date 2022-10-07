using System;
using System.Diagnostics;
using System.Threading;

namespace _IntegralCalculator
{
	public class IntegralCalculator
	{
		public delegate void ProgressUpdateHandler(int threadId, double progress);
		public delegate void ResultHandler(IntegralCalculationData data);

		public event ProgressUpdateHandler ProgressUpdated;
		public event ResultHandler CalculationFinished;

		private static Semaphore _semaphore = new(2, 2);

		private static double F(double x)
		{
			return Math.Sin(x);
		}

		public void CalculateIntegral()
		{
			int threadId = Thread.CurrentThread.ManagedThreadId;

			BarsManager.AddProgressBar(threadId);

			_semaphore.WaitOne();
			Stopwatch sw = new();
			sw.Start();

			double result = 0;
			double start = 0, end = 1;
			double step = 0.00000001;
			double x = start + step / 2;
			long steps = (long)(Math.Abs(end - start) / step);
			for (long i = 0, counter = 0; i < steps; i++, counter++)
			{
				result += F(x) * step;
				x += step;

				for (int j = 0; j < 1e1; j++) // Delay
					start /= 0.999;			  //

				if (counter == (int)1e4)
				{
					ProgressUpdated?.Invoke(threadId, (i + 1.0) / steps);
					counter = 0;
				}
			}

			sw.Stop();
			CalculationFinished?.Invoke(new IntegralCalculationData
			{
				Result = result,
				Elapsed = sw.Elapsed,
				IndexOfBarLine = BarsManager.GetIndexOfBarLine(threadId),
				ThreadId = threadId
			});

			_semaphore.Release();
		}
	}
}
