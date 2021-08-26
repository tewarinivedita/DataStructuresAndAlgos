using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace DataStructures
{
    class ArrayInterviewQuestions
    {
        public class TestMyArray
        {
            SumOfTwoNumbers sumOfTwoNumbers = new SumOfTwoNumbers();
            public Dictionary<int, int[]> TestData = new Dictionary<int, int[]>()
            {
                {11, new[] {1, 3, 7, 9, 2}},
                {22, new[] {1, 3, 7, 9, 2}},
                {1, null},
                {5, new[] {5}},
            };
            public bool TestSumOfTwoNumber()
            {
                int[] arrTotest = new int[] {1, 3, 7, 9, 2};
                int sum = 11;
                int[] result = sumOfTwoNumbers.GetIndexesForSumOfNumber(arrTotest, sum);
                if(result[0]==3 && result[1]==4)
                    return true;
                return false;
            }
            public bool TestSumOfTwoNumberOptimizedCode()
            {
                int[] arrTotest = new int[] { 1, 3, 7, 9, 2 };
                int sum = 11;
                int[] result = sumOfTwoNumbers.GetIndexesForSumOfNumberOptimized(arrTotest, sum);
                if (result[0] == 3 && result[1] == 4)
                    return true;
                return false;
            }
            public bool TestGetSmallestPositiveNumberNotPresent()
            {
                int[] arrTotest = new int[] { 1, 3, 6, 4, 1, 2 };
                int result = sumOfTwoNumbers.GetSmallestPositiveNumberNotPresent(arrTotest);
                if (result == 5)
                    return true;
                return false;
            }
            public bool TestGetContainerAreaWithMaxWater()
            {
                int[] arrTotest = new int[] { 4, 8, 1, 2, 3, 9 };
                int result = sumOfTwoNumbers.GetContainerAreaWithMaxWater(arrTotest);
                if (result == 32)
                    return true;
                return false;
            }
            public bool TestGetTrappingRainWaterBruteForce()
            {
                int[] arrTotest = new []{ 0,1,0,2,1,0,3,1,0,1, 2 };
                int result = sumOfTwoNumbers.GetTrappingRainWaterBruteForce(arrTotest);
                if (result == 8)
                    return true;
                return false;
            }
            public bool TestGetTrappingRainWaterOptimized()
            {
                int[] arrTotest = new[] {0,1,0,2,1,0,1,3,2,1,2,1};
                //int[] arrTotest = new[] { 0, 1, 0, 2, 1, 0, 3, 1, 0, 1, 2 };
                int result = sumOfTwoNumbers.GetTrappingRainWaterOptimized(arrTotest);
                if (result == 8)
                    return true;
                return false;
            }
        }

        public class SumOfTwoNumbers
        {
            //Use two pointers one point to first element other pointing to end element
            //Move only one at a time based on a condition as to which one is smaller height
            public int GetTrappingRainWaterOptimized(int[] height)
            {
                int totalWater = 0;
                int left = 0, right = height.Length - 1, maxLeft=0,maxRight =0;
                while (left<right)
                {
                    int currentWater = 0;
                    if (height[left] < height[right]) //move left pointer
                    {
                        if (height[left] > maxLeft)
                            maxLeft = height[left];
                        else
                            currentWater = maxLeft - height[left];
                        left++;
                    }
                    else //move right pointer
                    {
                        if (height[right] > maxRight)
                            maxRight = height[right];
                        else
                            currentWater = maxRight - height[right];
                        right--;
                    }
                    totalWater += currentWater;
                }
                return totalWater;
            }

            //Use one pointer and calculate max left (for that use another pointer which is reinstatiated) and calcualte righ max each time(for while loop for it again)
            //Use formula currentWater = Math.Min(maxL, maxR) - height[i];
            public int GetTrappingRainWaterBruteForce(int[] height) //Use two pointers one point to first element other pointing to end element
            {
                int totalWater = 0;
                for (int i = 0; i < height.Length; i++)
                {
                    int left = i,right = i, maxL = 0, maxR = 0;
                    //Find Max Left
                    while (left >= 0)
                    {
                        maxL = Math.Max(maxL, height[left]);
                        left--;
                    }

                    //find Max Right
                    while (right < height.Length)
                    {
                        maxR = Math.Max(maxR, height[right]);
                        right++;
                    }

                    int currentWater = Math.Min(maxL, maxR) - height[i];
                    if (currentWater > 0)
                        totalWater += currentWater;
                }
                return totalWater;
            }


            
            public int GetContainerAreaWithMaxWater(int[] Heights)//Use two pointers one point to first element other pointing to end element
            {
                if (Heights == null || Heights.Length < 2)
                    return 0;
                int p1 = 0, p2 = Heights.Length - 1, maxWater = 0;

                while (p1< p2)
                {

                    int minHeight = Math.Min(Heights[p1], Heights[p2]);
                    int width = (p2 - p1);
                    int area = minHeight * width;
                    maxWater = Math.Max(maxWater, area);
                    Console.WriteLine("P1 : {0} P2 : {1}, MaxWater : {2}", p1, p2, maxWater);
                    Console.WriteLine("height : {0} width : {1}, area : {2}", minHeight, width, area);
                    Console.WriteLine("maxWater : {0} ", maxWater);

                    if (Heights[p1] <= Heights[p2])
                    {
                        p1++;
                    }
                    else
                    {
                        p2--;
                    }
                   
                }

                return maxWater;
            }
            public int[] GetIndexesForSumOfNumber(int[] arr, int sum)
            {
                int[] result = null;
                for (int p1 = 0; p1 < arr.Length-1; p1++)
                {
                    int numberToFind = sum - arr[p1];
                    for (int p2 = p1 +1; p2 < arr.Length; p2++)
                    {
                        if (arr[p2] == numberToFind)
                        {
                            result = new int[2];
                            result[0] = p1;
                            result[1] = p2;
                        }
                    }
                }

                return result;
            }

            public int[] GetIndexesForSumOfNumberOptimized(int[] arr, int sum)
            {
                int[] result = null;
                Hashtable ht = new Hashtable();
                for (int index = 0; index < arr.Length; index++)
                {
                    int currentVal = arr[index];
                    int ntf = sum - arr[index];
                    if (ht.ContainsKey(arr[index]))
                    {
                        return new[] { (int)ht[arr[index]], index};
                    }
                    ht.Add(ntf, index);
                }

                return result;
            }

            public int GetSmallestPositiveNumberNotPresent(int[] A)
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < A.Length; i++)
                {
                    if (ht.ContainsKey(A[i]))
                    {
                        continue;
                    }

                    ht.Add(A[i],A[i]);
                }

                int s = 1;
                for (int i = 0; i < A.Length; i++)
                {
                    if (ht.ContainsKey(s))
                    {
                        s++;
                    }
                    else
                    {
                        return s;
                    }

                }

                return s;
            }

        }
    }
}
