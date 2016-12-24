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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // topTenRichTxt
            // 
            this.topTenRichTxt.Location = new System.Drawing.Point(13, 339);
            this.topTenRichTxt.Name = "topTenRichTxt";
            this.topTenRichTxt.Size = new System.Drawing.Size(349, 114);
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
            this.insertScoreBtn.Location = new System.Drawing.Point(172, 10);
            this.insertScoreBtn.Name = "insertScoreBtn";
            this.insertScoreBtn.Size = new System.Drawing.Size(75, 23);
            this.insertScoreBtn.TabIndex = 2;
            this.insertScoreBtn.Text = "Save";
            this.insertScoreBtn.UseVisualStyleBackColor = true;
            this.insertScoreBtn.Visible = false;
            this.insertScoreBtn.Click += new System.EventHandler(this.insertScoreBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._name,
            this._score,
            this._time});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(349, 294);
            this.dataGridView1.TabIndex = 3;
            // 
            // _name
            // 
            this._name.HeaderText = "Name";
            this._name.Name = "_name";
            this._name.ReadOnly = true;
            // 
            // _score
            // 
            this._score.HeaderText = "Score";
            this._score.Name = "_score";
            this._score.ReadOnly = true;
            // 
            // _time
            // 
            this._time.HeaderText = "Time";
            this._time.Name = "_time";
            this._time.ReadOnly = true;
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(253, 11);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 23);
            this.reset.TabIndex = 4;
            this.reset.Text = "ClearDB";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // HighscoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 465);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.insertScoreBtn);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.topTenRichTxt);
            this.Name = "HighscoresForm";
            this.Text = "HighscoresForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox topTenRichTxt;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button insertScoreBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _score;
        private System.Windows.Forms.DataGridViewTextBoxColumn _time;
        private System.Windows.Forms.Button reset;
    }
}