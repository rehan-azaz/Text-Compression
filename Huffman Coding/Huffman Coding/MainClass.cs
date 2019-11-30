using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_Coding
{
    class MainClass
    {
        public static void setColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void setColorDefault()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)
        {
            List<ImpNode> node;
            Tree ptree = new Tree();
            while(true)
            {
                Console.Clear();
                node = ptree.getlistfromfile();
                Console.Clear();
                if(node==null)
                {
                    Console.WriteLine("File canoot be read! ");
                    Console.WriteLine("Press the any key to continue or Enter \"E\" to exit the program");
                    string c = Console.ReadLine();
                    if (c.ToLower() == "e")
                    {
                        break;
                    }
                    else
                        continue;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Symbols  .... Frequency");
                    ptree.info(node);
                    ptree.Treelist(node);
                    ptree.Code("", node[0]);
                    Console.WriteLine(" Huffman Code Created Tree \n");
                    ptree.printtree(0, node[0]);
                    Console.WriteLine("Symbols-------Code");
                    ptree.codesinleaf(node[0]);
                    Console.WriteLine("/n");
                    Console.WriteLine("Press the any key to continue or Enter \"E\" to exit the program");
                    string name = Console.ReadLine();
                    if (name.ToLower()=="e")
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
        }

    }
}
