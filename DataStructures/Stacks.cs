using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    //LIFO - last in first ou
    class Stacks
    {
        //s = "a)bcd()e" => "abcd()e"
        //s = "(ab(c)e" => "(abc)e" or "ab(c)e"
        //s = "))((" => ""
        //Trick you can also remove by removing with empty literal
        public static string MinRemoveToMakeValid()
        {
            string s = "))((";
            char[] arr = s.ToCharArray();
            HashSet<int> removePoss = new HashSet<int>();
            Stack<int> positions = new Stack<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '(')
                {
                    positions.Push(i);
                }
                else if (arr[i] == ')' && positions.Count > 0)
                    positions.Pop();
                else if (arr[i] == ')' && positions.Count == 0)
                {
                    removePoss.Add(i);
                }
            }

            s = "";
            if (positions.Count > 0)
            {
                foreach (var pos in positions)
                {
                    removePoss.Add(pos);
                }
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (!removePoss.Contains(i))
                    s = arr[i] + s;
            }

            return s;
        }
    }
}
