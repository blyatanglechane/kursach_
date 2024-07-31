namespace kursach_.FormGraphics
{
    partial class Week
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Week));
            this.label2 = new System.Windows.Forms.Label();
            this.FCsInput = new System.Windows.Forms.TextBox();
            this.ButtonFCsEvent = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите ФИО студента";
            // 
            // FCsInput
            // 
            this.FCsInput.Font = new System.Drawing.Font("Comic Sans MS", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FCsInput.Location = new System.Drawing.Point(156, 130);
            this.FCsInput.Multiline = true;
            this.FCsInput.Name = "FCsInput";
            this.FCsInput.Size = new System.Drawing.Size(246, 63);
            this.FCsInput.TabIndex = 3;
            // 
            // ButtonFCsEvent
            // 
            this.ButtonFCsEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFCsEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonFCsEvent.Location = new System.Drawing.Point(192, 228);
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
            this.pictureBox2.Location = new System.Drawing.Point(73, 130);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 63);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // Week
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 357);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ButtonFCsEvent);
            this.Controls.Add(this.FCsInput);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Week";
            this.Text = "FormGraphics2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FCsInput;
        private System.Windows.Forms.Button ButtonFCsEvent;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}