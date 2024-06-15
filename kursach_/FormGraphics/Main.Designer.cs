namespace kursach_
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainLogo = new System.Windows.Forms.Label();
            this.Graphic1 = new System.Windows.Forms.Button();
            this.WeekEvent = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.MainLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 100);
            this.panel1.TabIndex = 0;
            // 
            // MainLogo
            // 
            this.MainLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLogo.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainLogo.Location = new System.Drawing.Point(0, 0);
            this.MainLogo.Name = "MainLogo";
            this.MainLogo.Size = new System.Drawing.Size(775, 100);
            this.MainLogo.TabIndex = 0;
            this.MainLogo.Text = "Система выгрузки";
            this.MainLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MainLogo.Click += new System.EventHandler(this.MainLogo_Click);
            // 
            // Graphic1
            // 
            this.Graphic1.BackColor = System.Drawing.Color.DarkCyan;
            this.Graphic1.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.Graphic1.FlatAppearance.BorderSize = 0;
            this.Graphic1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Graphic1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Graphic1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Graphic1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Graphic1.Location = new System.Drawing.Point(60, 222);
            this.Graphic1.Name = "Graphic1";
            this.Graphic1.Size = new System.Drawing.Size(165, 54);
            this.Graphic1.TabIndex = 1;
            this.Graphic1.Text = "Дневная выгрузка";
            this.Graphic1.UseVisualStyleBackColor = false;
            this.Graphic1.Click += new System.EventHandler(this.Graphic1_Click);
            // 
            // WeekEvent
            // 
            this.WeekEvent.BackColor = System.Drawing.Color.PapayaWhip;
            this.WeekEvent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.WeekEvent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.WeekEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WeekEvent.Location = new System.Drawing.Point(309, 222);
            this.WeekEvent.Name = "WeekEvent";
            this.WeekEvent.Size = new System.Drawing.Size(165, 54);
            this.WeekEvent.TabIndex = 2;
            this.WeekEvent.Text = "Выгрузка за неделю";
            this.WeekEvent.UseVisualStyleBackColor = false;
            this.WeekEvent.Click += new System.EventHandler(this.Graphic2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkKhaki;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(556, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сравнение с оптимальным";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kursach_.Properties.Resources._2998144_eco_growth_plant_science_sprout_icon;
            this.pictureBox1.Location = new System.Drawing.Point(675, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 409);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.WeekEvent);
            this.Controls.Add(this.Graphic1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "BiologyDB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MainLogo;
        private System.Windows.Forms.Button Graphic1;
        private System.Windows.Forms.Button WeekEvent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

