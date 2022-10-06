using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public class ProgressBarsManager
	{
		public static object _lockObject = new();

		private ConcurrentDictionary<int, ProgressBar> progresses = new();

		public int GetBarId(int threadId)
		{
			return progresses[threadId].InstanceId;
		}

		public void AddProgressBar(int threadId)
		{
			progresses.TryAdd(threadId, new ProgressBar(threadId, 0));
			UpdateAllBars(0);
		}

		public void UpdateProgressBar(int threadId, double progress)
		{
			progresses[threadId].Progress = progress;
			lock (_lockObject)
			{
				UpdateAllBars();
			}
		}

		public void UpdateAllBars()
		{
			foreach (var prog in progresses)
				prog.Value.Update();

		}

		public void UpdateAllBars(double progress)
		{
			foreach (var prog in progresses)
			{
				prog.Value.Progress = progress;
				prog.Value.Update();
			}
		}
	}
}
