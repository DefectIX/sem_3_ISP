using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace _IntegralCalculator
{
	public class IntegralCalculator
	{
		public static bool ShouldUseSemaphore = true;
		public static bool ShouldExecuteDelay = true;

		public event EventHandler<CalculationFinishedEventArgs> CalculationFinished;

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

				if (ShouldExecuteDelay)               //
					for (int j = 0; j < 5; j++) // Delay
						start /= 1;           //

				if (counter == (int)1e5)
				{
					BarsManager.UpdateBarLine(threadId, (i + 1.0) / steps);
					counter = 0;
				}
			}
			sw.Stop();

			CalculationFinished?.Invoke(this, new CalculationFinishedEventArgs(
				result,
				sw.Elapsed,
				BarsManager.GetIndexOfBarLine(threadId),
				threadId
			));

			if (ShouldUseSemaphore)
				_semaphore.Release();
		}
	}
}
