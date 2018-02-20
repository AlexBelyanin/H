namespace H
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
            this.SuperDinamicLayer_pb = new System.Windows.Forms.PictureBox();
            this.DinamicLayer_pb = new System.Windows.Forms.PictureBox();
            this.main_pb = new System.Windows.Forms.PictureBox();
            this.EditorComboBox = new System.Windows.Forms.ComboBox();
            this.EditorListBox = new System.Windows.Forms.ListBox();
            this.MapNameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SuperDinamicLayer_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DinamicLayer_pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_pb)).BeginInit();
            this.SuspendLayout();
            // 
            // SuperDinamicLayer_pb
            // 
            this.SuperDinamicLayer_pb.BackColor = System.Drawing.Color.Transparent;
            this.SuperDinamicLayer_pb.Location = new System.Drawing.Point(0, 0);
            this.SuperDinamicLayer_pb.Name = "SuperDinamicLayer_pb";
            this.SuperDinamicLayer_pb.Size = new System.Drawing.Size(68, 50);
            this.SuperDinamicLayer_pb.TabIndex = 4;
            this.SuperDinamicLayer_pb.TabStop = false;
            // 
            // DinamicLayer_pb
            // 
            this.DinamicLayer_pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DinamicLayer_pb.BackColor = System.Drawing.Color.Black;
            this.DinamicLayer_pb.Location = new System.Drawing.Point(0, 0);
            this.DinamicLayer_pb.Name = "DinamicLayer_pb";
            this.DinamicLayer_pb.Size = new System.Drawing.Size(414, 50);
            this.DinamicLayer_pb.TabIndex = 3;
            this.DinamicLayer_pb.TabStop = false;
            this.DinamicLayer_pb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DinamicLayer_MouseClick);
            // 
            // main_pb
            // 
            this.main_pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_pb.BackColor = System.Drawing.Color.White;
            this.main_pb.InitialImage = null;
            this.main_pb.Location = new System.Drawing.Point(0, 0);
            this.main_pb.Name = "main_pb";
            this.main_pb.Size = new System.Drawing.Size(796, 386);
            this.main_pb.TabIndex = 2;
            this.main_pb.TabStop = false;
            // 
            // EditorComboBox
            // 
            this.EditorComboBox.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditorComboBox.Location = new System.Drawing.Point(810, 51);
            this.EditorComboBox.Name = "EditorComboBox";
            this.EditorComboBox.Size = new System.Drawing.Size(161, 34);
            this.EditorComboBox.TabIndex = 5;
            this.EditorComboBox.SelectedIndexChanged += new System.EventHandler(this.EditorComboBox_SelectedIndexChanged);
            // 
            // EditorListBox
            // 
            this.EditorListBox.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditorListBox.ItemHeight = 26;
            this.EditorListBox.Location = new System.Drawing.Point(810, 91);
            this.EditorListBox.Name = "EditorListBox";
            this.EditorListBox.Size = new System.Drawing.Size(161, 186);
            this.EditorListBox.TabIndex = 6;
            // 
            // MapNameTextBox
            // 
            this.MapNameTextBox.Font = new System.Drawing.Font("Segoe Print", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MapNameTextBox.Location = new System.Drawing.Point(810, 11);
            this.MapNameTextBox.Name = "MapNameTextBox";
            this.MapNameTextBox.Size = new System.Drawing.Size(161, 34);
            this.MapNameTextBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(975, 384);
            this.Controls.Add(this.MapNameTextBox);
            this.Controls.Add(this.EditorListBox);
            this.Controls.Add(this.EditorComboBox);
            this.Controls.Add(this.SuperDinamicLayer_pb);
            this.Controls.Add(this.DinamicLayer_pb);
            this.Controls.Add(this.main_pb);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.SuperDinamicLayer_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DinamicLayer_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox main_pb;
        private System.Windows.Forms.PictureBox DinamicLayer_pb;
        private System.Windows.Forms.PictureBox SuperDinamicLayer_pb;
        private System.Windows.Forms.ComboBox EditorComboBox;
        private System.Windows.Forms.ListBox EditorListBox;
        private System.Windows.Forms.TextBox MapNameTextBox;
    }
}

