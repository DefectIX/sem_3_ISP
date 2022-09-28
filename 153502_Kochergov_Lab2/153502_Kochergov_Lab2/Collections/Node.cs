using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab2.Collections
{
	class Node<T>
	{
		public T Value;
		public Node<T> Next = null;
		public Node<T> Prev = null;
		public Node(T value)
		{
			this.Value = value;
		}
		public Node() { }

	}
}
