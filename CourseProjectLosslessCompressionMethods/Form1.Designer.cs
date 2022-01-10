
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
            this.SuspendLayout();
            // 
            // importFilesButton
            // 
            this.importFilesButton.Location = new System.Drawing.Point(15, 5);
            this.importFilesButton.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.importFilesButton.Name = "importFilesButton";
            this.importFilesButton.Size = new System.Drawing.Size(322, 147);
            this.importFilesButton.TabIndex = 0;
            this.importFilesButton.Text = "Импортировать файлы";
            this.importFilesButton.UseVisualStyleBackColor = true;
            this.importFilesButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // beginCompareButton
            // 
            this.beginCompareButton.Location = new System.Drawing.Point(28, 160);
            this.beginCompareButton.Name = "beginCompareButton";
            this.beginCompareButton.Size = new System.Drawing.Size(179, 68);
            this.beginCompareButton.TabIndex = 1;
            this.beginCompareButton.Text = "Начать сравнение";
            this.beginCompareButton.UseVisualStyleBackColor = true;
            this.beginCompareButton.Click += new System.EventHandler(this.beginCompareButton_Click);
            // 
            // showResultsInGraphic
            // 
            this.showResultsInGraphic.Location = new System.Drawing.Point(346, 20);
            this.showResultsInGraphic.Name = "showResultsInGraphic";
            this.showResultsInGraphic.Size = new System.Drawing.Size(194, 132);
            this.showResultsInGraphic.TabIndex = 3;
            this.showResultsInGraphic.Text = "Отобразить результаты";
            this.showResultsInGraphic.UseVisualStyleBackColor = true;
            this.showResultsInGraphic.Click += new System.EventHandler(this.showResultsInGraphic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(818, 648);
            this.Controls.Add(this.beginCompareButton);
            this.Controls.Add(this.showResultsInGraphic);
            this.Controls.Add(this.importFilesButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "Чапаев Илья 20ВП1 Неискажающие алгоритмы сжатия";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button importFilesButton;
        private System.Windows.Forms.Button beginCompareButton;
        private System.Windows.Forms.Button showResultsInGraphic;
    }
}

