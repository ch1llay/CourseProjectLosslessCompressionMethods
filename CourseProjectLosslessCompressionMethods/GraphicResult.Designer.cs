
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.algorithmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.huffmanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lz77Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeflateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // GraphicResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 460);
            this.Controls.Add(this.dataGridView1);
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "GraphicResult";
            this.Text = "GraphicResult";
            this.Load += new System.EventHandler(this.GraphicResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn algorithmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn huffmanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lz77Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeflateColumn;
    }
}