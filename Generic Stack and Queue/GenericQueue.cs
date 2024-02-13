using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Task
{
    public class GenericQueue<T> where T : class
    {
      
            private T[] queue;
            private int front = -1;
            private int rear = -1;
            private int size;

            public GenericQueue(int size)
            {
                this.size = size;
                queue = new T[size];
            }

            public void Enqueue(T newItem)
            {
                if (rear + 1 == size)
                {
                    Console.WriteLine("Queue Overflow");
                    return;
                }
                else
                {
                    if (front == -1 && rear == -1)
                    {
                        front = 0;
                        rear = 0;
                    }
                    else
                    {
                        rear++;
                    }
                    queue[rear] = newItem;
                }
            }

            public T Dequeue()
            {
                if (front > rear || rear == -1)
                {
                    Console.WriteLine("Queue is Empty");
                    throw new Exception("Empty Queue");
                }
                else
                {
                    T item = queue[front];
                    if (front == rear)
                    {
                        rear = -1;
                        front = -1;
                    }
                    else
                    {
                        front++;
                    }
                    return item;
                }
            }

            public bool IsEmpty()
            {
                return front == -1 || front > rear;
            }

            public bool IsFull()
            {
                return rear + 1 == size;
            }
        

    }
}
