using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public class ProgressBar
	{
		private static int _instanceCounter = 0;
		public static int BarLength = 32;

		public ProgressBar(int threadId, double progress)
		{
			InstanceId = _instanceCounter++;
			ThreadId = threadId;
			Progress = progress;
		}

		public int InstanceId { get; }
		public int ThreadId { get; set; }
		public double Progress { get; set; }

		public void Update(double newProgress)
		{
			Progress = newProgress;
			Console.SetCursorPosition(0, InstanceId * 6);
			int currentLength = (int)(Progress * BarLength);
			string bar = new string('=', currentLength);
			int percents = (int)Math.Round(Progress * 100, 0);
			if (percents != 100)
				bar += '>';
			bar += new string(' ', BarLength - bar.Length);
			Console.WriteLine($"Поток {ThreadId} [{bar}] {percents}%");

		}

	}
}
