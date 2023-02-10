using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_10_02_23
{
    internal class MyArrayList : IEnumerable
    {
        private int size;
        private LinkedList<int> list;

        public MyArrayList()
        {
            list = new LinkedList<int>();
            size = 0;
        }

        public int Length()
        {
            if (size == 0)
            {
                return 0;
            }
            return size;
        }



        public bool Contains(int el)
        {
            return (list.Contains(el)) ? true : false;
        }

        public int Get(int i)
        {
            if (i > size) throw new ArgumentOutOfRangeException("index does not exist");
            return list.ElementAt(i);
        }
        public bool binarySearch(int el)
        {
            int lo = 0; int hi = size - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (list.ElementAt(mid) == el) { return true; }
                else if (list.ElementAt(mid) < el) { lo = mid + 1; }
                else hi = mid - 1;
            }

            return false;
        }

        public void Add(int el)
        {
            list.AddLast(el);
            size++;
        }
        public void Remove(int el)
        {
            if (size == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            list.Remove(el);
            size--;
        }
        // considering 0 based indexing
        public void RemoveAt(int idx)
        {
            if (idx < 0 || idx > size) return;
            int i = 0;
            for (i = 0; i < idx; i++)
            {

            }
            int el = list.ElementAt(i);
            list.Remove(el);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }

        static void Main(string[] args)
        {
            MyLinkedList l = new MyLinkedList();
            Console.WriteLine("My LinkedList is Created");
            l.AddAtTail(1);
            l.AddAtTail(2);
            l.AddAtTail(3);
            l.AddAtTail(4);
            l.AddAtTail(5);
            for (int i = 0; i < l.count; i++)
            {
                Console.Write(l.Get(i) + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Changing Head of LinkedList");
            l.AddAtHead(6);
            for (int i = 0; i < l.count; i++)
            {
                Console.Write(l.Get(i) + " ");
            }
            Console.WriteLine();
            l.AddAtIndex(0, 10);
            Console.WriteLine("Adding 10 at 0th index of LinkedList");
            for (int i = 0; i < l.count; i++)
            {
                Console.Write(l.Get(i) + " ");
            }
            Console.WriteLine();
            l.DeleteAtIndex(0);
            Console.WriteLine("deleting 10 at 0th index of LinkedList");
            for (int i = 0; i < l.count; i++)
            {
                Console.Write(l.Get(i) + " ");
            }
            l.RemoveAll();
            Console.WriteLine();
            //l.RemoveAll();

            Console.Write(l.count);

            Console.WriteLine();
            MyArrayList al = new MyArrayList();

            al.Add(1);
            al.Add(2);
            al.Add(3);
            al.Add(4);
            al.Add(5);

            foreach (int i in al)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine(al.Contains(5));
            //Console.WriteLine(al.Get(6));
            bool b = al.binarySearch(4);
            Console.WriteLine(b);



            //2
            CustomArrayList cl = new CustomArrayList();
            Console.WriteLine(cl.Size());
            cl.Add(1);
            cl.Add(2);
            cl.Add(3);
            cl.Add(4);
            Console.WriteLine(cl.Size());
            cl.Add(5);
            Console.WriteLine(cl.Size());
            cl.Add(6);
            cl.Add(7);
            cl.Add(8);
            Console.WriteLine(cl.Size());
            //here is the ninth element
            cl.Add(9);
            Console.WriteLine(cl.Size());
            foreach (int i in cl)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            //cl.RemoveAt(2);
            //cl.RemoveAt(0);
            cl.ReplaceAt(0, 10);
            for (int i = 0; i < cl.cnt; i++)
            {
                Console.Write(cl.GetVal(i) + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < cl.cnt; i++)
            {
                Console.Write(cl.GetVal(i) + " ");
            }
            Console.WriteLine();
            bool ans = cl.Contains(8);
            cl.Sort();
            int ans2 = cl.BinarySearch(8);

            Console.WriteLine(ans);
            Console.WriteLine(ans2);

            Console.ReadLine();
        }


    }
}