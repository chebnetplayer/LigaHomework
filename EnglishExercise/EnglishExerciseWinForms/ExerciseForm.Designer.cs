namespace EnglishExerciseWinForms
{
    partial class ExerciseForm
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
            this.EnglishwordtextBox = new System.Windows.Forms.TextBox();
            this.FirstVariantbutton = new System.Windows.Forms.Button();
            this.SecondVariantbutton = new System.Windows.Forms.Button();
            this.ThirdVariantbutton = new System.Windows.Forms.Button();
            this.LearnedWordsrichTextBox = new System.Windows.Forms.RichTextBox();
            this.LearnedWordsbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnglishwordtextBox
            // 
            this.EnglishwordtextBox.Location = new System.Drawing.Point(12, 39);
            this.EnglishwordtextBox.Name = "EnglishwordtextBox";
            this.EnglishwordtextBox.ReadOnly = true;
            this.EnglishwordtextBox.Size = new System.Drawing.Size(200, 20);
            this.EnglishwordtextBox.TabIndex = 0;
            // 
            // FirstVariantbutton
            // 
            this.FirstVariantbutton.Location = new System.Drawing.Point(12, 101);
            this.FirstVariantbutton.Name = "FirstVariantbutton";
            this.FirstVariantbutton.Size = new System.Drawing.Size(75, 23);
            this.FirstVariantbutton.TabIndex = 1;
            this.FirstVariantbutton.UseVisualStyleBackColor = true;
            this.FirstVariantbutton.Click += new System.EventHandler(this.FirstVariantbutton_Click);
            // 
            // SecondVariantbutton
            // 
            this.SecondVariantbutton.Location = new System.Drawing.Point(142, 101);
            this.SecondVariantbutton.Name = "SecondVariantbutton";
            this.SecondVariantbutton.Size = new System.Drawing.Size(75, 23);
            this.SecondVariantbutton.TabIndex = 2;
            this.SecondVariantbutton.UseVisualStyleBackColor = true;
            this.SecondVariantbutton.Click += new System.EventHandler(this.SecondVariantbutton_Click);
            // 
            // ThirdVariantbutton
            // 
            this.ThirdVariantbutton.Location = new System.Drawing.Point(257, 101);
            this.ThirdVariantbutton.Name = "ThirdVariantbutton";
            this.ThirdVariantbutton.Size = new System.Drawing.Size(75, 23);
            this.ThirdVariantbutton.TabIndex = 3;
            this.ThirdVariantbutton.UseVisualStyleBackColor = true;
            this.ThirdVariantbutton.Click += new System.EventHandler(this.ThirdVariantbutton_Click);
            // 
            // LearnedWordsrichTextBox
            // 
            this.LearnedWordsrichTextBox.Location = new System.Drawing.Point(432, 12);
            this.LearnedWordsrichTextBox.Name = "LearnedWordsrichTextBox";
            this.LearnedWordsrichTextBox.ReadOnly = true;
            this.LearnedWordsrichTextBox.Size = new System.Drawing.Size(129, 112);
            this.LearnedWordsrichTextBox.TabIndex = 4;
            this.LearnedWordsrichTextBox.Text = "";
            // 
            // LearnedWordsbutton
            // 
            this.LearnedWordsbutton.Location = new System.Drawing.Point(257, 36);
            this.LearnedWordsbutton.Name = "LearnedWordsbutton";
            this.LearnedWordsbutton.Size = new System.Drawing.Size(169, 23);
            this.LearnedWordsbutton.TabIndex = 5;
            this.LearnedWordsbutton.Text = "Check Learned Words";
            this.LearnedWordsbutton.UseVisualStyleBackColor = true;
            this.LearnedWordsbutton.Click += new System.EventHandler(this.LearnedWordsbutton_Click);
            // 
            // ExerciseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 148);
            this.Controls.Add(this.LearnedWordsbutton);
            this.Controls.Add(this.LearnedWordsrichTextBox);
            this.Controls.Add(this.ThirdVariantbutton);
            this.Controls.Add(this.SecondVariantbutton);
            this.Controls.Add(this.FirstVariantbutton);
            this.Controls.Add(this.EnglishwordtextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ExerciseForm";
            this.Text = "ExerciseForm";
            this.Load += new System.EventHandler(this.ExerciseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EnglishwordtextBox;
        private System.Windows.Forms.Button FirstVariantbutton;
        private System.Windows.Forms.Button SecondVariantbutton;
        private System.Windows.Forms.Button ThirdVariantbutton;
        private System.Windows.Forms.RichTextBox LearnedWordsrichTextBox;
        private System.Windows.Forms.Button LearnedWordsbutton;
    }
}