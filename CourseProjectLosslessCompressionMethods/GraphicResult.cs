using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProjectLosslessCompressionMethods
{
    public partial class GraphicResult : Form
    {

        public GraphicResult()
        {
            InitializeComponent();
        }
        long huffmanTime;
        double huffmanDegree;
        long lz77Time;
        double lz77Degree;
        long deflateTime;
        double deflateDegree;

        public void AddData(long huffmanTime, double huffmanDegree, long lz77Time, double lz77Degree, long deflateTime, double deflateDegree)
        {
            this.huffmanTime = huffmanTime;
            this.huffmanDegree = huffmanDegree;
            this.lz77Time = lz77Time;
            this.lz77Degree = lz77Degree;
            this.deflateTime = deflateTime;
            this.deflateDegree = deflateDegree;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GraphicResult_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Время сжатия", huffmanTime, lz77Time, deflateTime );
            dataGridView1.Rows.Add("Степень сжатия", huffmanDegree, lz77Degree, deflateDegree);


        }
    }
}
