using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms {

	internal static class SelectionnSorting {
		public static void Sort(int[] elements) {
			int sortedElementsCount = 0;

			for (int i = 0; i < elements.Length; i++) {
				int minValue = Int32.MaxValue;
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
