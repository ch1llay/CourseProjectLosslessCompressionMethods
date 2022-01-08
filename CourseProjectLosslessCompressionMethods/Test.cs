using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProjectLosslessCompressionMethods.Methods.Huffman;
using CourseProjectLosslessCompressionMethods.Methods.LZ77;
using System.Windows.Forms;
using CourseProjectLosslessCompressionMethods.Methods.Deflate;

namespace CourseProjectLosslessCompressionMethods
{
    
    
    class Test
    {
        [STAThreadAttribute]
        public static void Main()
        {
            Huffman huffman = new Huffman();
            string path = "Files/abra.txt";
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            path = fileDialog.FileName;
            huffman.CompressFile(path);
            LZ77 LZ77 = new LZ77(2048);
            Console.WriteLine($"LZ77 {LZ77.Compress(path)}");
            // Deflate deflate = new Deflate();
            Console.WriteLine(Deflate.Compress(path, path + ".deflate"));
        }
    }
}
