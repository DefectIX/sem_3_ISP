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
			Id = _instanceCounter++;
			ThreadId = threadId;
			Progress = progress;
			IsFinished = false;
		}

		public int Id { get; }
		public int ThreadId { get; set; }
		public double Progress { get; set; }
		public bool IsFinished { get; set; }

		public override string ToString()
		{
			int currentLength = (int)(Progress * BarLength);
			string bar = new string('=', currentLength);
			int percents = (int)Math.Round(Progress * 100, 0);
			if (percents != 100)
				bar += '>';
			bar += new string(' ', BarLength - bar.Length);
			return $"Thread {ThreadId} [{bar}] {percents}%";
		}
	}
}
