using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Task
{
    public class GenericStack<T> where T : struct
    {
        private T[] stack;
        private int topIndex = -1;
        private int size = 0;

        public GenericStack(int size)
        {
            this.size = size;
            this.stack = new T[size];
        }

        public void Push(T newItem)
        {
            if (topIndex >= size - 1)
            {
                Console.WriteLine("Stack is full.");
                return;
            }
            stack[++topIndex] = newItem;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is already empty.");
                throw new Exception("Empty Stack");
            }
            T poppedItem = stack[topIndex--];
            return poppedItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty.");
                return default(T); // Returns default value of type T
            }
            return stack[topIndex];
        }

        public bool IsEmpty()
        {
            return topIndex == -1;
        }
    }
}
