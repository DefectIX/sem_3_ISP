using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153502_Kochergov_Lab1.Interfaces;
using _153502_Kochergov_Lab2.Collections;

namespace _153502_Kochergov_Lab1.Collections
{

	class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>, IEnumerator<T>
	{

		private int size;

		public int Count
		{
			get { return size; }
		}



		private Node<T> _first = null;
		private Node<T> _current = null;
		private Node<T> _last = null;

		T IEnumerator<T>.Current => _current.Value;

		object IEnumerator.Current => _current;

		public MyCustomCollection()
		{
			size = 0;
		}

		public T this[int index]
		{
			get
			{
				if (index >= Count)
					throw new IndexOutOfRangeException();
				_current = _first;
				for (int i = 0; i < index; i++)
					Next();
				return _current.Value;
			}
			set
			{
				if (index >= Count)
					throw new IndexOutOfRangeException();
				_current = _first;
				for (int i = 0; i < index; i++)
					Next();
				_current.Value = value;
			}
		}

		public void Add(T item)
		{
			if (_first == null)
			{
				_first = new Node<T>(item);
				_last = _first;
			}
			else
			{
				Node<T> temp = new Node<T>(item);
				_last.Next = temp;
				temp.Prev = _last;
				_last = temp;

			}

			++size;
		}



		public T Current()
		{
			if (_current != null)
				return _current.Value;
			else
			{
				_current = _first;
				return _current.Value;
			}
		}

		public void Next()
		{
			MoveNext();
		}

		public void Remove(T item)
		{
			Reset();
			while (MoveNext())
			{
				if (item.Equals(_current.Value))
				{
					RemoveCurrent();
					Reset();
					return;
				}

			}

			throw new ArgumentException($"The collection does not contain item {item}");
		}

		public T RemoveCurrent()
		{
			T temp = _current.Value;
			--size;
			if (Object.ReferenceEquals(_first, _current))
			{
				_first = _first.Next;
				_first.Prev = null;
				_current = _first;

			}
			else if (Object.ReferenceEquals(_last, _current))
			{
				_last = _last.Prev;
				_last.Next = null;
				_current = _last;
			}
			else
			{
				_current.Prev.Next = _current.Next;
				_current.Next.Prev = _current.Prev;
				_current = _current.Next;
			}

			return temp;
		}

		public void Reset()
		{
			_current = null;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool MoveNext()
		{

			if (_current == null && _first == null)
			{
				return false;
			}
			else if (_current == null)
			{
				_current = _first;
				return true;
			}
			else if (_current.Next != null)
			{
				_current = _current.Next;
				return true;
			}

			return false;
		}

		public void Dispose()
		{
			Reset();
		}
	}
}