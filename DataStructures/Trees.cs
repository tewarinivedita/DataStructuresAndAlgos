using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace DataStructures
{
    public class TreeNode
    {
        public int? Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int? val = 0, TreeNode left =null,TreeNode right =null)
        {
            Val = val;
            Left = left;
            Right = right;
        }

    }
    public static class Trees
    {
        public static TreeNode InsertLevelOrder(int?[] array, TreeNode root, int i)
        {
            if (i < array.Length)
            {
                root = new TreeNode(array[i]);
                root.Left = InsertLevelOrder(array, root.Left, 2 * i+1);
                root.Right = InsertLevelOrder(array, root.Right, 2 * i+2);
            }

            return root;
        }
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
                return null;
            IList<int?> levels = new List<int?>() { };
            levels.Add(root.Val);
            
            return 
        }
        public static void InOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left);
                Console.Write(root.Val + " ");
                InOrderTraversal(root.Right);
            }
        }
        public static void PreOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.Val + " ");
                PreOrderTraversal(root.Left);
                PreOrderTraversal(root.Right);
            }
        }

        public static void PostOrderTraversal(TreeNode root)
        {
            if (root != null)
            {
                PostOrderTraversal(root.Left);
                PostOrderTraversal(root.Right);
                Console.Write(root.Val + " ");
            }
        }

        public static int MaxDepthOptimized(TreeNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(MaxDepthOptimized(root.Left), MaxDepthOptimized(root.Right));

        }

        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return DfsToGetMaxDepth(root, 0);

        }

        public static int DfsToGetMaxDepth(TreeNode node, int count)
        {
            if (node == null)
                return count;
            count++;
            return Math.Max(DfsToGetMaxDepth(node.Left, count), DfsToGetMaxDepth(node.Right, count));
        }
    }
}
