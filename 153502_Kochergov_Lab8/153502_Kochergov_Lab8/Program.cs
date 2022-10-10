using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab8
{
	class Program
	{
		static async Task Main(string[] args)
		{
			//var task1 = PrintDoubleAsync(1.5);
			//task1.Wait();
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

				//if (ShouldAddDelay)               //
					for (int j = 0; j < 1e1; j++) // Delay
						start /= 0.999;           //

			}
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
		}

		static int PrintDouble(double n, int q)
		{
			return (int)n * q;
		}

		static async Task<int> PrintDoubleAsync(double d)
		{
			Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
			int temp = await Task.Run(() => PrintDouble(d, 2));
			Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
			int temp2 = await Task.Run(() => PrintDouble(d, 2));
			Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
			return temp+temp2;
		}
	}
}
