namespace EnglishExerciseWinForms
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginButton = new System.Windows.Forms.Button();
            this.Loginlabel = new System.Windows.Forms.Label();
            this.LogIntextBox = new System.Windows.Forms.TextBox();
            this.Registratebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(279, 27);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Loginlabel
            // 
            this.Loginlabel.AutoSize = true;
            this.Loginlabel.Location = new System.Drawing.Point(22, 36);
            this.Loginlabel.Name = "Loginlabel";
            this.Loginlabel.Size = new System.Drawing.Size(55, 13);
            this.Loginlabel.TabIndex = 1;
            this.Loginlabel.Text = "Nickname";
            this.Loginlabel.Click += new System.EventHandler(this.Loginlabel_Click);
            // 
            // LogIntextBox
            // 
            this.LogIntextBox.Location = new System.Drawing.Point(95, 29);
            this.LogIntextBox.Name = "LogIntextBox";
            this.LogIntextBox.Size = new System.Drawing.Size(100, 20);
            this.LogIntextBox.TabIndex = 2;
            // 
            // Registratebutton
            // 
            this.Registratebutton.Location = new System.Drawing.Point(279, 57);
            this.Registratebutton.Name = "Registratebutton";
            this.Registratebutton.Size = new System.Drawing.Size(75, 23);
            this.Registratebutton.TabIndex = 3;
            this.Registratebutton.Text = "Registration";
            this.Registratebutton.UseVisualStyleBackColor = true;
            this.Registratebutton.Click += new System.EventHandler(this.Registrationbutton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 108);
            this.Controls.Add(this.Registratebutton);
            this.Controls.Add(this.LogIntextBox);
            this.Controls.Add(this.Loginlabel);
            this.Controls.Add(this.LoginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(404, 147);
            this.MinimumSize = new System.Drawing.Size(404, 147);
            this.Name = "LoginForm";
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label Loginlabel;
        private System.Windows.Forms.TextBox LogIntextBox;
        private System.Windows.Forms.Button Registratebutton;
    }
}

