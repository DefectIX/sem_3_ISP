using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public class ProgressBarsManager
	{
		private Dictionary<int, ProgressBar> progresses = new();

		public void AddProgressBar(int threadId)
		{
			progresses.Add(threadId, new ProgressBar(threadId, 0));
			UpdateAllBars(0);
		}

		public void UpdateProgressBar(int threadId, double progress)
		{
			progresses[threadId].Update(progress);
		}

		public void UpdateAllBars(double progress)
		{
			foreach (var prog in progresses)
			{
				prog.Value.Update(progress);
			}
		}
	}
}
