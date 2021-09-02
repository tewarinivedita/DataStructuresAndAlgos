using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public static class Search
    {
        //on Sorted array
        //Log N (base is 2)
        public static int BinarySearch(int[] sortedArray, int target)
        {
            int l = 0;
            int r = sortedArray.Length - 1;

            if (sortedArray.Length == 1)
            {
                if (sortedArray[0] == target)
                    return 0;
                return -1;
            }

            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (sortedArray[mid] == target)
                {
                    return mid;
                }

                if (target > sortedArray[mid])
                {
                    r = mid + 1;
                }

                if (target < sortedArray[mid])
                {
                    l = mid - 1;
                }
            }

            return -1;

        }
        

        public static int BinarySearchWithLeftRight(int[] sortedArray, int l, int r, int target)
        {
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (sortedArray[mid] == target)
                {
                    return mid;
                }

                if (target > sortedArray[mid])
                {
                    l = mid + 1;
                }

                if (target < sortedArray[mid])
                {
                    r = mid - 1;
                }
            }

            return -1;
        }

        //O(N)
        public static int[] FindFirstAndLastPositionOfElement(int[] nums, int element)
        {
            int l = 0;
            int r = nums.Length - 1;
            int LP =0, RP=0;

            while (l <= r || l!=0 && r!=0)
            {
                int mid = (l + r) / 2;
                if (nums[mid] == element)
                {
                    LP = mid;
                    RP = mid;
                    break;
                }

                
                if (element > nums[mid] && mid < nums.Length - 1)
                {
                    l = mid + 1;
                }

                if (element < nums[mid] && mid > 0)
                {
                    r = mid - 1;
                }
            }


            if (l == 0 && nums[r] != element)
                return null;
                
            while (nums[LP] != element)
            {
                LP = LP - 1;
            }

            while (nums[RP] != element)
            {
                RP = RP + 1;
            }
            
            return new[] {LP, RP};
        }

        //O(LogN)
        public static int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
                return new[] {-1, -1};

            int l = 0;
            int r = nums.Length - 1;
            int firstPosition = BinarySearchWithLeftRight(nums, l, r, target);
            if(firstPosition==-1)
                return new[] { -1, -1 };


            int startI = firstPosition, endI = firstPosition, prevEnd=firstPosition, prevStart=firstPosition;
            while (startI!=-1)
            {
                prevStart = startI;
                startI = BinarySearchWithLeftRight(nums, 0, startI - 1, target);
            }

            startI = prevStart;
            while (endI != -1)
            {
                prevEnd = endI;
                endI = BinarySearchWithLeftRight(nums, endI + 1, nums.Length - 1, target);
            }

            endI = prevEnd;
            int[] foundIs = {startI, endI };

            return foundIs;
        }

    }
}
