using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public class ProgressBar
	{
		public static int BarLength = 50;

		public ProgressBar(int threadId, double progress, int lineIndex)
		{
			ThreadId = threadId;
			Progress = progress;
			LineIndex = lineIndex;
		}

		public int ThreadId { get; set; }
		public double Progress { get; set; }
		public int LineIndex { get; set; }

		public override string ToString()
		{
			int currentLength = (int)(Progress * BarLength);
			string bar = new string('=', currentLength);
			int percents = (int)Math.Round(Progress * 100, 0);
			if (percents != 100)
				bar += '>';
			bar += new string(' ', BarLength - bar.Length);
			return $"Thread {ThreadId:D2} [{bar}] {percents}%";
		}
	}
}
