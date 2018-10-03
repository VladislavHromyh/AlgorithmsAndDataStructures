using System;

namespace SortingAlgorithms
{
    internal static class MergeSorting
    {
        public static void Sort(int[] elements)
        {
            int[][] pairs = new int[(elements.Length / 2)][];
            int pairsIndex = 0;
            bool isOddCount = elements.Length % 2 != 0;
            for (int i = 0; ; )
            {
                int[] array;
                array = new int[2];
                array[0] = elements[i];
                array[1] = elements[i + 1];
                i += 2;
                SortSubarray(array);
                if (i == elements.Length - 1 && isOddCount)
                {
                    array = MergeSubarrays(array, new[] { elements[i] });
                }
                pairs[pairsIndex] = array;
                pairsIndex++;

                if (i == elements.Length - 1 && isOddCount)
                {
                    break;
                }
                else if (i == elements.Length && !isOddCount)
                {
                    break;
                }
            }

            int pairsCount = pairs.Length;

            while (pairsCount > 1)
            {
                int newPairsIndex = 0;
                pairsCount /= 2;
                int[][] newPairs = new int[pairsCount][];
                for (int j = 0; ;)
                {
                    newPairs[newPairsIndex] = MergeSubarrays(pairs[j], pairs[j + 1]);
                    j += 2;
                    newPairsIndex++;
                    if (j == pairs.Length)
                    {
                        break;
                    }
                }
                pairs = newPairs;
            }
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = pairs[0][i];
            }
        }

        private static void SortSubarray(int[] array)
        {
            if (array.Length != 2)
            {
                return;
            }

            if (array[0] > array[1])
            {
                int temp = array[0];
                array[0] = array[1];
                array[1] = temp;
            }
        }

        private static int[] MergeSubarrays(int[] array1, int[] array2)
        {
            int[] output = new int[array1.Length + array2.Length];
            int counter = 0;
            for (int i = 0, j = 0; ;)
            {
                int minValue = Math.Min(array1[i], array2[j]);
                output[counter] = minValue;
                counter++;
                if (array1[i] == minValue)
                {
                    i++;
                } else
                {
                    j++;
                }

                if (i == array1.Length && j == array2.Length)
                {
                    break;
                } else if (i == array1.Length)
                {
                    for (; j < array2.Length; j++)
                    {
                        output[counter] = array2[j];
                        counter++;
                    }
                    break;
                } else if (j == array2.Length)
                {
                    for (; i < array1.Length; i++)
                    {
                        output[counter] = array1[i];
                        counter++;
                    }
                    break;
                }
            }

            return output;
        }
    }
}
