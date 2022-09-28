using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab2.Collections
{
	class Node<T>
	{
		public T value;
		public Node<T> next = null;
		public Node<T> prev = null;
		public Node(T value)
		{
			this.value = value;
		}
		public Node() { }

	}
}
