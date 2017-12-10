using System.Collections;
using System.Collections.Generic;

namespace DataStructures {

	internal class Queue<T> : IEnumerable<T>{
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

		public void Enqueue(T data) {
			Node<T> node = new Node<T>(data);
			if (count == 0) {
				head = tail = node;
			} else {
				tail.Next = node;
			}
			tail = node;
			count++;
		}

		public T Dequeue() {
			Node<T> nodeToDequeue = head;
			head = head.Next;
			count--;
			return nodeToDequeue.Data;
		}

		public T First() {
			return head.Data;
		}

		public T Last() {
			return tail.Data;
		}

		public bool IsEmpty() {
			return count == 0;
		}

		public bool Contains(T data) {
			Node<T> currentNode = head;
			while (currentNode != null) {
				if (currentNode.Data.Equals(data)) {
					return true;
				}
				currentNode = currentNode.Next;
			}

			return false;
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