namespace EnglishExerciseWinForms
{
    partial class RegistrationForm
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
            this.Registrationbutton = new System.Windows.Forms.Button();
            this.NicknametextBox = new System.Windows.Forms.TextBox();
            this.Nicklabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Registrationbutton
            // 
            this.Registrationbutton.Location = new System.Drawing.Point(119, 108);
            this.Registrationbutton.Name = "Registrationbutton";
            this.Registrationbutton.Size = new System.Drawing.Size(75, 23);
            this.Registrationbutton.TabIndex = 0;
            this.Registrationbutton.Text = "Registration";
            this.Registrationbutton.UseVisualStyleBackColor = true;
            this.Registrationbutton.Click += new System.EventHandler(this.Registrationbutton_Click);
            // 
            // NicknametextBox
            // 
            this.NicknametextBox.Location = new System.Drawing.Point(123, 40);
            this.NicknametextBox.Name = "NicknametextBox";
            this.NicknametextBox.Size = new System.Drawing.Size(100, 20);
            this.NicknametextBox.TabIndex = 1;
            // 
            // Nicklabel
            // 
            this.Nicklabel.AutoSize = true;
            this.Nicklabel.Location = new System.Drawing.Point(62, 43);
            this.Nicklabel.Name = "Nicklabel";
            this.Nicklabel.Size = new System.Drawing.Size(55, 13);
            this.Nicklabel.TabIndex = 2;
            this.Nicklabel.Text = "Nickname";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 154);
            this.Controls.Add(this.Nicklabel);
            this.Controls.Add(this.NicknametextBox);
            this.Controls.Add(this.Registrationbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Registrationbutton;
        private System.Windows.Forms.TextBox NicknametextBox;
        private System.Windows.Forms.Label Nicklabel;
    }
}