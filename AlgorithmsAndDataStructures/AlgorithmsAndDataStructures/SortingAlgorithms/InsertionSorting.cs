namespace SortingAlgorithms {

	internal static class InsertionSorting {
		public static void Sort(int[] elements) {
			for (int i = 1; i < elements.Length; i++) {
				if (elements[i] < elements[i - 1]) {
					int valueToCompare = elements[i];
					for (int j = i - 1; j >= 0; j--) {
						if (elements[j] > valueToCompare) {
							elements[j + 1] = elements[j];
						} else {
							elements[j + 1] = valueToCompare;
							break;
						}

						if (j == 0) {
							elements[j] = valueToCompare;
						}
					}
				}
			}
		}
	}
}
