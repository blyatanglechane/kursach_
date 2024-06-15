namespace kursach_.FormGraphics
{
    partial class FormGraphics2
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
            this.IDInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FCsInput = new System.Windows.Forms.TextBox();
            this.ButtonIDEvent = new System.Windows.Forms.Button();
            this.ButtonFCsEvent = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // IDInput
            // 
            this.IDInput.Font = new System.Drawing.Font("Comic Sans MS", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IDInput.Location = new System.Drawing.Point(98, 133);
            this.IDInput.Multiline = true;
            this.IDInput.Name = "IDInput";
            this.IDInput.Size = new System.Drawing.Size(246, 63);
            this.IDInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите ID студента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите ФИО студента";
            // 
            // FCsInput
            // 
            this.FCsInput.Font = new System.Drawing.Font("Comic Sans MS", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FCsInput.Location = new System.Drawing.Point(443, 133);
            this.FCsInput.Multiline = true;
            this.FCsInput.Name = "FCsInput";
            this.FCsInput.Size = new System.Drawing.Size(246, 63);
            this.FCsInput.TabIndex = 3;
            // 
            // ButtonIDEvent
            // 
            this.ButtonIDEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonIDEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonIDEvent.Location = new System.Drawing.Point(148, 231);
            this.ButtonIDEvent.Name = "ButtonIDEvent";
            this.ButtonIDEvent.Size = new System.Drawing.Size(162, 37);
            this.ButtonIDEvent.TabIndex = 4;
            this.ButtonIDEvent.Text = "Выгрузить по ID";
            this.ButtonIDEvent.UseVisualStyleBackColor = true;
            this.ButtonIDEvent.Click += new System.EventHandler(this.ButtonIDEvent_Click);
            // 
            // ButtonFCsEvent
            // 
            this.ButtonFCsEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFCsEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonFCsEvent.Location = new System.Drawing.Point(488, 231);
            this.ButtonFCsEvent.Name = "ButtonFCsEvent";
            this.ButtonFCsEvent.Size = new System.Drawing.Size(176, 37);
            this.ButtonFCsEvent.TabIndex = 5;
            this.ButtonFCsEvent.Text = "Выгрузить по ФИО";
            this.ButtonFCsEvent.UseVisualStyleBackColor = true;
            this.ButtonFCsEvent.Click += new System.EventHandler(this.ButtonFCsEvent_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::kursach_.Properties.Resources._290119_card_id_identification_identity_profile_icon;
            this.pictureBox2.Location = new System.Drawing.Point(374, 133);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kursach_.Properties.Resources._172487_key_icon;
            this.pictureBox1.Location = new System.Drawing.Point(29, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FormGraphics2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 357);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ButtonFCsEvent);
            this.Controls.Add(this.ButtonIDEvent);
            this.Controls.Add(this.FCsInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDInput);
            this.Name = "FormGraphics2";
            this.Text = "FormGraphics2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FCsInput;
        private System.Windows.Forms.Button ButtonIDEvent;
        private System.Windows.Forms.Button ButtonFCsEvent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}