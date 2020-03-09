namespace ImageProcessingv2
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.OPEN_BUTTON = new System.Windows.Forms.Button();
            this.ZAP_BUTTON = new System.Windows.Forms.Button();
            this.CLOSE_BUTTON = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OPEN_BUTTON
            // 
            this.OPEN_BUTTON.Location = new System.Drawing.Point(655, 12);
            this.OPEN_BUTTON.Name = "OPEN_BUTTON";
            this.OPEN_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.OPEN_BUTTON.TabIndex = 0;
            this.OPEN_BUTTON.Text = "Otworz";
            this.OPEN_BUTTON.UseVisualStyleBackColor = true;
            this.OPEN_BUTTON.Click += new System.EventHandler(this.OPEN_BUTTON_Click);
            // 
            // ZAP_BUTTON
            // 
            this.ZAP_BUTTON.Location = new System.Drawing.Point(235, 415);
            this.ZAP_BUTTON.Name = "ZAP_BUTTON";
            this.ZAP_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.ZAP_BUTTON.TabIndex = 1;
            this.ZAP_BUTTON.Text = "Zapisz";
            this.ZAP_BUTTON.UseVisualStyleBackColor = true;
            this.ZAP_BUTTON.Click += new System.EventHandler(this.ZAP_BUTTON_Click);
            // 
            // CLOSE_BUTTON
            // 
            this.CLOSE_BUTTON.Location = new System.Drawing.Point(12, 415);
            this.CLOSE_BUTTON.Name = "CLOSE_BUTTON";
            this.CLOSE_BUTTON.Size = new System.Drawing.Size(56, 23);
            this.CLOSE_BUTTON.TabIndex = 2;
            this.CLOSE_BUTTON.Text = "Zamknij";
            this.CLOSE_BUTTON.UseVisualStyleBackColor = true;
            this.CLOSE_BUTTON.Click += new System.EventHandler(this.CLOSE_BUTTON_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 365);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPG|*.jpg|PNG|*.png|BMP|*.bmp";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG|*.jpg|PNG|*.png|BMP|*.bmp";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CLOSE_BUTTON);
            this.Controls.Add(this.ZAP_BUTTON);
            this.Controls.Add(this.OPEN_BUTTON);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Obrazkownia";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OPEN_BUTTON;
        private System.Windows.Forms.Button ZAP_BUTTON;
        private System.Windows.Forms.Button CLOSE_BUTTON;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

