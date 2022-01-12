
namespace CourseProjectLosslessCompressionMethods
{
    partial class GraphicResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.algorithmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.huffmanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lz77Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeflateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.algorithmName,
            this.huffmanColumn,
            this.lz77Column,
            this.DeflateColumn});
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(652, 112);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // algorithmName
            // 
            this.algorithmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.algorithmName.HeaderText = "Алгоритм";
            this.algorithmName.Name = "algorithmName";
            // 
            // huffmanColumn
            // 
            this.huffmanColumn.HeaderText = "Хаффман";
            this.huffmanColumn.Name = "huffmanColumn";
            // 
            // lz77Column
            // 
            this.lz77Column.HeaderText = "LZ77";
            this.lz77Column.Name = "lz77Column";
            // 
            // DeflateColumn
            // 
            this.DeflateColumn.HeaderText = "Deflate";
            this.DeflateColumn.Name = "DeflateColumn";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Сравнение по времени";
            legend1.Title = "Сравнение по времени";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 156);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Сравнение по времени";
            series1.Name = "Хаффман";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Сравнение по времени";
            series2.Name = "LZ77";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Сравнение по времени";
            series3.Name = "Deflate";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(652, 186);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "Сравнение по времени";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Сравнение по степени сжатия";
            legend2.Title = "Сравнение по времени";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 348);
            this.chart2.Name = "chart2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Сравнение по степени сжатия";
            series4.Name = "Хаффман";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Сравнение по степени сжатия";
            series5.Name = "LZ77";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Сравнение по степени сжатия";
            series6.Name = "Deflate";
            this.chart2.Series.Add(series4);
            this.chart2.Series.Add(series5);
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(652, 186);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "Сравнение по времени";
            // 
            // GraphicResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 538);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GraphicResult";
            this.Text = "GraphicResult";
            this.Load += new System.EventHandler(this.GraphicResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn algorithmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn huffmanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lz77Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeflateColumn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}