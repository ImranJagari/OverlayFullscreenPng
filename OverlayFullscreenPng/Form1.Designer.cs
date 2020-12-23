namespace OverlayFullscreenPng
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.filePathTxt = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.keystrokeBtn = new System.Windows.Forms.Button();
            this.lblWaitingForKS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.opacityNum = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.titleBarPicture = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.opacityNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(37, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chemin vers l\'overlay";
            // 
            // filePathTxt
            // 
            this.filePathTxt.BackColor = System.Drawing.Color.Black;
            this.filePathTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePathTxt.Enabled = false;
            this.filePathTxt.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.filePathTxt.Location = new System.Drawing.Point(149, 78);
            this.filePathTxt.Name = "filePathTxt";
            this.filePathTxt.Size = new System.Drawing.Size(287, 20);
            this.filePathTxt.TabIndex = 1;
            // 
            // findBtn
            // 
            this.findBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.findBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findBtn.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.findBtn.Location = new System.Drawing.Point(442, 76);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(75, 23);
            this.findBtn.TabIndex = 2;
            this.findBtn.Text = "Chercher";
            this.findBtn.UseVisualStyleBackColor = false;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.applyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyBtn.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.applyBtn.Location = new System.Drawing.Point(164, 184);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 3;
            this.applyBtn.Text = "Appliquer";
            this.applyBtn.UseVisualStyleBackColor = false;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(37, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Combinaison de touche pour retirer l\'overlay";
            // 
            // keystrokeBtn
            // 
            this.keystrokeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.keystrokeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keystrokeBtn.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.keystrokeBtn.Location = new System.Drawing.Point(255, 102);
            this.keystrokeBtn.Name = "keystrokeBtn";
            this.keystrokeBtn.Size = new System.Drawing.Size(133, 23);
            this.keystrokeBtn.TabIndex = 6;
            this.keystrokeBtn.Text = "...";
            this.keystrokeBtn.UseVisualStyleBackColor = false;
            this.keystrokeBtn.Click += new System.EventHandler(this.keystrokeBtn_Click);
            // 
            // lblWaitingForKS
            // 
            this.lblWaitingForKS.AutoSize = true;
            this.lblWaitingForKS.ForeColor = System.Drawing.SystemColors.Control;
            this.lblWaitingForKS.Location = new System.Drawing.Point(394, 107);
            this.lblWaitingForKS.Name = "lblWaitingForKS";
            this.lblWaitingForKS.Size = new System.Drawing.Size(144, 13);
            this.lblWaitingForKS.TabIndex = 7;
            this.lblWaitingForKS.Text = "En attente de la combinaison";
            this.lblWaitingForKS.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(37, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Opacité";
            // 
            // opacityNum
            // 
            this.opacityNum.BackColor = System.Drawing.Color.Black;
            this.opacityNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opacityNum.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.opacityNum.Location = new System.Drawing.Point(87, 130);
            this.opacityNum.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.opacityNum.Name = "opacityNum";
            this.opacityNum.Size = new System.Drawing.Size(120, 20);
            this.opacityNum.TabIndex = 9;
            this.opacityNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.Location = new System.Drawing.Point(287, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Sauvegarder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // titleBarPicture
            // 
            this.titleBarPicture.BackColor = System.Drawing.Color.Black;
            this.titleBarPicture.Location = new System.Drawing.Point(-2, -1);
            this.titleBarPicture.Name = "titleBarPicture";
            this.titleBarPicture.Size = new System.Drawing.Size(577, 34);
            this.titleBarPicture.TabIndex = 11;
            this.titleBarPicture.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(12, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(542, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(511, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(25, 23);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(573, 227);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.titleBarPicture);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.opacityNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWaitingForKS);
            this.Controls.Add(this.keystrokeBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.filePathTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.opacityNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleBarPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePathTxt;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button keystrokeBtn;
        private System.Windows.Forms.Label lblWaitingForKS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown opacityNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox titleBarPicture;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

