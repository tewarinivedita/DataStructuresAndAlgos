using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructures
{
    internal class StringsInterviewQuestions
    {
        public class TestMyStringCode
        {
            private MyStringCode myStringCode = new MyStringCode();

            public bool TestBackSpaceCompare()
            {
                var A = "abc#d"; //"dasdasd"; //"##s";//"ab#z";
                var B = "abzz###d"; //"#dsa";//"##s#s";//"az#z";
                var result = myStringCode.BackSpaceCompare("abc#d", "abzz###d");
                return result;
            }

            public bool TestBackSpaceCompareOptimized()
            {
                var A = "abc#d"; //"dasdasd"; //"##s";//"ab#z";
                var B = "abzz###d"; //"#dsa";//"##s#s";//"az#z";
                var result = myStringCode.BackSpaceCompareOptimized("abc#d", "abzz###d");
                return result;
            }

            public bool TestLengthOfLongestSubstring()
            {
                var result = myStringCode.LengthOfLongestSubstring("abcdbaac");
                //int result = myStringCode.LengthOfLongestSubstring("abcddbaac");
                //int result = myStringCode.LengthOfLongestSubstring("aab");
                //int result = myStringCode.LengthOfLongestSubstring("dvdf");
                return result == 4;
            }

            public bool TestIsPalindrome()
            {
                //bool result = myStringCode.IsPalindrome("A man, a plan, a canal: Panama");
                var result = myStringCode.IsPalindrome("0P");
                return result;
            }

            public bool TestIsAlmostAPalindrome()
            {
                //bool result = myStringCode.IsAlmostAPalindrome("race a car");
                //bool result = myStringCode.IsAlmostAPalindrome("abccdba");
                //bool result = myStringCode.IsAlmostAPalindrome("abcdefdba");
                //var result = myStringCode.IsAlmostAPalindrome("a");
                var result = myStringCode.IsAlmostAPalindrome("ab");
                //var result = myStringCode.IsAlmostAPalindrome("");
                return result;
            }
        }

        public class MyStringCode
        {
            public static string TransformByRemovingFrom(string S)
            {
                // write your code in C# 6.0 with .NET 4.5 (Mono)
                
                char[] arr = S.ToCharArray();
                int i = 1;
                bool IsNotLastCheck = true;
                while (IsNotLastCheck)
                {
                    IsNotLastCheck = false;
                    while (i < S.Length)
                    {
                        string tempString = arr[i - 1] + arr[i].ToString();
                        if (tempString == "AA" || tempString == "BB" || tempString == "CC")
                        {
                            arr[i - 1] = (char)0;//'\0'
                            arr[i] = (char)0;
                            i += 2;
                            IsNotLastCheck = true;
                            continue;
                        }

                        i += 1;
                    }

                    string cleanString = new string(arr);
                    arr = cleanString.ToCharArray();
                    if(arr.Length > 1)
                        i = 1;
                    else
                        break;
                        
                }
               
                return new string(arr);
            }

            //Almost Palindrome - removing one character
            public bool IsAlmostAPalindrome(string s)
            {
                s = s.ToLower();
                var rgRegex = new Regex(@"[^0-9a-zA-Z]+");
                s = rgRegex.Replace(s, "");
                var inputArray = s.ToCharArray();
                int p = 0, q = inputArray.Length - 1;
                var firstAttempt = true;
                while (p <= q)
                {
                    if (inputArray[p] != inputArray[q])
                    {
                        if (firstAttempt)
                        {
                            if (inputArray[p] == inputArray[q - 1])
                            {
                                firstAttempt = false;
                                q--;
                                continue;
                            }

                            if (inputArray[q] == inputArray[p + 1])
                            {
                                firstAttempt = false;
                                p++;
                                continue;
                            }
                        }

                        return false;
                    }

                    p++;
                    q--;
                }

                return true;
            }

            //Palindrome
            public bool IsPalindrome(string s)
            {
                s = s.ToLower();
                var rgRegex = new Regex(@"[^0-9a-zA-Z]+");
                s = rgRegex.Replace(s, "");
                var inputArray = s.ToCharArray();
                int p = 0, q = inputArray.Length - 1;
                while (p <= q)
                {
                    if (inputArray[p] != inputArray[q])
                        return false;
                    p++;
                    q--;
                }

                return true;
            }

            //Slidding window technique
            public int LengthOfLongestSubstring(string s)
            {
                var arrChars = s.ToCharArray();
                if (arrChars.Length <= 1)
                    return arrChars.Length;

                int p = 0, maxLength = 0;
                var seen = new Hashtable();
                for (var q = 0; q < arrChars.Length; q++)
                {
                    var charQ = arrChars[q];
                    if (seen.ContainsKey(charQ))
                    {
                        var oldIndexOfElement = (int) seen[charQ];
                        seen[charQ] = q;
                        if (oldIndexOfElement >= p) p = oldIndexOfElement + 1;
                    }
                    else
                    {
                        seen.Add(charQ, q);
                    }

                    maxLength = Math.Max(maxLength, q - p + 1);
                }

                return maxLength;
            }

            public bool BackSpaceCompareOptimized(string s, string t) //TO DO
            {
                var A = s.ToCharArray();
                var B = t.ToCharArray();
                var p = A.Length - 1;
                var q = B.Length - 1;
                var backCountA = 0;
                var backCountB = 0;
                var compare = true;
                while (p >= 0 || q >= 0)
                {
                    if (A[p] == '#')
                    {
                        backCountA += 1;
                        p--;
                        compare = false;
                    }

                    if (B[q] == '#')
                    {
                        backCountB += 1;
                        compare = false;
                        q--;
                    }

                    if (A[p] != '#' && B[q] != '#')
                        compare = true;

                    if (compare)
                    {
                        if (A[p] != B[q]) return false;
                        p = p - backCountA - 1;
                        q = q - backCountB - 1;
                        backCountA = 0;
                        backCountB = 0;
                    }
                }

                if (p == q)
                    return true;

                return false;
            }

            public bool BackSpaceCompare(string s, string t)
            {
                var A = s.ToCharArray();
                var B = t.ToCharArray();
                var p = A.Length - 1;
                var q = B.Length - 1;
                while (p >= 0 || q >= 0)
                {
                    if (A[p] == '#')
                    {
                        var backCount = 2;

                        while (backCount > 0)
                        {
                            p--;
                            backCount--;
                            if (A[p] == '#')
                                backCount += 2;
                        }

                        continue;
                    }

                    if (B[q] == '#')
                    {
                        var backCount = 2;

                        while (backCount > 0)
                        {
                            q--;
                            backCount--;
                            if (B[q] == '#')
                                backCount += 2;
                        }

                        continue;
                    }

                    if (A[p] != B[q])
                        return false;
                    p--;
                    q--;
                }
                if (p == q)
                    return true;

                return false;
            }
        }
    }
}