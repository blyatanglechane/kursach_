namespace kursach_
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Graphic1 = new System.Windows.Forms.Button();
            this.Graphic2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(775, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Построение графиков";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Graphic1
            // 
            this.Graphic1.BackColor = System.Drawing.Color.DarkCyan;
            this.Graphic1.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.Graphic1.FlatAppearance.BorderSize = 0;
            this.Graphic1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Graphic1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Graphic1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Graphic1.Location = new System.Drawing.Point(102, 222);
            this.Graphic1.Name = "Graphic1";
            this.Graphic1.Size = new System.Drawing.Size(165, 54);
            this.Graphic1.TabIndex = 1;
            this.Graphic1.Text = "Graphic1";
            this.Graphic1.UseVisualStyleBackColor = false;
            this.Graphic1.Click += new System.EventHandler(this.Graphic1_Click);
            // 
            // Graphic2
            // 
            this.Graphic2.BackColor = System.Drawing.Color.DarkKhaki;
            this.Graphic2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.Graphic2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Graphic2.Location = new System.Drawing.Point(528, 222);
            this.Graphic2.Name = "Graphic2";
            this.Graphic2.Size = new System.Drawing.Size(165, 54);
            this.Graphic2.TabIndex = 2;
            this.Graphic2.Text = "Graphic2";
            this.Graphic2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 409);
            this.Controls.Add(this.Graphic2);
            this.Controls.Add(this.Graphic1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "ProgramGraphic";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Graphic1;
        private System.Windows.Forms.Button Graphic2;
    }
}

