using System;
using System.Collections.Generic;
using System.Text;


namespace HuffmanCoding
{
    
    public class PriorityQueue<T> where T : IComparable
    {
        
        int heapSize = -1;
        List<HuffmanNode> nodes = new List<HuffmanNode>();
        public int Size
        {
            get
            {
                return nodes.Count;
            }
        }
        private void Swap(int i, int j)
        {
            var temp = nodes[i];
            nodes[i] = nodes[j];
            nodes[j] = temp;
        }
        private int LeftChild(int i)
        {
            return i * 2 + 1;
        }
        private int RightChild(int i)
        {
            return i * 2 + 2;
        }

        private void MinHeapify(int i)
        {
            int left = LeftChild(i);
            int right =RightChild(i);

            int smallest = i;

            if (left <= heapSize && nodes[smallest].Frequency > nodes[left].Frequency)
                smallest = left;
            if (right <= heapSize && nodes[smallest].Frequency > nodes[right].Frequency)
                smallest = right;

            if (smallest != i)
            {
                Swap(smallest, i);
                MinHeapify(smallest);
            }
        }

        private void BuildHeap(int i)
        {
            while (i >= 0 && nodes[(i - 1) / 2].Frequency > nodes[i].Frequency)
            {
                Swap(i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }
        public void Enqueue(HuffmanNode n)
        {
            nodes.Add(n);
            heapSize++;
            BuildHeap(heapSize);
        }
        public HuffmanNode Dequeue()
        {
            if (heapSize > -1)
            {
                var s = nodes[0];
                nodes[0] = nodes[heapSize];
                nodes.RemoveAt(heapSize);
                heapSize--;
                MinHeapify(0);
                return s;
            }
            else
                throw new Exception("Queue is empty");
        }
        
        public void Display()
        {
            Console.WriteLine("Symbols , Frequency");
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine(nodes[i].Symbol+" , "+nodes[i].Frequency);
            }

        }
        public bool isEmpty()
        {
            return (Size == 0) ? true:false;
        }
    }
}
