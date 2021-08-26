using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class Result
    {
        //answer should be 37
        public static long journey()
        {
            List<int> path; int maxStep;
            path = new List<int>() {3, 10, -20, -5, 2}; //new List<int>() {10, 2, -10, 5, 20}; //ans 37
            maxStep = 2;
            if (path == null || path.Count == 0)
                return 0;
            
            long maxSum = path[0];
            int i = 0;
            while (i < path.Count - 1)
            {
                long maxNumInPath = 0;
                Hashtable ht = new Hashtable();
                for (int j = 1; j <= maxStep; j++)
                {
                    int k = i + j;
                    if (k >= path.Count)
                        break;

                    if (path[k] > maxNumInPath)
                    {
                        long maxInHt = path[k];
                        if (ht.ContainsKey(maxInHt))
                            ht[maxInHt] = k;
                        else
                            ht.Add((long)path[k], k);

                        maxNumInPath = path[k];
                    }
                }

                maxSum = maxSum + maxNumInPath;
                if (ht.ContainsKey(maxNumInPath))
                    i = (int)ht[maxNumInPath];
            }

            return maxSum;
        }

        public static void fizzBuzz(int n = 15)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                if(i%3==0 && i%5!=0)
                    Console.WriteLine("Fizz");
                if(i % 3 != 0 && i % 5 == 0)
                    Console.WriteLine("Buzz");
                if (i % 3 != 0 && i % 5 != 0)
                    Console.WriteLine(i);

            }
        }
    }
}
