namespace SortingAlgorithms {

	internal static class SelectionSorting {
		public static void Sort(int[] elements) {
			int sortedElementsCount = 0;

			for (int i = 0; i < elements.Length; i++) {
				int minValue = int.MaxValue;
				int minValueIndex = 0;
				for (int j = sortedElementsCount; j < elements.Length; j++) {
					if (elements[j] < minValue) {
						minValue = elements[j];
						minValueIndex = j;
					}
				}
				int valueToReplace = elements[sortedElementsCount];
				if (valueToReplace == minValue) {
					sortedElementsCount++;
					continue;
				}
				elements[sortedElementsCount] = minValue;
				elements[minValueIndex] = valueToReplace;
				sortedElementsCount++;
			}
		}
	}
}
