using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProjectLosslessCompressionMethods.Methods.Huffman;
using CourseProjectLosslessCompressionMethods.Methods.LZ77;
using CourseProjectLosslessCompressionMethods.Methods.Deflate;

namespace CourseProjectLosslessCompressionMethods
{
    
    
    class Test
    {
        public static void Main()
        {
            Huffman huffman = new Huffman();
            huffman.CompressFile("Files/abra.txt");
        }
    }
}
