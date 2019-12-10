using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Coding
{
    public class HuffmanNode
    {
        string symbol;
        int frequency;
        string code;
        HuffmanNode left;
        HuffmanNode right;
        HuffmanNode parent;
        List<HuffmanNode> nodes = new List<HuffmanNode>();
        int Size
        {
            get
            {
                return nodes.Count;
            }
        }
        public HuffmanNode()
        {
        }
        public HuffmanNode(string c, int f)
        {
            this.Symbol = c;
            this.Frequency = f;
        }

        public HuffmanNode(string symbol, int frequency, string code, HuffmanNode left, HuffmanNode right, HuffmanNode parent)
        {
            this.Symbol = symbol;
            this.Frequency = frequency;
            this.Code = code;
            this.Left = left;
            this.Right = right;
            this.Parent = parent;
        }


        public string Symbol { get => symbol; set => symbol = value; }
        public int Frequency { get => frequency; set => frequency = value; }
        public string Code { get => code; set => this.code = value; }
        internal HuffmanNode Left { get => left; set => left = value; }
        internal HuffmanNode Right { get => right; set => right = value; }
        internal HuffmanNode Parent { get => parent; set => parent = value; }
        public List<HuffmanNode> GetList(string text)
        {
            var charsToRemove = new string[] { "\n", "\r" };
            foreach (var c in charsToRemove)
            {
                text = text.Replace(c, string.Empty);
            }

            for (int i = 0; i < text.Length; i++)
            {
                HuffmanNode n = new HuffmanNode();
                n.symbol = text[i].ToString();
                n.frequency++;
                bool flag = false;
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (n.symbol == nodes[j].symbol)
                    {
                        flag = true;
                    }
                }
                if (!flag)
                {
                    nodes.Add(n);
                }
                else
                {
                    for (int q = 0; q < nodes.Count; q++)
                    {
                        if (nodes[q].symbol == text[i].ToString())
                        {
                            nodes[q].frequency++;
                        }
                    }
                }
            }
            return this.nodes;
        }
        public void Display()
        {
            Console.WriteLine(nodes.Count);
            Console.WriteLine("Symbol,\tFrequency");
            foreach (HuffmanNode n in nodes)
            {
                Console.WriteLine(n.Symbol + ",\t" + n.Frequency);
            }
        }
    }

} 
}
