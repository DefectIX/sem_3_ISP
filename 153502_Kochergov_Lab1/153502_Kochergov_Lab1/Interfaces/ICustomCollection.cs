using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab1.Interfaces
{
	interface ICustomCollection<T>
	{
		T this[int index] { get; set; }
		int Count { get; }
		void Reset();
		void Next();
		void Add(T item);
		void Remove(T item);
		T Current();
		T RemoveCurrent();
	}
}
