using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures  {
	internal class CircularLinkedList<T> : IEnumerable<T> {
		private class Node<T> {
			public T Data { get; set; }
			public Node<T> Next { get; set; }

			public Node(T data) {
				Data = data;
			}
		}

		private Node<T> head;
		private Node<T> tail;
		private int count;
		public int Count { get { return count; } private set { count = value; } }

		public void Add(T data) {
			Node<T> node = new Node<T>(data);
			if (head == null) {
				head = node;
			} else {
				tail.Next = node;
			}
			tail = node;
			tail.Next = head;

			Count++;
		}

		public void Remove(T data) {
			Node<T> current = head;
			Node<T> previous = null;

			while (current != null) {
				if (!current.Data.Equals(data)) {
					previous = current;
					current = current.Next;
					continue;
				}
				
				if (previous == null) {
					head = head.Next;
					tail.Next = head;
					if (head == null) {
						tail = null;
					}

				} else {
					previous.Next = current.Next;
					if (current == tail) {
						tail = previous;
						tail.Next = head;
					}		
				}
				Count--;
				return;
			}
		}

		public void Clear() {
			head = tail = null;
			Count = 0;
		}

		public bool Contains(T data) {
			bool contains = false;
			Node<T> current = head;

			int count = 0;
			while (count < Count) {
				if (!current.Data.Equals(data)) {
					current = current.Next;
					count++;
					continue;
				}
				contains = true;
				break;
			}
			return contains;
		}

		public void AppendFirst(T data) {
			Node<T> node = new Node<T>(data);
			node.Next = head;
			head = node;
			if (Count == 0) {
				tail = head;
			}
			tail.Next = head;
			Count++;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator() {
			Node<T> current = head;
			int count = 0;
			while (count < Count) {
				yield return current.Data;
				current = current.Next;
				count++;
			}
		}
	}
}
