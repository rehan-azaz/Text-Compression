using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Huffman_Coding
{
    class Tree
    {
        public List<ImpNode> getlistfromfile()        
        {
            List<ImpNode> node = new List<ImpNode>();
             
            string name = @"C:\Users\I'm Libra\source\repos\Huffman Coding\tree.txt";



            try
            {
                FileStream file = new FileStream(name, FileMode.Open, FileAccess.Read);
                for(int j=0;j<file.Length;j++)
                {
                    string onlyread = Convert.ToChar(file.ReadByte()).ToString();
                    if (node.Exists(x => x.symbol == onlyread))
                        node[node.FindIndex(y => y.symbol == onlyread)].increaseinFrequency();
                    else
                        node.Add(new ImpNode(onlyread));
                }
                node.Sort();
                return node;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public void Treelist(List<ImpNode> nodes)
        {
            while(nodes.Count>1)
            {
                ImpNode node = nodes[0];
                nodes.RemoveAt(0);
                ImpNode n = nodes[0];
                nodes.RemoveAt(0);
                nodes.Add(new ImpNode(node, n));
                nodes.Sort();
            }
        }
        public void Code(string code, ImpNode node)
        {
            if (node==null)
            {
                return;
            }
            if (node.left == null && node.right== null)
            {
                node.code = code;
                return;
            }
            Code(code + "0", node.left);
            Code(code + "1", node.right);



        }
        public void printtree(int level, ImpNode node)
        {
            if (node== null)
            {
                return;
            }
            for(int k=0;k<level;k++)
            {
                Console.Write("\t");
            }
            Console.Write("[" + node.symbol + "]");
            Console.WriteLine("(" + node.code + ")");
            printtree(level + 1, node.right);
            printtree(level + 1, node.left);
        }
        public void info(List<ImpNode> node)
        {
            foreach(var x in node)
            {
                Console.WriteLine("Symbol: {0} - Frequency : {1}", x.symbol, x.frequency);
            }
        }
        public void codesinleaf(ImpNode node)
        {
            if (node==null)
            {
                return;
            }
            if (node.left == null && node.right == null)
            {
                Console.WriteLine("Symbol : {0} -  Code : {1}", node.symbol, node.code);
                return;
            }
            codesinleaf(node.left);
            codesinleaf(node.right);
        }
    }
}
