using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProjectLosslessCompressionMethods.Methods.Huffman;
using CourseProjectLosslessCompressionMethods.Methods.LZ77;
using System.Windows.Forms;

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
            LZ77 optimazeLz77 = new LZ77(1 << 12);
            optimazeLz77.CompressFile(path);
            huffman.CompressFile($"{path}.lz77");
        }
    }
}
