using System;

namespace DataStructures
{

    public class DoubleLinkedList
    {
        public Node head;
        public Node CreateDoublyLinkedList()
        {
            int[] arr = { 10, 11 };
            Node H1 = CreateALinkedList(arr);
            int[] arr2 = { 7, 8, 9 };
            Node H2 = CreateALinkedList(arr2);
            int[] arr3 = { 12, 13 };
            Node H3 = CreateALinkedList(arr3);
            int[] arr4 = { 1, 2, 3, 4, 5, 6 };
            Node H4 = CreateALinkedList(arr4);

            H2.next.child = H1;
            H4.next.child = H2;

            Node Q = H4;
            while (Q != null)
            {
                if (Q.val == 5)
                {
                    Q.child = H3;
                }
                Q = Q.next;
            }

            return H4;
        }

        public Node CreateALinkedList(int[] arr)
        {
            if (arr.Length == 0)
                return null;
            Node P = new Node(arr[0]);
            Node head = P;
            for (int i = 1; i < arr.Length; i++)
            {
                Node tmpNode = new Node(arr[i]);
                tmpNode.prev = P;
                P.next = tmpNode;
                P = tmpNode;
            }

            return head;
        }
        public void InsertFront(DoubleLinkedList doubleLinkedList, int data)
        {
            Node newNode = new Node(data);
            newNode.next = doubleLinkedList.head;
            newNode.prev = null;
            if (doubleLinkedList.head != null)
            {
                doubleLinkedList.head.prev = newNode;
            }
            doubleLinkedList.head = newNode;
        }
        public void InsertLast(DoubleLinkedList doubleLinkedList, int data)
        {
            Node newNode = new Node(data);
            if (doubleLinkedList.head == null)
            {
                newNode.prev = null;
                doubleLinkedList.head = newNode;
                return;
            }
            Node lastNode = GetLastNode(doubleLinkedList);
            lastNode.next = newNode;
            newNode.prev = lastNode;
        }
        public Node GetLastNode(DoubleLinkedList singlyList)
        {
            Node temp = singlyList.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        public void InsertAfter(Node prev_node, int data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
            Node newNode = new Node(data);
            newNode.next = prev_node.next;
            prev_node.next = newNode;
            newNode.prev = prev_node;
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
        }
        public void DeleteNodebyKey(DoubleLinkedList doubleLinkedList, int key)
        {
            Node temp = doubleLinkedList.head;
            if (temp != null && temp.val == key)
            {
                doubleLinkedList.head = temp.next;
                doubleLinkedList.head.prev = null;
                return;
            }
            while (temp != null && temp.val != key)
            {
                temp = temp.next;
            }
            if (temp == null)
            {
                return;
            }
            if (temp.next != null)
            {
                temp.next.prev = temp.prev;
            }
            if (temp.prev != null)
            {
                temp.prev.next = temp.next;
            }
        }
    }

    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;

        public Node(int data)
        {
            val = data;
        }
    }
}
