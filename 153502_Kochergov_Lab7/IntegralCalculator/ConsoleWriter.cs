using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IntegralCalculator
{
	public class ConsoleWriter
	{
		public ConcurrentDictionary<int, string> LinesList = new();

		private object block = new();

		public void UpdateConsole()
		{
			//lock (block)
			//{
			Console.SetCursorPosition(0, 0);
			string temp = string.Join('\n', LinesList.Select(x => x.Value));
			Console.Write(temp);
			//}
		}

		public void AddLines(int number)
		{
			int offset = LinesList.Count;
			for (int i = 0; i < number; i++)
			{
				LinesList.TryAdd(i + offset, "");
			}
		}
	}
}
