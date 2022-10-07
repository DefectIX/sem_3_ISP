using System;

namespace _IntegralCalculator
{
	public struct IntegralCalculationData
	{
		public double Result { get; set; }
		public TimeSpan Elapsed { get; set; }
		public int IndexOfBarLine { get; set; }
		public int ThreadId { get; set; }
	}
}
