using System;

namespace DataStructures {
	internal class BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey> {
		public class BSTNode<TKey, TValue> {
			public BSTNode<TKey, TValue> Left;
			public BSTNode<TKey, TValue> Right;
			public TKey Key { get; set; }
			public TValue Value { get; set; }
			public BSTNode<TKey, TValue> Parent { get; set; }

			public BSTNode(TKey key, TValue value, BSTNode<TKey, TValue> parent) {
				Key = key;
				Value = value;
				Parent = parent;
			}

			public override string ToString() {
				string output = string.Format("Key: {0}; Value: {1}", Key, Value);
				if (Parent != null) {
					output += "; Parent: " + Parent.Value;
				}
				if (Left != null) {
					output += "; Left child: " + Left.Value;
				}
				if (Right != null) {
					output += "; Right child: " + Right.Value;
				}
				return output;
			}
		}

		public BSTNode<TKey, TValue> root;

		private BSTNode<TKey, TValue> Find(TKey key, BSTNode<TKey, TValue> parent) {
			if (parent == null) {
				return null;
			}

			int compareResult = key.CompareTo(parent.Key);
			if (compareResult > 0) {
				return Find(key, parent.Right);
			} else if (compareResult < 0) {
				return Find(key, parent.Left);
			} else {
				return parent;
			}
		}

		private void Insert(TKey key, TValue value, BSTNode<TKey, TValue> parent) {
			if (parent == null) {
				root = new BSTNode<TKey, TValue>(key, value, parent);
				return;
			}

			int compareResult = key.CompareTo(parent.Key);
			if (compareResult > 0) {
				if (parent.Right == null) {
					parent.Right = new BSTNode<TKey, TValue>(key, value, parent);
				} else {
					Insert(key, value, parent.Right);
				}		
			} else if (compareResult < 0) {
				if (parent.Left == null) {
					parent.Left = new BSTNode<TKey, TValue>(key, value, parent);
				} else {
					Insert(key, value, parent.Left);
				}
				
			}
		}

		private void Remove(TKey key, BSTNode<TKey, TValue> parent) {
			BSTNode<TKey, TValue> node = Find(key, parent);
			if (node == null) {
				return;
			}

			int compareResult = key.CompareTo(node.Key);
			if (compareResult > 0) {
				Remove(key, node);
			} else if (compareResult < 0) {
				Remove(key, node);
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
						node = null;
					}
				} else if (leftChild == null) {
					node = rightChild;
					node.Right = null;
				} else if (rightChild == null) {
					node = leftChild;
					node.Left = null;
				} else {
					if (rightChild.Left == null) {
						node = rightChild;
					} else {
						BSTNode<TKey, TValue> mostleftChild = rightChild;
						while (true) {
							if (mostleftChild.Left != null) {					
								mostleftChild = mostleftChild.Left;
							} else {
								break;
							}
						}
						if (node.Parent.Right == node) {
							node.Parent.Right = mostleftChild;
						} else if (node.Parent.Left == node) {
							node.Parent.Left = mostleftChild;
						}
						node.Left.Parent = mostleftChild;
						mostleftChild.Right = node.Right;
						node = null;
					}
				}
			}
		}

		public void Add(TKey key, TValue value) {
			Insert(key, value, root);
		}

		public void Remove(TKey key) {
			Remove(key, root);
		}

		private void InfixTraverse(BSTNode<TKey, TValue> node, Action<BSTNode<TKey, TValue>> action) {
			if (node == null) {
				return;
			}
			InfixTraverse(node.Left, action);
			action(node);
			InfixTraverse(node.Right, action);
		}

		public void InfixTraverse(Action<BSTNode<TKey, TValue>> action) {
			InfixTraverse(root, action);
		}

		public void PrefixTraverse(Action<BSTNode<TKey, TValue>> action) {
			PrefixTraverse(root, action);
		}

		private void PrefixTraverse(BSTNode<TKey, TValue> node, Action<BSTNode<TKey, TValue>> action) {
			if (node == null) {
				return;
			}
			action(node);
			PrefixTraverse(node.Left, action);
			PrefixTraverse(node.Right, action);
		}

		public void PostfixTraverse(Action<BSTNode<TKey, TValue>> action) {
			PostfixTraverse(root, action);
		}

		private void PostfixTraverse(BSTNode<TKey, TValue> node, Action<BSTNode<TKey, TValue>> action) {
			if (node == null) {
				return;
			}
			PostfixTraverse(node.Left, action);
			PostfixTraverse(node.Right, action);
			action(node);
		}
	}
}