using System;

namespace _IntegralCalculator
{
	public class CalculationFinishedEventArgs : EventArgs
	{
		public CalculationFinishedEventArgs(double result, TimeSpan elapsed, int indexOfBarLine, int threadId)
		{
			Result = result;
			Elapsed = elapsed;
			IndexOfBarLine = indexOfBarLine;
			ThreadId = threadId;
		}

		public double Result { get; }
		public TimeSpan Elapsed { get; }
		public int IndexOfBarLine { get;}
		public int ThreadId { get;  }
	}
}
