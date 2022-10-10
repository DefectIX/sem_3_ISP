using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace _IntegralCalculator
{
	public class IntegralCalculator
	{
		public static bool ShouldUseSemaphore = true;
		public static bool ShouldAddDelay = true;

		public delegate void ResultHandler(IntegralCalculationData data);

		public event ResultHandler CalculationFinished;

		private static Semaphore _semaphore = new(2, 2);

		public void CalculateIntegral()
		{
			int threadId = Thread.CurrentThread.ManagedThreadId;

			BarsManager.AddProgressBar(threadId);

			if (ShouldUseSemaphore)
				_semaphore.WaitOne();

			Stopwatch sw = new();
			sw.Start();

			double result = 0;
			double start = 0, end = 1;
			double step = 0.00000001;
			double x = start + step / 2;
			long steps = (long)(Math.Abs(end - start) / step);
			for (long i = 0, counter = 1; i < steps; i++, counter++)
			{
				result += Math.Sin(x) * step;
				x += step;

				if (ShouldAddDelay)				  //
					for (int j = 0; j < 1e1; j++) // Delay
						start /= 0.999;           //

				if (counter == (int)1e5)
				{
					BarsManager.UpdateBarLine(threadId, (i + 1.0) / steps);
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

			if (ShouldUseSemaphore)
				_semaphore.Release();
		}
	}
}
