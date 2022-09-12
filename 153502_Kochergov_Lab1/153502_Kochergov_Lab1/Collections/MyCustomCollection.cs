﻿using System;
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
		private Node<T> Curr { get; set; }
		private Node<T> Begin { get; set; }

		public T this[int index]
		{
			get
			{
				if (index >= Count)
					throw new IndexOutOfRangeException();
				Node<T> it = Begin;
				for (int i = 0; i != index; i++)
					it = it.Next;

				return it.Data;
			}
			set
			{
				if (index >= Count)
					throw new IndexOutOfRangeException();
				Node<T> it = Begin;
				for (int i = 0; i != index; i++)
					it = it.Next;

				it.Data = value;
			}
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
				Curr = newNode;
				Count++;
				return;
			}
			if (Count == 1)
			{
				Begin.Next = newNode;
				Count++;
				return;
			}

			Node<T> it = Begin;
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
				Begin = null;
				Curr = null;
				return;
			}

			if (Begin.Data.Equals(item))
			{
				if (Curr == Begin)
					Curr = Begin.Next;
				Begin = Begin.Next;
				Count--;
				return;
			}

			if (Begin.Next.Data.Equals(item))
			{
				if (Curr == Begin.Next)
					Curr = Begin;
				Begin.Next = Begin.Next.Next;
				Count--;
				return;
			}

			Node<T> it = Begin;
			while (it.Next.Next != null)
			{
				if (it.Next.Next.Data.Equals(item))
				{
					it.Next = it.Next.Next;
					break;
				}
				it = it.Next;
			}

			if (it.Next.Next == null)
				return;
		}

		public T Current()
		{
			if (Count == 0)
				throw new IndexOutOfRangeException();
			return Curr.Data;
		}

		public T RemoveCurrent()
		{
			if (Count == 0)
				return default;
			T data;
			if (Curr == Begin)
			{
				data = Curr.Data;
				Count = 0;
				Begin = null;
				Curr = null;
				return data;
			}

			Node<T> it = Begin;
			while (it.Next != Curr)
				it = it.Next;
			data = it.Next.Data;
			it.Next = it.Next.Next;
			Count--;
			return data;
		}
	}
}
