﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseProjectLosslessCompressionMethods.Methods.Huffman;
using CourseProjectLosslessCompressionMethods.Methods.LZ77;
using CourseProjectLosslessCompressionMethods.Methods.Deflate;
using System.Windows.Forms;

namespace CourseProjectLosslessCompressionMethods
{
    
    
    class Test
    {
        [STAThreadAttribute]
        public static void Main()
        {
            //Huffman huffman = new Huffman();
            //string path = "Files/abra.txt";
            //FileDialog fileDialog = new OpenFileDialog();
            //fileDialog.ShowDialog();
            //path = fileDialog.FileName;
            //huffman.CompressFile(path);
            //LZ77 lz77 = new LZ77(12, 5 );
            //lz77.CompressFile(path);
            //huffman.CompressFile($"{path}.lz77");
            OptimazeLz77 optimazeLz77 = new OptimazeLz77(5, 8, "КРАСНАЯ КРАСКА");
            optimazeLz77.Coding();
        }
    }
}
