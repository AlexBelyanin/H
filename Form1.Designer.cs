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
            this.DinamicLayer_pb.BackColor = System.Drawing.Color.Transparent;
            this.DinamicLayer_pb.Location = new System.Drawing.Point(0, 0);
            this.DinamicLayer_pb.Name = "DinamicLayer_pb";
            this.DinamicLayer_pb.Size = new System.Drawing.Size(100, 50);
            this.DinamicLayer_pb.TabIndex = 3;
            this.DinamicLayer_pb.TabStop = false;
            // 
            // main_pb
            // 
            this.main_pb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_pb.BackColor = System.Drawing.Color.White;
            this.main_pb.InitialImage = null;
            this.main_pb.Location = new System.Drawing.Point(0, -1);
            this.main_pb.Name = "main_pb";
            this.main_pb.Size = new System.Drawing.Size(482, 386);
            this.main_pb.TabIndex = 2;
            this.main_pb.TabStop = false;
            this.main_pb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.main_pb_MouseClick);
            this.main_pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.main_pb_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(661, 384);
            this.Controls.Add(this.SuperDinamicLayer_pb);
            this.Controls.Add(this.DinamicLayer_pb);
            this.Controls.Add(this.main_pb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SuperDinamicLayer_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DinamicLayer_pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox main_pb;
        private System.Windows.Forms.PictureBox DinamicLayer_pb;
        private System.Windows.Forms.PictureBox SuperDinamicLayer_pb;
    }
}

