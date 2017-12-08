using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures  {
	internal class SinglyLinkedList<T> : IEnumerable<T> {
		private class Node<T> {
			public T Data { get; private set; }
			public Node<T> Next { get; set; }

			public Node(T data) {
				Data = data;
			}
		}

		private Node<T> head;
		private Node<T> tail;
		private int count;

		public void Add(T data) {
			Node<T> node = new Node<T>(data);
			if (head == null) {
				head = node;
			} else {
				tail.Next = node;
			}
			tail = node;

			count++;
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
					if (current == tail) {
						tail = previous;
					}		
				}
				count--;
				return;
			}
		}

		public void Clear() {
			head = tail = null;
			count = 0;
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
			if (count == 0) {
				tail = head;
			}
			count++;
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

		public bool IsEmpty() {
			return count == 0;
		}
	}
}
