using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Kochergov_Lab1.Interfaces;

namespace _153502_Kochergov_Lab1.Collections
{
	class MyCustomCollection<T> : ICustomCollection<T>
	{
		public MyCustomCollection()
		{
			Count = 0;
			_begin = null;
			_curr = null;
		}

		private Node<T> _begin;
		private Node<T> _curr;

		public T this[int index]
		{
			get
			{
				if (index >= Count)
					throw new IndexOutOfRangeException();
				Node<T> it = _begin;
				for (int i = 0; i != index; i++)
					it = it.Next;

				return it.Data;
			}
			set
			{
				if (index >= Count)
					throw new IndexOutOfRangeException();
				Node<T> it = _begin;
				for (int i = 0; i != index; i++)
					it = it.Next;

				it.Data = value;
			}
		}

		public int Count { get; private set; }

		public void Add(T item)
		{
			Node<T> newNode = new Node<T>(item);
			if (Count == 0)
			{
				_begin = newNode;
				_curr = newNode;
				Count++;
				return;
			}
			if (Count == 1)
			{
				_begin.Next = newNode;
				Count++;
				return;
			}

			Node<T> it = _begin;
			while (it.Next.Next != null)
				it = it.Next;
			it.Next.Next = newNode;
			Count++;
		}

		public void Remove(T item)
		{
			if (Count == 0)
				return;
			if (Count == 1)
			{
				Count = 0;
				_begin = null;
				_curr = null;
				return;
			}

			if (_begin.Data.Equals(item))
			{
				if (_curr == _begin)
					_curr = _begin.Next;
				_begin = _begin.Next;
				Count--;
				return;
			}

			if (_begin.Next.Data.Equals(item))
			{
				if (_curr == _begin.Next)
					_curr = _begin;
				_begin.Next = _begin.Next.Next;
				Count--;
				return;
			}

			Node<T> it = _begin;
			while (it.Next.Next != null)
			{
				if (it.Next.Next.Data.Equals(item))
				{
					it.Next = it.Next.Next;
					break;
				}
				it = it.Next;
			}
		}

		public bool MoveNext()
		{
			if (_curr == null)
			{
				if (_begin == null)
				{
					return false;
				}
				_curr = _begin;
				return true;
			}
			if (_curr.Next != null)
			{
				_curr = _curr.Next;
				return true;
			}
			return false;
		}

		public void Next()
		{
			MoveNext();
		}

		public T Current
		{
			get
			{
				if (_curr == null)
					throw new Exception("Cursor out of range");
				return _curr.Data;
			}
			set
			{
				if (_curr == null)
					throw new Exception("Cursor out of range");
				_curr.Data = value;
			}
		}

		object IEnumerator.Current => _curr.Data;
		
		T ICustomCollection<T>.Current()
		{
			return Current;
		}

		public T RemoveCurrent()
		{
			if (Count == 0)
				return default;
			T data;
			if (_curr == _begin)
			{
				data = _curr.Data;
				Count = 0;
				_begin = null;
				_curr = null;
				return data;
			}

			Node<T> it = _begin;
			while (it.Next != _curr)
				it = it.Next;
			data = it.Next.Data;
			it.Next = it.Next.Next;
			Count--;
			return data;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Reset()
		{
			_curr = null;
		}

		public void Dispose()
		{
			Reset();
		}
	}
}
