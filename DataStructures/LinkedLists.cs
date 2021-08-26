using System;
using System.Collections.Generic;
using System.Text;

//[1]
//1
//1
//    [1, 2]
//1
//2
//    [1, 2, 3]
//1
//3
//    [1, 2, 3]
//1
//2
//    [1, 2, 3]
//2
//3
//    [1, 2, 3, 4, 5]
//2
//4
//    [1, 2, 3, 4, 5]
//3
//5
//    [1, 2, 3]
//0
//0
//    [1, 2, 3]
//4
//1
//        [1, 2, 3]
//    - 1
//2
//    [1, 2, 3]
//1
//    - 2
namespace HackerRankPrep1
{
    public class CircularLinkedList
    {
        public ListNode head;
        
        public void InsertAfter(ListNode prev_node, int new_data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given previous node Cannot be null");
                return;
            }

            if (prev_node.next == head)
            {
                ListNode new_node = new ListNode(new_data);
                new_node.next = head;
                prev_node.next = new_node;
            }
            else
            {
                ListNode new_node = new ListNode(new_data);
                new_node.next = prev_node.next;
                prev_node.next = new_node;

            }

        }
        
        public void DeleteNodebyKey(CircularLinkedList singlyList, int key)
        {
            ListNode temp = singlyList.head;
            ListNode prev = null;
            if (temp != null && temp.val == key)
            {
                singlyList.head = temp.next;
                return;
            }
            while (temp != null && temp.val != key)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            prev.next = temp.next;
        }
        
    }

    public class SingleLinkedList
    {
        public ListNode _head;

        public void CreateALinkedList(int[] arr)
        {
            if (arr.Length == 0)
                _head = null;
            ListNode prevNode = new ListNode(arr[0]);
            _head = prevNode;
            for (int i =1; i<arr.Length;i++)
            {
                ListNode curNode = new ListNode(arr[i]);
                prevNode.next = curNode;
                prevNode = curNode;
            }
        }

        public void Traverse(ListNode node)
        {
            if (node == null)
                return;
            Console.WriteLine("\n\nTraversing in Forward Direction\n\n");

            while (node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }

        }

        public void ReverseLinkedList()
        {
            if (_head == null || _head.next ==null)
                return;

            ListNode P = null;
            ListNode Q = _head;
            while (Q != null)
            {
                ListNode tmpNode = Q.next;
                Q.next = P;
                P = Q;
                Q = tmpNode;
            }

            _head = P;
        }




        public ListNode ReverseLinkedList(ListNode head, int left, int right)
        {
            ListNode Q = head;
            ListNode P = null;
            int counter = 1;
            while (counter < left)
            {
                P = Q;
                Q = Q.next;
                counter++;
            }

            ListNode tail = Q;
            ListNode N = Q.next;

            //reverse now
            while (counter >= left && counter < right)
            {
                ListNode tmpNode = Q.next;
                Q.next = P;
                P = Q;
                Q = tmpNode;
                counter++;
            }

            ListNode tmp = tail.next;
            tail.next = P;
            tmp.next = Q;

            return head;
        }

        //public ListNode ReverseLinkedListSun(ListNode head, int left, int right)
        //{
        //    if (head == null)
        //        return null;
        //    if (head.next == null || left < 1 && right > 500 || left > right || left == right)
        //        return head;

        //    if (head.next.next == null)
        //    {
        //        ListNode nexthead = head.next;
        //        head.next = null;
        //        nexthead.next = head;
        //        head = nexthead;
        //        return head;
        //    }

        //    ListNode Q = head;
        //    ListNode P = null;
        //    while (Q.next != null && Q.val != left)
        //    {
        //        P = Q;
        //        Q = Q.next;
        //    }

        //    ListNode P2 = P;
        //    ListNode Q2 = Q;
        //    while (Q2 != null && Q2.val != right)//reverse the list till it finds
        //    {
        //        ListNode tmpNode = Q.next;
        //        Q2.next = P2;
        //        P2 = Q2;
        //        Q2 = tmpNode;
        //    }

        //    ListNode tmpNode2 = P.next;
        //    P.next = P2;
        //    tmpNode2.next = Q;
        //    return head;
        //}
        
        public void InsertLast(int new_data)
        {
            ListNode new_node = new ListNode(new_data);
            if (_head == null)
            {
                _head = new_node;
                return;
            }
            ListNode lastNode = GetLastNode();
            lastNode.next = new_node;
        }
        public void InsertFront(SingleLinkedList singlyList, int new_data)
        {
            ListNode new_node = new ListNode(new_data);
            new_node.next = singlyList._head;
            singlyList._head = new_node;
        }
        public void InsertAfter(ListNode prev_node, int new_data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given previous node Cannot be null");
                return;
            }
            ListNode new_node = new ListNode(new_data);
            new_node.next = prev_node.next;
            prev_node.next = new_node;
        }

        public ListNode GetLastNode()
        {
            ListNode temp = _head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }


        public void DeleteNodebyKey(SingleLinkedList singlyList, int key)
        {
            ListNode temp = singlyList._head;
            ListNode prev = null;
            if (temp != null && temp.val == key)
            {
                singlyList._head = temp.next;
                return;
            }
            while (temp != null && temp.val != key)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            prev.next = temp.next;
        }

    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int d)
        {
            val = d;
            next = null;
        }
    }
}
