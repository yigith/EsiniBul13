﻿namespace EsiniBul
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlKartlar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlKartlar
            // 
            this.pnlKartlar.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlKartlar.Location = new System.Drawing.Point(12, 12);
            this.pnlKartlar.Name = "pnlKartlar";
            this.pnlKartlar.Size = new System.Drawing.Size(505, 441);
            this.pnlKartlar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(527, 464);
            this.Controls.Add(this.pnlKartlar);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eşini Bul";
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlKartlar;
    }
}