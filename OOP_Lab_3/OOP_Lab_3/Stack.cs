using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_3
{
    class Owner
    {
        int id;
        string owner_name;
        string organization_name;

        public Owner(string name, string organization)
        {
            owner_name = name;
            organization_name = organization;
            id = owner_name.GetHashCode() + organization_name.GetHashCode();
        }

        public override string ToString()
        {
            return "Owner Information:\nID: " + id + "\nName: " + owner_name + "\nOrganization: " + organization_name + "\n-  -  -  -  -  -  -\n";
        }
    }

    public class Stack<T> :ICloneable
    {
        class Node
        {
            public T value;
            public Node Next;
            public Node(T value)
            {
                this.value = value;
                Next = null;
            }
        }

        public readonly DateTime Time;
        Owner Stack_owner;
        Node Head;
        public uint size;

        public Stack()
        {
            Stack_owner = new Owner("Denis", "BSTU");
            Time = DateTime.Now;
            Head = null;
            size = 0;
        }

        public void Information()
        {
            Console.WriteLine(Stack_owner.ToString() + "\nDate: " + Time + "\n");
        }

        public void push(T value)
        {
            Node new_node = new Node(value);
            if (size == 0)
            {
                Head = new_node;
                new_node.Next = null;
            }
            else
            {
                new_node.Next = Head;
                Head = new_node;
            }
            size++;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void pop()
        {
            if (isEmpty())
            {
                return;
            }
            else
            {
                Head = Head.Next;
                size--;
            }
        }

        public T top()
        {
            return Head.value;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public static void Show(Stack<T> stack)
        {
            Stack<T> show = (Stack<T>)stack.Clone();
            
            for (int i = 0;!show.isEmpty() ; i++)
            {
                Console.Write(show.top()+" ");
                show.pop();
            }
            Console.WriteLine();
        }
        //////////////////////////////////////////
        public static Stack<T> operator +(Stack<T> stack_1, Stack<T> stack_2)
        {
            while (!stack_2.isEmpty())
            {
                stack_1.push(stack_2.top());
                stack_2.pop();
            }
            return stack_1;
        }

        public static Stack<T> operator --(Stack<T> stack)
        {
            stack.pop();
            return stack;
        }

        public static bool operator true(Stack<T> stack)
        {
            if (stack.isEmpty())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator false(Stack<T> stack)
        {
            if (!stack.isEmpty())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Stack<T> operator <(Stack<T> stack_1, Stack<T> stack_2)
        {
            Stack<T> stack = (Stack<T>)stack_2.Clone();
            T[] arr = new T[stack.size];

            for (int i = 0; !stack.isEmpty(); i++)
            {
                arr[i] = stack.top();
                stack.pop();
            }

            Array.Sort<T>(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                stack_1.push(arr[i]);
            }
            return stack_1;
        }

        public static Stack<T> operator >(Stack<T> stack_1, Stack<T> stack_2)
        {
            Stack<T> stack = (Stack<T>)stack_1.Clone();
            T[] arr = new T[stack.size];

            for (int i = 0; !stack.isEmpty(); i++)
            {
                arr[i] = stack.top();
                stack.pop();
            }

            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
            {
                stack_2.push(arr[i]);
            }
            return stack_2;
        }
    }
}
