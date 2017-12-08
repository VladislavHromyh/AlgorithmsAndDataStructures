using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures {
	internal class Stack<T> : IEnumerable<T> {
		private class Node<T> {
			public T Data { get; private set; }
			public Node<T> Next { get; set; }

			public Node(T data) {
				Data = data;
			}
		}

		private Node<T> head;
		private int count;

		public void Push(T data) {
			Node<T> node = new Node<T>(data);
			if (count > 0) {
				node.Next = head;
			}
			head = node;
			count++;
		}

		public T Pop(T data) {
			Node<T> nodeToPop = head;
			head = head.Next;
			count--;
			return nodeToPop.Data;
		}

		public T Peek(T data) {
			return head.Data;
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