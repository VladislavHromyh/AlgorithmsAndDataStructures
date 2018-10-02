namespace SortingAlgorithms{

    internal static class BubbleSorting
    {
		public static void Sort(int[] elements) {
			bool isCollectionOrdered = false;
			while (!isCollectionOrdered) {
				isCollectionOrdered = true;
				for (int i = 0; i < elements.Length - 1; i++) {
					if (elements[i] > elements[i + 1]) {
						isCollectionOrdered = false;
						int largerValue = elements[i];
						elements[i] = elements[i + 1];
						elements[i + 1] = largerValue;
					}
				}
			}
		}
	}
}
