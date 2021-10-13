namespace FaceBookUI
{
    partial class PersonalDetailsForm
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
            this.lableUserFirstName = new System.Windows.Forms.Label();
            this.lableUserLastName = new System.Windows.Forms.Label();
            this.lableUserGender = new System.Windows.Forms.Label();
            this.lableUserBirthday = new System.Windows.Forms.Label();
            this.lableUserCity = new System.Windows.Forms.Label();
            this.lableUserEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lableUserFirstName
            // 
            this.lableUserFirstName.AutoSize = true;
            this.lableUserFirstName.Location = new System.Drawing.Point(15, 10);
            this.lableUserFirstName.Name = "lableUserFirstName";
            this.lableUserFirstName.Size = new System.Drawing.Size(79, 16);
            this.lableUserFirstName.TabIndex = 0;
            this.lableUserFirstName.Text = "First Name: ";
            // 
            // lableUserLastName
            // 
            this.lableUserLastName.AutoSize = true;
            this.lableUserLastName.Location = new System.Drawing.Point(15, 35);
            this.lableUserLastName.Name = "lableUserLastName";
            this.lableUserLastName.Size = new System.Drawing.Size(79, 16);
            this.lableUserLastName.TabIndex = 1;
            this.lableUserLastName.Text = "Last Name: ";
            // 
            // lableUserGender
            // 
            this.lableUserGender.AutoSize = true;
            this.lableUserGender.Location = new System.Drawing.Point(15, 60);
            this.lableUserGender.Name = "lableUserGender";
            this.lableUserGender.Size = new System.Drawing.Size(59, 16);
            this.lableUserGender.TabIndex = 2;
            this.lableUserGender.Text = "Gender: ";
            // 
            // lableUserBirthday
            // 
            this.lableUserBirthday.AutoSize = true;
            this.lableUserBirthday.Location = new System.Drawing.Point(15, 85);
            this.lableUserBirthday.Name = "lableUserBirthday";
            this.lableUserBirthday.Size = new System.Drawing.Size(63, 16);
            this.lableUserBirthday.TabIndex = 3;
            this.lableUserBirthday.Text = "Birthday: ";
            // 
            // lableUserCity
            // 
            this.lableUserCity.AutoSize = true;
            this.lableUserCity.Location = new System.Drawing.Point(15, 110);
            this.lableUserCity.Name = "lableUserCity";
            this.lableUserCity.Size = new System.Drawing.Size(36, 16);
            this.lableUserCity.TabIndex = 4;
            this.lableUserCity.Text = "City: ";
            // 
            // lableUserEmail
            // 
            this.lableUserEmail.AutoSize = true;
            this.lableUserEmail.Location = new System.Drawing.Point(15, 135);
            this.lableUserEmail.Name = "lableUserEmail";
            this.lableUserEmail.Size = new System.Drawing.Size(48, 16);
            this.lableUserEmail.TabIndex = 5;
            this.lableUserEmail.Text = "Email: ";
            // 
            // PersonalDetails
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(279, 166);
            this.Controls.Add(this.lableUserEmail);
            this.Controls.Add(this.lableUserCity);
            this.Controls.Add(this.lableUserBirthday);
            this.Controls.Add(this.lableUserGender);
            this.Controls.Add(this.lableUserLastName);
            this.Controls.Add(this.lableUserFirstName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(295, 205);
            this.MinimumSize = new System.Drawing.Size(295, 205);
            this.Name = "PersonalDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lableUserFirstName;
        private System.Windows.Forms.Label lableUserLastName;
        private System.Windows.Forms.Label lableUserGender;
        private System.Windows.Forms.Label lableUserBirthday;
        private System.Windows.Forms.Label lableUserCity;
        private System.Windows.Forms.Label lableUserEmail;
    }
}