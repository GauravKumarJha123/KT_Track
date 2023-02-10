using System;

namespace KT_10_02_23
{
    public class Node
    {
        public int val;
        public Node next;
        public Node(int v)
        {
            this.val = v;
        }
    }
    public class MyLinkedList
    {

        Node head;
        public int count;

        public MyLinkedList()
        {
            this.head = null;
            this.count = 0;
        }
        /*public void Adddiff(int el)
        {
            if (count == 0)
            {
                head = new Node(el);
            }
            head.next = new Node(el);
            count++;
        }*/

        public int Get(int idx)
        {
            Node node = GetNode(idx);
            return node == null ? -1 : node.val;
        }

        public Node GetNode(int idx)
        {
            if (idx >= count)
            {
                return null;
            }
            Node curr = head;
            for (int i = 0; i < idx; i++)
            {
                curr = curr.next;
            }
            return curr;
        }
        public void AddAtHead(int val)
        {
            Node newNode = new Node(val);
            newNode.next = head;
            head = newNode;
            count++;
        }
        public void AddAtTail(int val)
        {
            if (head == null)
            {
                AddAtHead(val);
                return;
            }
            Node node = GetNode(count - 1);
            node.next = new Node(val);
            count++;
        }
        public void AddAtIndex(int idx, int val)
        {
            if (idx > count)
            {
                return;
            }
            if (idx == 0)
            {
                AddAtHead(val);
                return;
            }
            Node node = GetNode(idx - 1);
            Node newNode = new Node(val);
            newNode.next = node.next;
            node.next = newNode;
            count++;
        }
        // 1 based indexing lets say 4 then 3
        public void DeleteAtIndex(int idx)
        {
            if (count == 0) return;
            if (idx < count && idx >= 0)
            {
                if (idx == 0)
                {
                    head = head.next;
                }
                else
                {
                    Node node = GetNode(idx - 1);
                    node.next = node.next.next;
                }
                count--;
            }
        }
        public void RemoveAll()
        {
            if (count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            head = null;
            count = 0;

        }



        /*public void Reverse(Node head)
        {
            if (head == null || head.next == null) return;

            Node curr = head, prev = null;
            while(curr != null)
            {
                Node temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }   
        }*/

    }


}