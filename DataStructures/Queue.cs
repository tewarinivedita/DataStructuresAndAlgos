
namespace DataStructures
{
    //FIFO
    public class MyQueue
    {
        private int max = 100;
        private int[] inStack;
        private int[] outStack;
        private int topIn = -1;
        private int topOut = -1;

        /** Initialize your data structure here. */
        public MyQueue()
        {
            inStack = new int[max];
            outStack = new int[max];
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            if (topIn + 1 < max)
            {
                topIn++;
                inStack[topIn] = x;
            }
            else
            {
                DeQueue();
                topIn++;
                inStack[topOut] = x;
            }
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            int val = 0;
            if (!Empty())
            {
                if (topOut >= 0)
                    val = outStack[topOut];
                else
                {
                    DeQueue();
                    val = outStack[topOut];
                }
                topOut--;
            }

            return val;
        }

        public void DeQueue()
        {
            if(topOut != -1)
                return;
            ;
            int i = topIn;
            int o = -1;

            while (i >= 0)
            {
                o++;
                outStack[o] = inStack[i];
                i--;
            }
            topIn = i;
            topOut = o;

        }

        /** Get the front element. */
        public int Peek()
        {
            int val=0;
            if (!Empty())
            {
                if (topOut >= 0 && topOut < max)
                    val = outStack[topOut];
                else
                {
                    DeQueue();
                    val = outStack[topOut];
                }
            }

            return val;

        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            if (topOut == -1 && topIn == -1)
                return true;
            else
                return false;
        }
    }


}
