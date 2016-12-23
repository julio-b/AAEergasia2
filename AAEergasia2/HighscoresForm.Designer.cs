namespace AAEergasia2 {
    partial class HighscoresForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.topTenRichTxt = new System.Windows.Forms.RichTextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.insertScoreBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // topTenRichTxt
            // 
            this.topTenRichTxt.Location = new System.Drawing.Point(12, 49);
            this.topTenRichTxt.Name = "topTenRichTxt";
            this.topTenRichTxt.Size = new System.Drawing.Size(325, 354);
            this.topTenRichTxt.TabIndex = 0;
            this.topTenRichTxt.Text = "";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(13, 13);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(153, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.Text = "<Your Name>";
            this.nameTextBox.Visible = false;
            // 
            // insertScoreBtn
            // 
            this.insertScoreBtn.Location = new System.Drawing.Point(185, 10);
            this.insertScoreBtn.Name = "insertScoreBtn";
            this.insertScoreBtn.Size = new System.Drawing.Size(75, 23);
            this.insertScoreBtn.TabIndex = 2;
            this.insertScoreBtn.Text = "Save";
            this.insertScoreBtn.UseVisualStyleBackColor = true;
            this.insertScoreBtn.Visible = false;
            this.insertScoreBtn.Click += new System.EventHandler(this.insertScoreBtn_Click);
            // 
            // HighscoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 415);
            this.Controls.Add(this.insertScoreBtn);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.topTenRichTxt);
            this.Name = "HighscoresForm";
            this.Text = "HighscoresForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox topTenRichTxt;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button insertScoreBtn;
    }
}