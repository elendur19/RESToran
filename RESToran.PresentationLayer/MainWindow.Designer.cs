
namespace RESToran.PresentationLayer
{
    partial class MainWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.FoodPressedPanel = new System.Windows.Forms.Panel();
            this.FoodButton2 = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.AddFoodButton = new System.Windows.Forms.Button();
            this.EditMenuButton = new System.Windows.Forms.Button();
            this.ShowMenuButton = new System.Windows.Forms.Button();
            this.ReservationsPressedPanel = new System.Windows.Forms.Panel();
            this.ReservationsButton2 = new System.Windows.Forms.Button();
            this.BackButton4 = new System.Windows.Forms.Button();
            this.ManageReservationsButton = new System.Windows.Forms.Button();
            this.ViewReservationsButton = new System.Windows.Forms.Button();
            this.TablesPressedPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TablesButton2 = new System.Windows.Forms.Button();
            this.BackTablesButton = new System.Windows.Forms.Button();
            this.AddTablesButton = new System.Windows.Forms.Button();
            this.ManageTablesButton = new System.Windows.Forms.Button();
            this.ViewTablesButton = new System.Windows.Forms.Button();
            this.ProfilePressedPanel = new System.Windows.Forms.Panel();
            this.ProfileButton2 = new System.Windows.Forms.Button();
            this.BackButton5 = new System.Windows.Forms.Button();
            this.EditProfileButton = new System.Windows.Forms.Button();
            this.ViewProfileButton = new System.Windows.Forms.Button();
            this.MenuButtonPanel = new System.Windows.Forms.Panel();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.ReservationsButton = new System.Windows.Forms.Button();
            this.TablesButton = new System.Windows.Forms.Button();
            this.FoodButton = new System.Windows.Forms.Button();
            this.viewProfileControl1 = new RESToran.PresentationLayer.UserControls.ViewProfileControl();
            this.editProfileControl1 = new RESToran.PresentationLayer.UserControls.EditProfileControl();
            this.panel1.SuspendLayout();
            this.FoodPressedPanel.SuspendLayout();
            this.ReservationsPressedPanel.SuspendLayout();
            this.TablesPressedPanel.SuspendLayout();
            this.ProfilePressedPanel.SuspendLayout();
            this.MenuButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.FoodPressedPanel);
            this.panel1.Controls.Add(this.ReservationsPressedPanel);
            this.panel1.Controls.Add(this.TablesPressedPanel);
            this.panel1.Controls.Add(this.ProfilePressedPanel);
            this.panel1.Controls.Add(this.MenuButtonPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 733);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // FoodPressedPanel
            // 
            this.FoodPressedPanel.Controls.Add(this.FoodButton2);
            this.FoodPressedPanel.Controls.Add(this.BackButton);
            this.FoodPressedPanel.Controls.Add(this.AddFoodButton);
            this.FoodPressedPanel.Controls.Add(this.EditMenuButton);
            this.FoodPressedPanel.Controls.Add(this.ShowMenuButton);
            this.FoodPressedPanel.Location = new System.Drawing.Point(20, 184);
            this.FoodPressedPanel.Name = "FoodPressedPanel";
            this.FoodPressedPanel.Size = new System.Drawing.Size(203, 241);
            this.FoodPressedPanel.TabIndex = 5;
            // 
            // FoodButton2
            // 
            this.FoodButton2.Location = new System.Drawing.Point(0, 0);
            this.FoodButton2.Name = "FoodButton2";
            this.FoodButton2.Size = new System.Drawing.Size(201, 47);
            this.FoodButton2.TabIndex = 4;
            this.FoodButton2.Text = "Food";
            this.FoodButton2.UseVisualStyleBackColor = true;
            this.FoodButton2.Click += new System.EventHandler(this.FoodButton2_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(0, 209);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(201, 32);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddFoodButton
            // 
            this.AddFoodButton.Location = new System.Drawing.Point(0, 158);
            this.AddFoodButton.Name = "AddFoodButton";
            this.AddFoodButton.Size = new System.Drawing.Size(201, 45);
            this.AddFoodButton.TabIndex = 2;
            this.AddFoodButton.Text = "Add Food";
            this.AddFoodButton.UseVisualStyleBackColor = true;
            this.AddFoodButton.Click += new System.EventHandler(this.AddFoodButton_Click);
            // 
            // EditMenuButton
            // 
            this.EditMenuButton.Location = new System.Drawing.Point(0, 106);
            this.EditMenuButton.Name = "EditMenuButton";
            this.EditMenuButton.Size = new System.Drawing.Size(201, 46);
            this.EditMenuButton.TabIndex = 1;
            this.EditMenuButton.Text = "Edit Menu";
            this.EditMenuButton.UseVisualStyleBackColor = true;
            this.EditMenuButton.Click += new System.EventHandler(this.EditMenuButton_Click);
            // 
            // ShowMenuButton
            // 
            this.ShowMenuButton.Location = new System.Drawing.Point(0, 53);
            this.ShowMenuButton.Name = "ShowMenuButton";
            this.ShowMenuButton.Size = new System.Drawing.Size(201, 47);
            this.ShowMenuButton.TabIndex = 0;
            this.ShowMenuButton.Text = "Show Menu";
            this.ShowMenuButton.UseVisualStyleBackColor = true;
            this.ShowMenuButton.Click += new System.EventHandler(this.ShowMenuButton_Click);
            // 
            // ReservationsPressedPanel
            // 
            this.ReservationsPressedPanel.Controls.Add(this.ReservationsButton2);
            this.ReservationsPressedPanel.Controls.Add(this.BackButton4);
            this.ReservationsPressedPanel.Controls.Add(this.ManageReservationsButton);
            this.ReservationsPressedPanel.Controls.Add(this.ViewReservationsButton);
            this.ReservationsPressedPanel.Location = new System.Drawing.Point(42, 209);
            this.ReservationsPressedPanel.Name = "ReservationsPressedPanel";
            this.ReservationsPressedPanel.Size = new System.Drawing.Size(203, 193);
            this.ReservationsPressedPanel.TabIndex = 7;
            // 
            // ReservationsButton2
            // 
            this.ReservationsButton2.Location = new System.Drawing.Point(0, 0);
            this.ReservationsButton2.Name = "ReservationsButton2";
            this.ReservationsButton2.Size = new System.Drawing.Size(201, 47);
            this.ReservationsButton2.TabIndex = 4;
            this.ReservationsButton2.Text = "Reservations";
            this.ReservationsButton2.UseVisualStyleBackColor = true;
            this.ReservationsButton2.Click += new System.EventHandler(this.ReservationsButton2_Click);
            // 
            // BackButton4
            // 
            this.BackButton4.Location = new System.Drawing.Point(1, 158);
            this.BackButton4.Name = "BackButton4";
            this.BackButton4.Size = new System.Drawing.Size(201, 32);
            this.BackButton4.TabIndex = 3;
            this.BackButton4.Text = "Back";
            this.BackButton4.UseVisualStyleBackColor = true;
            this.BackButton4.Click += new System.EventHandler(this.BackButton4_Click);
            // 
            // ManageReservationsButton
            // 
            this.ManageReservationsButton.Location = new System.Drawing.Point(0, 106);
            this.ManageReservationsButton.Name = "ManageReservationsButton";
            this.ManageReservationsButton.Size = new System.Drawing.Size(201, 46);
            this.ManageReservationsButton.TabIndex = 1;
            this.ManageReservationsButton.Text = "Manage Reservations";
            this.ManageReservationsButton.UseVisualStyleBackColor = true;
            this.ManageReservationsButton.Click += new System.EventHandler(this.ManageReservationsButton_Click);
            // 
            // ViewReservationsButton
            // 
            this.ViewReservationsButton.Location = new System.Drawing.Point(0, 53);
            this.ViewReservationsButton.Name = "ViewReservationsButton";
            this.ViewReservationsButton.Size = new System.Drawing.Size(201, 47);
            this.ViewReservationsButton.TabIndex = 0;
            this.ViewReservationsButton.Text = "View Reservations";
            this.ViewReservationsButton.UseVisualStyleBackColor = true;
            this.ViewReservationsButton.Click += new System.EventHandler(this.ViewReservationsButton_Click);
            // 
            // TablesPressedPanel
            // 
            this.TablesPressedPanel.Controls.Add(this.TablesButton2);
            this.TablesPressedPanel.Controls.Add(this.BackTablesButton);
            this.TablesPressedPanel.Controls.Add(this.AddTablesButton);
            this.TablesPressedPanel.Controls.Add(this.ManageTablesButton);
            this.TablesPressedPanel.Controls.Add(this.ViewTablesButton);
            this.TablesPressedPanel.Location = new System.Drawing.Point(0, 0);
            this.TablesPressedPanel.Name = "TablesPressedPanel";
            this.TablesPressedPanel.Size = new System.Drawing.Size(203, 241);
            this.TablesPressedPanel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome";
            // 
            // TablesButton2
            // 
            this.TablesButton2.Location = new System.Drawing.Point(0, 0);
            this.TablesButton2.Name = "TablesButton2";
            this.TablesButton2.Size = new System.Drawing.Size(201, 47);
            this.TablesButton2.TabIndex = 4;
            this.TablesButton2.Text = "Tables";
            this.TablesButton2.UseVisualStyleBackColor = true;
            this.TablesButton2.Click += new System.EventHandler(this.TablesButton2_Click);
            // 
            // BackTablesButton
            // 
            this.BackTablesButton.Location = new System.Drawing.Point(0, 209);
            this.BackTablesButton.Name = "BackTablesButton";
            this.BackTablesButton.Size = new System.Drawing.Size(201, 32);
            this.BackTablesButton.TabIndex = 3;
            this.BackTablesButton.Text = "Back";
            this.BackTablesButton.UseVisualStyleBackColor = true;
            this.BackTablesButton.Click += new System.EventHandler(this.BackTablesButton_Click);
            // 
            // AddTablesButton
            // 
            this.AddTablesButton.Location = new System.Drawing.Point(0, 158);
            this.AddTablesButton.Name = "AddTablesButton";
            this.AddTablesButton.Size = new System.Drawing.Size(201, 45);
            this.AddTablesButton.TabIndex = 2;
            this.AddTablesButton.Text = "Add Tables";
            this.AddTablesButton.UseVisualStyleBackColor = true;
            this.AddTablesButton.Click += new System.EventHandler(this.AddTablesButton_Click);
            // 
            // ManageTablesButton
            // 
            this.ManageTablesButton.Location = new System.Drawing.Point(0, 106);
            this.ManageTablesButton.Name = "ManageTablesButton";
            this.ManageTablesButton.Size = new System.Drawing.Size(201, 46);
            this.ManageTablesButton.TabIndex = 1;
            this.ManageTablesButton.Text = "Manage Tables";
            this.ManageTablesButton.UseVisualStyleBackColor = true;
            this.ManageTablesButton.Click += new System.EventHandler(this.ManageTablesButton_Click);
            // 
            // ViewTablesButton
            // 
            this.ViewTablesButton.Location = new System.Drawing.Point(0, 53);
            this.ViewTablesButton.Name = "ViewTablesButton";
            this.ViewTablesButton.Size = new System.Drawing.Size(201, 47);
            this.ViewTablesButton.TabIndex = 0;
            this.ViewTablesButton.Text = "View Tables";
            this.ViewTablesButton.UseVisualStyleBackColor = true;
            this.ViewTablesButton.Click += new System.EventHandler(this.ViewTablesButton_Click);
            // 
            // ProfilePressedPanel
            // 
            this.ProfilePressedPanel.BackColor = System.Drawing.Color.Transparent;
            this.ProfilePressedPanel.Controls.Add(this.ProfileButton2);
            this.ProfilePressedPanel.Controls.Add(this.BackButton5);
            this.ProfilePressedPanel.Controls.Add(this.EditProfileButton);
            this.ProfilePressedPanel.Controls.Add(this.ViewProfileButton);
            this.ProfilePressedPanel.Location = new System.Drawing.Point(36, 480);
            this.ProfilePressedPanel.Name = "ProfilePressedPanel";
            this.ProfilePressedPanel.Size = new System.Drawing.Size(203, 193);
            this.ProfilePressedPanel.TabIndex = 8;
            // 
            // ProfileButton2
            // 
            this.ProfileButton2.Location = new System.Drawing.Point(0, 0);
            this.ProfileButton2.Name = "ProfileButton2";
            this.ProfileButton2.Size = new System.Drawing.Size(201, 47);
            this.ProfileButton2.TabIndex = 4;
            this.ProfileButton2.Text = "Profile";
            this.ProfileButton2.UseVisualStyleBackColor = true;
            this.ProfileButton2.Click += new System.EventHandler(this.ProfileButton2_Click);
            // 
            // BackButton5
            // 
            this.BackButton5.Location = new System.Drawing.Point(1, 158);
            this.BackButton5.Name = "BackButton5";
            this.BackButton5.Size = new System.Drawing.Size(201, 32);
            this.BackButton5.TabIndex = 3;
            this.BackButton5.Text = "Back";
            this.BackButton5.UseVisualStyleBackColor = true;
            this.BackButton5.Click += new System.EventHandler(this.BackButton5_Click);
            // 
            // EditProfileButton
            // 
            this.EditProfileButton.Location = new System.Drawing.Point(0, 106);
            this.EditProfileButton.Name = "EditProfileButton";
            this.EditProfileButton.Size = new System.Drawing.Size(201, 46);
            this.EditProfileButton.TabIndex = 1;
            this.EditProfileButton.Text = "Edit Profile";
            this.EditProfileButton.UseVisualStyleBackColor = true;
            this.EditProfileButton.Click += new System.EventHandler(this.EditProfileButton_Click);
            // 
            // ViewProfileButton
            // 
            this.ViewProfileButton.Location = new System.Drawing.Point(0, 53);
            this.ViewProfileButton.Name = "ViewProfileButton";
            this.ViewProfileButton.Size = new System.Drawing.Size(201, 47);
            this.ViewProfileButton.TabIndex = 0;
            this.ViewProfileButton.Text = "View Profile";
            this.ViewProfileButton.UseVisualStyleBackColor = true;
            this.ViewProfileButton.Click += new System.EventHandler(this.ViewProfileButton_Click);
            // 
            // MenuButtonPanel
            // 
            this.MenuButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.MenuButtonPanel.Controls.Add(this.ProfileButton);
            this.MenuButtonPanel.Controls.Add(this.ReservationsButton);
            this.MenuButtonPanel.Controls.Add(this.TablesButton);
            this.MenuButtonPanel.Controls.Add(this.FoodButton);
            this.MenuButtonPanel.Location = new System.Drawing.Point(3, 137);
            this.MenuButtonPanel.Name = "MenuButtonPanel";
            this.MenuButtonPanel.Size = new System.Drawing.Size(242, 274);
            this.MenuButtonPanel.TabIndex = 0;
            // 
            // ProfileButton
            // 
            this.ProfileButton.Location = new System.Drawing.Point(-1, 166);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(200, 44);
            this.ProfileButton.TabIndex = 3;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // ReservationsButton
            // 
            this.ReservationsButton.Location = new System.Drawing.Point(0, 114);
            this.ReservationsButton.Name = "ReservationsButton";
            this.ReservationsButton.Size = new System.Drawing.Size(199, 46);
            this.ReservationsButton.TabIndex = 2;
            this.ReservationsButton.Text = "View reservations";
            this.ReservationsButton.UseVisualStyleBackColor = true;
            this.ReservationsButton.Click += new System.EventHandler(this.ReservationsButton_Click);
            // 
            // TablesButton
            // 
            this.TablesButton.Location = new System.Drawing.Point(0, 58);
            this.TablesButton.Name = "TablesButton";
            this.TablesButton.Size = new System.Drawing.Size(199, 50);
            this.TablesButton.TabIndex = 1;
            this.TablesButton.Text = "Tables";
            this.TablesButton.UseVisualStyleBackColor = true;
            this.TablesButton.Click += new System.EventHandler(this.TablesButton_Click);
            // 
            // FoodButton
            // 
            this.FoodButton.Location = new System.Drawing.Point(-1, 0);
            this.FoodButton.Name = "FoodButton";
            this.FoodButton.Size = new System.Drawing.Size(201, 52);
            this.FoodButton.TabIndex = 0;
            this.FoodButton.Text = "Food";
            this.FoodButton.UseVisualStyleBackColor = true;
            this.FoodButton.Click += new System.EventHandler(this.FoodButton_Click);
            // 
            // viewProfileControl1
            // 
            this.viewProfileControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.viewProfileControl1.Location = new System.Drawing.Point(323, 0);
            this.viewProfileControl1.Name = "viewProfileControl1";
            this.viewProfileControl1.Size = new System.Drawing.Size(832, 733);
            this.viewProfileControl1.TabIndex = 6;
            // 
            // editProfileControl1
            // 
            this.editProfileControl1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.editProfileControl1.Location = new System.Drawing.Point(323, 0);
            this.editProfileControl1.Name = "editProfileControl1";
            this.editProfileControl1.Size = new System.Drawing.Size(832, 733);
            this.editProfileControl1.TabIndex = 5;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 733);
            this.Controls.Add(this.viewProfileControl1);
            this.Controls.Add(this.editProfileControl1);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.FoodPressedPanel.ResumeLayout(false);
            this.ReservationsPressedPanel.ResumeLayout(false);
            this.TablesPressedPanel.ResumeLayout(false);
            this.ProfilePressedPanel.ResumeLayout(false);
            this.MenuButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MenuButtonPanel;
        private System.Windows.Forms.Button ReservationsButton;
        private System.Windows.Forms.Button TablesButton;
        private System.Windows.Forms.Button FoodButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Panel FoodPressedPanel;
        private System.Windows.Forms.Button FoodButton2;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button AddFoodButton;
        private System.Windows.Forms.Button EditMenuButton;
        private System.Windows.Forms.Button ShowMenuButton;
        private System.Windows.Forms.Panel TablesPressedPanel;
        private System.Windows.Forms.Button TablesButton2;
        private System.Windows.Forms.Button BackTablesButton;
        private System.Windows.Forms.Button AddTablesButton;
        private System.Windows.Forms.Button ManageTablesButton;
        private System.Windows.Forms.Button ViewTablesButton;
        private System.Windows.Forms.Panel ReservationsPressedPanel;
        private System.Windows.Forms.Button ReservationsButton2;
        private System.Windows.Forms.Button BackButton4;
        private System.Windows.Forms.Button ManageReservationsButton;
        private System.Windows.Forms.Button ViewReservationsButton;
        private System.Windows.Forms.Panel ProfilePressedPanel;
        private System.Windows.Forms.Button ProfileButton2;
        private System.Windows.Forms.Button BackButton5;
        private System.Windows.Forms.Button EditProfileButton;
        private System.Windows.Forms.Button ViewProfileButton;
        private UserControls.EditProfileControl editProfileControl1;
        private UserControls.ViewProfileControl viewProfileControl1;
    }
}