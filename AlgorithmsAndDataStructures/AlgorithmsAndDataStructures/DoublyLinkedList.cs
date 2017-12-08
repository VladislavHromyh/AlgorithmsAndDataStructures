using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures  {
	internal class DoublyLinkedList<T> : IEnumerable<T> {
		private class Node<T> {
			public T Data { get; set; }
			public Node<T> Previous { get; set; }
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
				node.Previous = tail;
			}
			tail = node;

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
					if (head == null) {
						tail = null;
					}

				} else {
					previous.Next = current.Next;
					current.Previous = previous;
					if (current == tail) {
						tail = previous;
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

			while (current != null) {
				if (!current.Data.Equals(data)) {
					current = current.Next;
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
			} else {
				head.Next.Previous = head;
			}
			Count++;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator() {
			Node<T> current = head;
			while (current != null) {
				yield return current.Data;
				current = current.Next;
			}
		}
	}
}
