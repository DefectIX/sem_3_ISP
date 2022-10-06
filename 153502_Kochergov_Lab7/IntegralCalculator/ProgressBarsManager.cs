using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public class ProgressBarsManager
	{
		public static int BarLength = 32;

		private Dictionary<int, double> progresses = new();

		public void AddProgressBar(int id)
		{
			progresses.Add(id, 0);
			UpdateBars();
		}

		public void UpdateProgressBar(int id, double progress)
		{
			progresses[id] = progress;
			UpdateBars();
		}

		public void UpdateBars()
		{
			int i = 0;
			foreach (var prog in progresses)
			{
				PrintProgressBar(prog.Key, prog.Value, i++);
			}
		}

		public void PrintProgressBar(int id, double progress, int i)
		{
			Console.SetCursorPosition(0, i*6);
			int currentLength = (int)(progress * BarLength);
			string bar = new string('=', currentLength);
			int percents = (int)Math.Round(progress * 100, 0);
			if (percents != 100)
				bar += '>';
			bar += new string(' ', BarLength - bar.Length);
			Console.WriteLine($"Поток {id} [{bar}] {percents}%");
		}
	}
}
