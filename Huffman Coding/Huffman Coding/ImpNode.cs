using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Coding
{
    class ImpNode:IComparable<ImpNode>
    {
        public string symbol;
        public int frequency;
        public string code;
        public ImpNode parent;
        public ImpNode right;
        public ImpNode left;
        public bool leaf;

        public ImpNode(string input)
        {
            symbol = input;
            frequency = 1;
            parent = null;
            right = null;
            left = null;
            leaf = true;
            code = "";


        }
        public ImpNode(ImpNode n1, ImpNode n2)
        {
            leaf = false;
            parent = null;
            code = "";
            if (n1.frequency >= n2.frequency)
            {
                right = n1;
                left = n2;
                right.parent = left.parent = this;
                symbol = n1.symbol + n2.symbol;
                frequency = n1.frequency + n2.frequency;
            }
            else if (n1.frequency < n2.frequency)
            {
                right = n2;
                left = n1;
                left.parent = right.parent = this;
                symbol = n1.symbol + n2.symbol;
                frequency = n1.frequency + n2.frequency;

            }

        }
        public int CompareTo(ImpNode node)
        {
            return this.frequency.CompareTo(node.frequency);
        }
        public void increaseinFrequency()
        {
            frequency++;
        }

    }  
}
