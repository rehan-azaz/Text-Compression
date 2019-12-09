using System;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"E:\Desktop\Fall2019\AOA\FCP\FileCompressionCode\FileCompressionCode\input.txt");
            string orignalText = text;


            HuffmanCoding hc = new HuffmanCoding();
            hc.Compress(text);
            hc.DisplayTree();
        }
    }
}
