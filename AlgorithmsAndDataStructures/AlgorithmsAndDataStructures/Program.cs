using System;
using DataStructures;

internal class Program {
	private static void Main(string[] args) {
		BinarySearchTree<int, int> bstTree = new BinarySearchTree<int, int>();
		bstTree.Add(10, 1010);
		bstTree.Add(15, 1515);
		bstTree.Add(9, 99);
		bstTree.Add(19, 1919);
		bstTree.Add(13, 1313);
		bstTree.Add(18, 1818);
		bstTree.Add(17, 1717);
		bstTree.Add(4, 44);
		bstTree.Add(6, 66);
		bstTree.Add(2, 22);
		bstTree.Add(1, 11);
		bstTree.PostfixTraverse(Console.WriteLine);
		Console.ReadKey(true);
	}
}