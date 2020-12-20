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
            this.label1 = new System.Windows.Forms.Label();
            this.filePathTxt = new System.Windows.Forms.TextBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.keystrokeBtn = new System.Windows.Forms.Button();
            this.lblWaitingForKS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.opacityNum = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.opacityNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chemin vers l\'overlay";
            // 
            // filePathTxt
            // 
            this.filePathTxt.Enabled = false;
            this.filePathTxt.Location = new System.Drawing.Point(145, 56);
            this.filePathTxt.Name = "filePathTxt";
            this.filePathTxt.Size = new System.Drawing.Size(287, 20);
            this.filePathTxt.TabIndex = 1;
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(438, 54);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(75, 23);
            this.findBtn.TabIndex = 2;
            this.findBtn.Text = "Chercher";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(236, 162);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 3;
            this.applyBtn.Text = "Appliquer";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Combinaison de touche pour retirer l\'overlay";
            // 
            // keystrokeBtn
            // 
            this.keystrokeBtn.Location = new System.Drawing.Point(251, 80);
            this.keystrokeBtn.Name = "keystrokeBtn";
            this.keystrokeBtn.Size = new System.Drawing.Size(133, 23);
            this.keystrokeBtn.TabIndex = 6;
            this.keystrokeBtn.Text = "...";
            this.keystrokeBtn.UseVisualStyleBackColor = true;
            this.keystrokeBtn.Click += new System.EventHandler(this.keystrokeBtn_Click);
            // 
            // lblWaitingForKS
            // 
            this.lblWaitingForKS.AutoSize = true;
            this.lblWaitingForKS.Location = new System.Drawing.Point(390, 85);
            this.lblWaitingForKS.Name = "lblWaitingForKS";
            this.lblWaitingForKS.Size = new System.Drawing.Size(144, 13);
            this.lblWaitingForKS.TabIndex = 7;
            this.lblWaitingForKS.Text = "En attente de la combinaison";
            this.lblWaitingForKS.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Opacité";
            // 
            // opacityNum
            // 
            this.opacityNum.Location = new System.Drawing.Point(83, 108);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 197);
            this.Controls.Add(this.opacityNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblWaitingForKS);
            this.Controls.Add(this.keystrokeBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.filePathTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.opacityNum)).EndInit();
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
    }
}

