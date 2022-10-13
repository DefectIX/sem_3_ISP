using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamServiceLibrary
{
	public class ProgressBar
	{
		public static int BarLength = 50;

		public ProgressBar(double progress, int lineIndex, string label = "")
		{
			Progress = progress;
			LineIndex = lineIndex;
			Label = label;
		}

		public double Progress { get; set; }
		public int LineIndex { get; set; }
		public string Label { get; set; }

		public override string ToString()
		{
			int currentLength = (int)(Progress * BarLength);
			string bar = new string('=', currentLength);
			int percents = (int)Math.Round(Progress * 100, 0);
			if (percents != 100)
				bar += '>';
			bar += new string(' ', BarLength - bar.Length);
			return $"{Label}[{bar}] {percents}%";
		}
	}
}
