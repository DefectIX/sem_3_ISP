using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Kochergov_Lab1.Interfaces;

namespace _153502_Kochergov_Lab1.Collections
{
	class MyCustomCollection<T> : ICustomCollection<T>
	{
		private Node<T> Curr { get; set; }
		private Node<T> Begin { get; set; }

		public T this[int index]
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public int Count { get; private set; } = 0;

		public void Reset()
		{
			Curr = Begin;
		}

		public void Next()
		{
			if (Curr.Next != null)
				Curr = Curr.Next;
		}

		public void Add(T item)
		{
			Node<T> newNode = new Node<T>(item);
			if (Count == 0)
			{
				Begin = newNode;
			}
			if (Curr.Next != null)
			{
				newNode.Next = Curr.Next;
			}
			Curr.Next = newNode;
			Count++;
		}

		public void Remove(T item)
		{
			throw new NotImplementedException();
		}

		public T Current()
		{
			throw new NotImplementedException();
		}

		public T RemoveCurrent()
		{
			throw new NotImplementedException();
		}
	}
}
