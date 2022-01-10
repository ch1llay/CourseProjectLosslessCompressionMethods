using CourseProjectLosslessCompressionMethods.Methods.Deflate;
using CourseProjectLosslessCompressionMethods.Methods.Huffman;
using CourseProjectLosslessCompressionMethods.Methods.LZ77;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectLosslessCompressionMethods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GraphicResult graphicResult = new GraphicResult();
        string path;
        long huffmanTime;
        double huffmanDegree;
        long lz77Time;
        double lz77Degree;
        long deflateTime;
        double deflateDegree;
        private void button1_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            path = fileDialog.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void beginCompareButton_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            Huffman huffman = new Huffman();
            byte[] inputData = File.ReadAllBytes(path);

            stopwatch.Start();
            huffmanDegree = (double)huffman.Compress(inputData).Length / (double)inputData.Length;
            stopwatch.Stop();
            huffmanTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            LZ77 lZ77 = new LZ77(4095);
            stopwatch.Start();
            lz77Degree = (double)lZ77.Compress(inputData)/ (double)inputData.Length;
            stopwatch.Stop();
            lz77Time = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            stopwatch.Start();
            deflateDegree = (double)Deflate.Compress(path, path + ".deflate") / (double)inputData.Length;
            stopwatch.Stop();
            deflateTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();
            MessageBox.Show("Сравнение прошло успешно");


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showResultsInTable_Click(object sender, EventArgs e)
        {

        }

        private void showResultsInGraphic_Click(object sender, EventArgs e)
        {

            if (graphicResult.IsDisposed)
            {
                graphicResult = new GraphicResult();
                
            }
            
            //graphicResult = new GraphicResult();
            if (!graphicResult.IsHandleCreated)
            {
                graphicResult.AddData(huffmanTime, huffmanDegree, lz77Time, lz77Degree, deflateTime, deflateDegree);
                graphicResult.Show();
            }
            
        }
    }
}
