using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kochergov_Lab1.Collections
{
	class MyEnumerator<T> : IEnumerator<T>
	{
		public MyEnumerator(Node<T> begin)
		{
			Begin = begin;
			CurrNode = null;
		}

		private Node<T> Begin { get; set; }
		private Node<T> CurrNode { get; set; }

		public T Current
		{
			get
			{
				return CurrNode.Data;
			}
			set
			{
				CurrNode.Data = value;
			}
		}

		object IEnumerator.Current => Current;

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (CurrNode == null)
			{
				if (Begin == null)
				{
					return false;
				}
				CurrNode = Begin;
				return true;
			}
			if (CurrNode.Next != null)
			{
				CurrNode = CurrNode.Next;
				return true;
			}

			return false;
		}

		public void Reset()
		{
			CurrNode = null;
		}
	}
}
