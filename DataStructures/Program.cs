using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace HackerRankPrep1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringsInterviewQuestions.MyStringCode.TransformByRemovingFrom("ACCAABBC");

            Sort.InsertionSort(new [] { 12, 11});
            Sort.SelectionSort(new List<int>() {2, 0, 2, 1, 1, 0});


            Sort.QuickSort(new List<int>() { 2, 0, 2, 1, 1, 0 });
            Sort.BubbleSort(new List<int>() { 2, 0, 2, 1, 1, 0 });

            MyQueue obj = new MyQueue();
             obj.Push(1);
             obj.Push(2);
             int param_3 = obj.Peek();
             int param_5 = obj.Pop();
             int param_2 = obj.Pop();
            bool param_4 = obj.Empty();
 


            string validString = Stacks.MinRemoveToMakeValid();

            //Result.fizzBuzz(15);
            Result.journey();




            //DoubleLinkedList doubleLinkedList = new DoubleLinkedList();
            //doubleLinkedList.CreateDoublyLinkedList();




            //SingleLinkedList sLinkedList = new SingleLinkedList();
            //int[] arr = {1, 2, 3, 4, 5,6,7,8,9};
            ////int[] arr = { 1, 2, 3, 4, 5 };
            ////int[] arr = { 3, 5 };
            ////int[] arr = { 1,2,3,4,5};
            ////int[] arr = { 1, 2, 3 };
            ////int[] arr = { 3,5};
            //sLinkedList.CreateALinkedList(arr);
            //sLinkedList.Traverse(sLinkedList._head);
            ////sLinkedList.ReverseLinkedList(2,4);
            //sLinkedList.ReverseLinkedList(sLinkedList._head, 3, 7);
            //sLinkedList.ReverseLinkedList();
            //sLinkedList.Traverse(sLinkedList._head);//check if it is reversed

            //StringsInterviewQuestions.TestMyStringCode stringInterviewQuestions =
            //    new StringsInterviewQuestions.TestMyStringCode();
            //stringInterviewQuestions.TestIsAlmostAPalindrome();
            //stringInterviewQuestions.TestIsPalindrome();
            //stringInterviewQuestions.TestLengthOfLongestSubstring();
            //stringInterviewQuestions.TestBackSpaceCompareOptimized();


            //ArrayInterviewQuestions.TestMyArray arrayInterviewQuestions = new ArrayInterviewQuestions.TestMyArray();
            //arrayInterviewQuestions.TestGetTrappingRainWaterOptimized();
            //arrayInterviewQuestions.TestGetTrappingRainWaterBruteForce();
            //arrayInterviewQuestions.TestGetContainerAreaWithMaxWater();
            //arrayInterviewQuestions.GetSmallestPositiveNumberNotPresent();
            //arrayInterviewQuestions.TestSumOfTwoNumberOptimizedCode();


            //Console.WriteLine("Hello World!");
            //string inputString = "1234123456";

            //SingleLinkedList sLL = new SingleLinkedList();
            //sLL.InsertFront(sLL, 1);
            //sLL.InsertFront(sLL, 2);
            //sLL.InsertFront(sLL, 3);
            //sLL.ReverseLinkedList(sLL);
            //sLL.Traverse(sLL.head);
            //IsSherlockString(inputString);
        }

        public static string IsSherlockString(string inputString)
        {
            List<FinalList> finalSherLockFinalLists = new List<FinalList>();
            var start = CharNode.CircularLinkedList[0];
            var nextCharNode = CharNode.CircularLinkedList[0].NextCharNode;
            finalSherLockFinalLists.Add(new FinalList()
            {
                Alphabet = start.Alphabet,
                Count = 1
            });
            bool iterate = true;
            int indexer = 0;
            while (iterate)
            {
                if (nextCharNode.Alphabet == finalSherLockFinalLists[indexer].Alphabet)
                {
                    finalSherLockFinalLists[indexer].Count++;
                    var toDeleteNode = nextCharNode;
                    nextCharNode = nextCharNode.NextCharNode;
                    CharNode.DeleteNode(toDeleteNode);
                    if (CharNode.TotalCount==0)
                    {
                        iterate = false;
                    }
                }
                else
                {
                    indexer++;
                    finalSherLockFinalLists.Add(new FinalList()
                    {
                        Alphabet = start.Alphabet,
                        Count = 1
                    });
                    nextCharNode = nextCharNode.NextCharNode;
                }
            }

            for(int i=0;i< finalSherLockFinalLists.Count()-2;i++)
            {
                if(i+1 > finalSherLockFinalLists.Count)
                    continue;
                if (finalSherLockFinalLists[i].Count != finalSherLockFinalLists[i + 1].Count)
                    return "NO";
            }
            
            return "YES";
        }

        private static void CreateCircularLinkedList(char[] arrOfChars)
        {
            CharNode.CircularLinkedList = new List<CharNode>();
            for (int i = 0; i < arrOfChars.Length; i++)
            { if(i == arrOfChars.Length-2)
                {
                    CharNode node = new CharNode()
                    {
                        Alphabet = arrOfChars[i],
                        NextCharNode = new CharNode()
                    };
                    CharNode.CircularLinkedList.Add(node);
                }
                else 
                {
                    CharNode node = new CharNode()
                    {
                        Alphabet = arrOfChars[i],
                        NextCharNode = new CharNode()
                        {
                            Alphabet = arrOfChars[i+1]
                        }
                    };
                    CharNode.CircularLinkedList.Add(node);
                }
            }

            CharNode.TotalCount = arrOfChars.Length;
        }
    }

    public class CharNode
    {
        public char Alphabet;
        public CharNode NextCharNode;
        public static List<CharNode> CircularLinkedList;
        public static int TotalCount;
        public static void DeleteNode(CharNode node)
        {
            if(TotalCount==0)
                return;

            CircularLinkedList.Remove(node);
            TotalCount--;
        }

    }

    public class FinalList
    {
        public char Alphabet;
        public int Count;
    }
}
