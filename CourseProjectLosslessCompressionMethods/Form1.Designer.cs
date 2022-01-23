
namespace CourseProjectLosslessCompressionMethods
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.importFilesButton = new System.Windows.Forms.Button();
            this.beginCompareButton = new System.Windows.Forms.Button();
            this.showResultsInGraphic = new System.Windows.Forms.Button();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // importFilesButton
            // 
            this.importFilesButton.Location = new System.Drawing.Point(1, 1);
            this.importFilesButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.importFilesButton.Name = "importFilesButton";
            this.importFilesButton.Size = new System.Drawing.Size(165, 83);
            this.importFilesButton.TabIndex = 0;
            this.importFilesButton.Text = "Импортировать файл";
            this.importFilesButton.UseVisualStyleBackColor = true;
            this.importFilesButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // beginCompareButton
            // 
            this.beginCompareButton.Enabled = false;
            this.beginCompareButton.Location = new System.Drawing.Point(175, 3);
            this.beginCompareButton.Name = "beginCompareButton";
            this.beginCompareButton.Size = new System.Drawing.Size(262, 78);
            this.beginCompareButton.TabIndex = 1;
            this.beginCompareButton.Text = "Начать сравнение";
            this.beginCompareButton.UseVisualStyleBackColor = true;
            this.beginCompareButton.Click += new System.EventHandler(this.beginCompareButton_Click);
            // 
            // showResultsInGraphic
            // 
            this.showResultsInGraphic.Enabled = false;
            this.showResultsInGraphic.Location = new System.Drawing.Point(1, 136);
            this.showResultsInGraphic.Name = "showResultsInGraphic";
            this.showResultsInGraphic.Size = new System.Drawing.Size(436, 84);
            this.showResultsInGraphic.TabIndex = 3;
            this.showResultsInGraphic.Text = "Отобразить результаты";
            this.showResultsInGraphic.UseVisualStyleBackColor = true;
            this.showResultsInGraphic.Click += new System.EventHandler(this.showResultsInGraphic_Click);
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(12, 98);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(263, 24);
            this.fileNameLabel.TabIndex = 4;
            this.fileNameLabel.Text = "Файл для сжатия не выбран";
            this.fileNameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(449, 234);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.beginCompareButton);
            this.Controls.Add(this.showResultsInGraphic);
            this.Controls.Add(this.importFilesButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "Чапаев Илья 20ВП1 Неискажающие алгоритмы сжатия";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importFilesButton;
        private System.Windows.Forms.Button beginCompareButton;
        private System.Windows.Forms.Button showResultsInGraphic;
        private System.Windows.Forms.Label fileNameLabel;
    }
}

