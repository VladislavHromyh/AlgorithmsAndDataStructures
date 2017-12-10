using System.Collections;
using System.Collections.Generic;

namespace DataStructures  {
	internal class CircularLinkedList<T> : IEnumerable<T> {
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
			tail.Next = head;

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
				count--;
				return;
			}
		}

		public void Clear() {
			head = tail = null;
			count = 0;
		}

		public bool Contains(T data) {
			Node<T> currentNode = head;
			int counter = 0;
			while (counter < count) {
				if (!currentNode.Data.Equals(data)) {
					currentNode = currentNode.Next;
					counter++;
					continue;
				}
				return true;
			}
			return false;
		}

		public void AppendFirst(T data) {
			Node<T> node = new Node<T>(data);
			node.Next = head;
			head = node;
			if (count == 0) {
				tail = head;
			}
			tail.Next = head;
			count++;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator() {
			Node<T> current = head;
			int counter = 0;
			while (counter < count) {
				yield return current.Data;
				current = current.Next;
				counter++;
			}
		}

		public bool IsEmpty() {
			return count == 0;
		}
	}
}
