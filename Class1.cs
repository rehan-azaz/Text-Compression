using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Compression
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
			nList.Reverse();
			foreach (HuffmanNode n in nList)
			{
				AssignCode();
			}

		}

		void AssignCode()
		{
			for (int i = 0; i < nList.Count && nList[i].Left != null && nList[i].Right != null; i++)
			{
				nList[i].Left.Code += "0";
				nList[i].Right.Code += "1";
			}
		}
		public void Display()
		{
			Console.WriteLine("Symbols,\tFrequency");
			foreach (HuffmanNode n in nList)
			{
				Console.WriteLine(n.Symbol + " , " + n.Frequency + "\n");
			}
		}
		public void DisplayCodes()
		{
			Console.WriteLine("Symbols,\tFrequency,\tCode");
			foreach (HuffmanNode n in nList)
			{
				Console.WriteLine(n.Symbol + ",\t\t" + n.Frequency + ",\t\t" + n.Code + "\n");
			}
		}
	}

}

