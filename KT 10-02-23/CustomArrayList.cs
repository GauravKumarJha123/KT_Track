using System;
using System.Collections;

namespace KT_10_02_23
{
    internal class CustomArrayList : IEnumerable
    {
        public int cnt;
        private int[] a;
        private int i;
        public CustomArrayList()
        {
            cnt = 0;
            a = new int[0];
            i = 0;
        }


        public void Add(int v)
        {
            if (cnt == 0)
            {
                Array.Resize(ref a, 4);
                a[0] = v;
                i++;
                cnt++;
            }
            else
            {
                cnt++;
                if (cnt > a.Length)
                {
                    Array.Resize(ref a, a.Length * 2);
                }
                a[i++] = v;

            }
        }
        public int Size()

        {
            return a.Length;
        }

        public int GetVal(int idx)
        {
            return a[idx];
        }
        public void ReplaceAt(int idx, int v)
        {
            a[idx] = v;
        }

        public void RemoveAt(int idx)
        {
            if (idx == 0)
            {
                for (int i = 0; i < cnt - 1; i++)
                {
                    a[i] = a[i + 1];
                }
                cnt--;
            }
            else
            {
                for (int i = idx - 1; i < cnt - 1; i++)
                {
                    a[i] = a[i + 1];
                }
                cnt--;
            }
        }
        /// <summary>
        /// Return wheteher list contains the numbers or not
        /// </summary>
        /// <param name="el">the el represents and integer element inside arraylist</param>
        /// <returns>Returns -1 in case el is not there else it's position</returns>
        public int BinarySearch(int el)
        {

            // 16 - 9 => 7
            int totalZeroCount = a.Length - cnt;

            int i = 0, j = a.Length - 1;
            while (i <= j)
            {
                int mid = i + (j - i) / 2;
                // for 8 mit is 13 --> 0 0 0 0 0 0 0 2 3 4 5 6 7 8 9 10
                // thus 13 - 7 => 6 in 0 based indexing
                if (a[mid] == el) return mid - totalZeroCount;
                else if (a[mid] < el) i = mid + 1;
                else j = mid - 1;
            }
            return -1;
        }
        public bool Contains(int el)
        {
            for (int i = 0; i < cnt; i++)
            {
                if (a[i] == el) return true;
            }
            return false;
        }
        public void Sort()
        {
            Array.Sort(a);
        }

        public IEnumerator GetEnumerator()
        {
            return a.GetEnumerator();
        }
    }


}