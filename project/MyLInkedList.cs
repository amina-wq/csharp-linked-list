using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class MyNode<T>
    {
        public T Data { get; set; }
        public MyNode<T> Next { get; set; }
        public MyNode<T> Prev { get; set; }
        public MyNode(T data)
        {
            Data = data;
        }
    }

    class MyLinkedList<T>
    {
        MyNode<T> Head = null;
        MyNode<T> Tail = null;
        int count = 0;

        public void Add(T item)
        {
            MyNode<T> newNode = new MyNode<T>(item);

            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
            }
            Tail = newNode;
            count++;
        }

        public void AddLast(T item)
        {
            Add(item);
        }

        public void AddFirst(T item)
        {
            MyNode<T> newNode = new MyNode<T>(item);

            if (Head == null)
            {
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Prev = newNode;
            }
            Head = newNode;
            count++;

        }

        public void Add(int index, T item)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException();
            else if (index == 0)
            {
                AddFirst(item);
            }
            else if (index == count)
            {
                AddLast(item);
            }
            else
            {
                MyNode<T> oldNode = FindNode(index);
                MyNode<T> newNode = new MyNode<T>(item);
                oldNode.Prev.Next = newNode;
                newNode.Prev = oldNode.Prev;
                oldNode.Prev = newNode;
                newNode.Next = oldNode;
                count++;
            }
        }

        public void RemoveFirst()
        {
            Head = Head.Next;
            Head.Prev = null;
            count--;
        }

        public void RemoveLast()
        {
            Tail = Tail.Prev;
            Tail.Next = null;
            count--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            else if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == count)
            {
                RemoveLast();
            }
            else
            {
                MyNode<T> NodeToDelete = FindNode(index);
                MyNode<T> PrevNode = NodeToDelete.Prev;
                PrevNode.Next = NodeToDelete.Next;
                NodeToDelete.Next.Prev = PrevNode;
                count--;
            }
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            MyNode<T> Node = FindNode(index);
            Node.Data = item;
        }

        public int IndexOf(T item)
        {
            int currentIndex = 0;
            MyNode<T> currentNode = Head;
            while (!currentNode.Data.Equals(item))
            {
                if (currentNode.Next == null)
                {
                    throw new Exception();
                }
                currentNode = currentNode.Next;
                currentIndex++;
            }
            

            return currentIndex;

        }

        public int LastIndexOf(T item)
        {
            int currentIndex = count - 1;
            MyNode<T> currentNode = Tail;
            while (!currentNode.Data.Equals(item))
            {
                if (currentNode.Prev == null)
                {
                    throw new Exception();
                }
                currentNode = currentNode.Prev;
                currentIndex--;
            }

            return currentIndex;
        }

        public void Sort()
        {
            List<T> newArray = new List<T>();
            MyNode<T> currentNode = Head;
            while (currentNode != null)
            {
                newArray.Add(currentNode.Data);
                currentNode = currentNode.Next;
            }

            newArray.Sort();
            MyLinkedList<T> newLinkedList = new MyLinkedList<T>();
            foreach(T item in newArray)
            {
                newLinkedList.Add(item);
            }
            Head = newLinkedList.Head;
            Tail = newLinkedList.Tail;
        }

        public T GetFirst()
        {
            return Head.Data;
        }
        public T GetLast()
        {
            return Tail.Data;
        }

        private MyNode<T> FindNode(int index)
        {
            int currentIndex = 0;
            MyNode<T> currentNode = Head;
            while (currentIndex != index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }

            return currentNode;
        }

        public void Print()
        {
            MyNode<T> currentNode = Head;
            Console.Write("null <-> ");
            while (currentNode != null)
            {
                Console.Write($"{currentNode.Data} <-> ");
                currentNode = currentNode.Next;
            }
            Console.WriteLine("null");
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();
            return FindNode(index).Data;
        }

        public int Size()
        {
            return count;
        }
    }
    class MyLInkedList
    {
        static void Main()
        {
            MyLinkedList<string> newList = new MyLinkedList<string>();
            newList.Add("add");
            newList.Add("pop");
            newList.Add("push");
            newList.Add(1, "kakashka");
            newList.Add("kakashka");
            newList.Add("kakashka");
            newList.Print();
            newList.Sort();
            newList.Print();
            Console.ReadLine();
        }
    }

}