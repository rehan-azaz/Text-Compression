using System;
using System.Collections.Generic;
using System.Text;

namespace HuffmanCoding
{
    public class HuffmanCoding
    {
        PriorityQueue<string> Q = new PriorityQueue<string>();
        List<HuffmanNode> nList = new List<HuffmanNode>();

        public void Compress(string text)
        {
            HuffmanNode node = new HuffmanNode();
            List<HuffmanNode> nodeList = node.GetList(text);
            PriorityQueue<string> PQ = new PriorityQueue<string>();
            foreach (HuffmanNode n in nodeList)
            {
                PQ.Enqueue(n);
            }
            int size = PQ.Size;
            PQ.DisplayTree();
            PQ.Display();

            while (size >= 1)
            {
                HuffmanNode hNode = new HuffmanNode();
                HuffmanNode a = new HuffmanNode();
                HuffmanNode b = new HuffmanNode();
                if (!PQ.isEmpty())
                    a = PQ.Dequeue();
                if (!PQ.isEmpty())
                    b = PQ.Dequeue();
                bool isA = true;
                bool isB = true;
                foreach (HuffmanNode n in nList)
                {
                    if (n == a)
                    {
                        isA = false;
                    }
                    if (n == b)
                    {
                        isB = false;
                    }
                }

                if (isA && a.Symbol != null)
                    nList.Add(a);
                if (isB && b.Symbol != null)
                    nList.Add(b);

                hNode.Left = a;
                hNode.Right = b;

                hNode.Frequency = a.Frequency + b.Frequency;
                hNode.Symbol = a.Symbol + b.Symbol;
                hNode.Left.Parent = hNode.Left.Parent = hNode;
                PQ.Enqueue(hNode);
                size--;
            }
            AssignCode(nList[0].Code, nList[0]);

        }

        public void AssignCode(string code, HuffmanNode node)
        {
            if (node == null)
                return;
            if (node.Left == null && node.Right == null)
            {
                node.Code = code;
                return;
            }
            AssignCode(code + "0", node.Left);
            AssignCode(code + "1", node.Right);
            return;
        }

        public void Display()
        {
            Console.WriteLine("Symbols,\tFrequency");
            foreach (HuffmanNode n in nList)
            {
                Console.WriteLine(n.Symbol + " , " + n.Frequency + "\n");
            }
        }

        public void DisplayTree()
        { 
            Console.WriteLine("\tFrequency Tree");
            List<HuffmanNode> n = nList;
            int i = 0;

            while (n[i].Left != null || n[i].Right != null)
            {
                Console.WriteLine(n[i].Frequency+"\n");
                Console.WriteLine(n[i].Left.Frequency+"\t");
                Console.WriteLine(n[i].Right.Frequency+"\n");
                i++;
            }
        }
        public void DisplayCodes()
        {
            Console.WriteLine("Symbols,\t\tFrequency,\tCode");
            foreach (HuffmanNode n in nList)
            {
                if (n.Code != null)
                    Console.WriteLine(n.Symbol + ",\t\t\t" + n.Frequency + ",\t\t" + n.Code + "\n");
            }
        }
    }
}
