using System;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\rhn20\source\repos\ConsoleApp1\ConsoleApp1\input.txt");
            string orignalText = text;
        
            
            HuffmanCoding hc = new HuffmanCoding();
            hc.Compress(text);
            hc.DisplayCodes();
        }
    }
}
