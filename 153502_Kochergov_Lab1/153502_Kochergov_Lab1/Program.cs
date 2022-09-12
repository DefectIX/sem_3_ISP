using System;
using _153502_Kochergov_Lab1.Collections;

namespace _153502_Kochergov_Lab1
{
	class Program
	{
		static void Main(string[] args)
		{
			MyCustomCollection<int> col = new MyCustomCollection<int>();
			col.Add(1);
			col.Add(2);
			col.Add(3);
			col.Add(4);
			col.Remove(2);
			col.Next();
			col.RemoveCurrent();
			for (int i = 0; i < 2; i++)
			{
				Console.Write(col[i]);
			}
		}
	}
}
