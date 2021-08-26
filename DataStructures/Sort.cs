using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    //QuickSort, Merge Sort, tree traversal, graph = > recursion 
    class Sort
    {
        public static void QuickSort(List<int> values)
        {
            QuickSortRecurssion(values, 0, values.Count - 1);
        }

        private static void QuickSortRecurssion(List<int> values, int left, int right)
        {
            if (left < right)
            {
                int pivotalIndex = GetPivotalIndex(values, left, right);
                QuickSortRecurssion(values, left, right - pivotalIndex);
                QuickSortRecurssion(values, left + pivotalIndex, right);
            }
        }

        public static int GetPivotalIndex(List<int> values, int left, int right)
        {
            int pElement = values[right];
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (values[j] > pElement)
                {
                    Swap(values, i, j);
                    i++;
                }
            }

            Swap(values, i, right);
            return i;
        }

        public static void Swap(List<int> values, int i, int j)
        {
            int tmp = values[i];
            values[i] = values[j];
            values[j] = tmp;
        }

        //O(N)
        //Move the largest to the right
        public static void BubbleSort(List<int> values)
        {
            int maxForIteration = values.Count;

            while (maxForIteration > 0)
            {
                int k = 1;
                while (k < maxForIteration)
                {
                    if (values[k - 1] > values[k])
                    {
                        int grtVal = values[k - 1];
                        values[k - 1] = values[k];
                        values[k] = grtVal;
                    }

                    k++;
                }

                maxForIteration--;
            }

        }

        //Find the smallest and put it in position one
        public static void SelectionSort(List<int> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                int sIndex = i;
                int j = i + 1;
                while (j < values.Count)
                {
                    if (values[sIndex] > values[j])
                    {
                        sIndex = j;
                    }

                    j++;
                }

                Swap(values, sIndex, i);
            }
        }

        public static void InsertionSort(int[] values)
        {
            if (values.Length == 1)
                return;
            Hashtable ht = new Hashtable();
            ht.Add(1,2);
            for (int i = 1; i < values.Length; i++)
            {
                int j = i - 1;
                int key = values[i];
                while (j >= 0 && key < values[j])
                {
                    values[j + 1] = values[j];
                    j--;
                }

                values[j + 1] = key;
            }

        }

        //ArrayInversionCount
        //Best BestShuffle
    }
}
