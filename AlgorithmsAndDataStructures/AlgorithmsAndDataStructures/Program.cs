using System;
using DataStructures;
using SortingAlgorithms;

internal class Program {
	private static void Main(string[] args) {
        int[] unsorted = new int[] { 6, 5, 3, 1, 8, 7, 2, 4};
        MergeSorting.Sort(unsorted);
        foreach (var s in unsorted)
        {
            Console.WriteLine(s);
        }
		Console.ReadKey(true);
	}
}