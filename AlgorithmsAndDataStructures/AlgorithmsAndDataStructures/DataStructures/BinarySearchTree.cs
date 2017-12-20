using System;
using System.Collections.Generic;

namespace DataStructures {
	internal class BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey> {
		public class BSTNode<TKey, TValue> {
			public BSTNode<TKey, TValue> Left;
			public BSTNode<TKey, TValue> Right;
			public TKey Key { get; private set; }
			public TValue Value { get; private set; }
			public BSTNode<TKey, TValue> Parent { get; private set; }

			public BSTNode(TKey key, TValue value, BSTNode<TKey, TValue> parent) {
				Key = key;
				Value = value;
				Parent = parent;
			}
		}

		private BSTNode<TKey, TValue> root;

		private BSTNode<TKey, TValue> Find(TKey key, BSTNode<TKey, TValue> node) {
			if (node == null) {
				return null;
			}

			int compareResult = key.CompareTo(node.Key);
			if (compareResult > 0) {
				return Find(key, node.Right);
			} else if (compareResult < 0) {
				return Find(key, node.Left);
			} else {
				return node;
			}
		}

		private void Insert(TKey key, TValue value, BSTNode<TKey, TValue> node, BSTNode<TKey, TValue> parent) {
			if (node == null) {
				node = new BSTNode<TKey, TValue>(key, value, parent);
				return;
			}

			int compareResult = key.CompareTo(node.Key);
			if (compareResult > 0) {
				Insert(key, value, node.Right, node);
			} else if (compareResult < 0) {
				Insert(key, value, node.Left, node);
			} else {
				node = new BSTNode<TKey, TValue>(key, value, parent);
			}
		}

		private void Remove(BSTNode<TKey, TValue> node, TKey key, BSTNode<TKey, TValue> parent) {
			if (node == null) {
				return;
			}
			int compareResult = key.CompareTo(node.Key);
			if (compareResult > 0) {
				Remove(node.Right, key, node);
			} else if (compareResult < 0) {
				Remove(node.Left, key, node);
			} else {
				BSTNode<TKey, TValue> leftChild = node.Left;
				BSTNode<TKey, TValue> rightChild = node.Right;

				if (leftChild == null && rightChild == null) {
					if (parent != null) {
						if (parent.Left == node) {
							parent.Left = null;
						} else {
							parent.Right = null;
						}
					}
				} else if (leftChild == null) {

				} else if (rightChild == null) {

				} else {

				}
			}
		}
	}
}