namespace RecognizeWinApp
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox53 = new System.Windows.Forms.PictureBox();
            this.pictureBox52 = new System.Windows.Forms.PictureBox();
            this.pictureBox49 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox49)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 400);
            this.panel3.TabIndex = 0;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(507, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(436, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Compute";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(507, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Train";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Push to data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.pictureBox53);
            this.panel4.Controls.Add(this.pictureBox52);
            this.panel4.Controls.Add(this.pictureBox49);
            this.panel4.Location = new System.Drawing.Point(507, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(81, 27);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox53
            // 
            this.pictureBox53.BackColor = System.Drawing.Color.Red;
            this.pictureBox53.Location = new System.Drawing.Point(55, 3);
            this.pictureBox53.Name = "pictureBox53";
            this.pictureBox53.Size = new System.Drawing.Size(20, 20);
            this.pictureBox53.TabIndex = 4;
            this.pictureBox53.TabStop = false;
            this.pictureBox53.Click += new System.EventHandler(this.pictureBox53_Click);
            // 
            // pictureBox52
            // 
            this.pictureBox52.BackColor = System.Drawing.Color.Blue;
            this.pictureBox52.Location = new System.Drawing.Point(29, 3);
            this.pictureBox52.Name = "pictureBox52";
            this.pictureBox52.Size = new System.Drawing.Size(20, 20);
            this.pictureBox52.TabIndex = 3;
            this.pictureBox52.TabStop = false;
            this.pictureBox52.Click += new System.EventHandler(this.pictureBox52_Click);
            // 
            // pictureBox49
            // 
            this.pictureBox49.BackColor = System.Drawing.Color.Black;
            this.pictureBox49.Location = new System.Drawing.Point(3, 3);
            this.pictureBox49.Name = "pictureBox49";
            this.pictureBox49.Size = new System.Drawing.Size(20, 20);
            this.pictureBox49.TabIndex = 0;
            this.pictureBox49.TabStop = false;
            this.pictureBox49.Click += new System.EventHandler(this.pictureBox49_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(601, 401);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.Text = "RecognizeApp";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox49)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox49;
        private System.Windows.Forms.PictureBox pictureBox53;
        private System.Windows.Forms.PictureBox pictureBox52;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

