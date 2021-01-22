
namespace RESToran.PresentationLayer.UserControls
{
    partial class ViewProfileControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.EmailAddressLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.HoursOpenLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile details:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.NameLabel.Location = new System.Drawing.Point(22, 107);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(70, 25);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "label2";
            // 
            // EmailAddressLabel
            // 
            this.EmailAddressLabel.AutoSize = true;
            this.EmailAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.EmailAddressLabel.Location = new System.Drawing.Point(22, 167);
            this.EmailAddressLabel.Name = "EmailAddressLabel";
            this.EmailAddressLabel.Size = new System.Drawing.Size(70, 25);
            this.EmailAddressLabel.TabIndex = 2;
            this.EmailAddressLabel.Text = "label3";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.LocationLabel.Location = new System.Drawing.Point(22, 223);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(70, 25);
            this.LocationLabel.TabIndex = 3;
            this.LocationLabel.Text = "label2";
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.AutoSize = true;
            this.PhoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.PhoneNumberLabel.Location = new System.Drawing.Point(22, 267);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(70, 25);
            this.PhoneNumberLabel.TabIndex = 4;
            this.PhoneNumberLabel.Text = "label2";
            // 
            // HoursOpenLabel
            // 
            this.HoursOpenLabel.AutoSize = true;
            this.HoursOpenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.HoursOpenLabel.Location = new System.Drawing.Point(24, 319);
            this.HoursOpenLabel.Name = "HoursOpenLabel";
            this.HoursOpenLabel.Size = new System.Drawing.Size(70, 25);
            this.HoursOpenLabel.TabIndex = 5;
            this.HoursOpenLabel.Text = "label3";
            // 
            // ViewProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HoursOpenLabel);
            this.Controls.Add(this.PhoneNumberLabel);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.EmailAddressLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label1);
            this.Name = "ViewProfileControl";
            this.Size = new System.Drawing.Size(621, 584);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label EmailAddressLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.Label HoursOpenLabel;
    }
}
