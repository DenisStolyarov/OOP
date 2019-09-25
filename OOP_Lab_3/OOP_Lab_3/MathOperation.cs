using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_3
{
    static class MathOperation
    {
        public static int GetMax(Stack<int> stack)
        {
            if (stack.isEmpty())
            {
                return -1;
            }
            Stack<int> Math = (Stack<int>)stack.Clone();
            int[] arr = new int[Math.size];
            int max = 0;
            for (int i = 0; !Math.isEmpty(); i++)
            {
                arr[i] = Math.top();
                if (arr[i]>arr[max])
                {
                    max = i;
                }
                Math.pop();
            }
            return arr[max];
        }

        public static int GetMin(Stack<int> stack)
        {
            if (stack.isEmpty())
            {
                return -1;
            }
            Stack<int> Math = (Stack<int>)stack.Clone();
            int[] arr = new int[Math.size];
            int min = 0;
            for (int i = 0; !Math.isEmpty(); i++)
            {
                arr[i] = Math.top();
                if (arr[i] < arr[min])
                {
                    min = i;
                }
                Math.pop();
            }
            return arr[min];
        }

        public static uint Length(Stack<int> stack)
        {
            return stack.size;
        }
    }
}
