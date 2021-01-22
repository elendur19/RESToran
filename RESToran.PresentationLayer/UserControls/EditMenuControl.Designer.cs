
namespace RESToran.PresentationLayer.UserControls
{
    partial class EditMenuControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.HouseSpecialCheckBox = new System.Windows.Forms.CheckBox();
            this.PriceBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.showMenuControl1 = new RESToran.PresentationLayer.UserControls.ShowMenuControl();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuGrid
            // 
            this.MenuGrid.AllowUserToAddRows = false;
            this.MenuGrid.AllowUserToDeleteRows = false;
            this.MenuGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MenuGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MenuGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.MenuGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MenuGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MenuGrid.Location = new System.Drawing.Point(0, 52);
            this.MenuGrid.Name = "MenuGrid";
            this.MenuGrid.ReadOnly = true;
            this.MenuGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.MenuGrid.RowTemplate.ReadOnly = true;
            this.MenuGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuGrid.Size = new System.Drawing.Size(770, 666);
            this.MenuGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F);
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Edit items on menu";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button1.Location = new System.Drawing.Point(585, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DescriptionTextBox);
            this.panel1.Controls.Add(this.HouseSpecialCheckBox);
            this.panel1.Controls.Add(this.PriceBox);
            this.panel1.Controls.Add(this.NameBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.showMenuControl1);
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 666);
            this.panel1.TabIndex = 3;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.DescriptionTextBox.Location = new System.Drawing.Point(159, 206);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(385, 214);
            this.DescriptionTextBox.TabIndex = 19;
            this.DescriptionTextBox.Text = "";
            // 
            // HouseSpecialCheckBox
            // 
            this.HouseSpecialCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.HouseSpecialCheckBox.Location = new System.Drawing.Point(190, 150);
            this.HouseSpecialCheckBox.Name = "HouseSpecialCheckBox";
            this.HouseSpecialCheckBox.Size = new System.Drawing.Size(25, 17);
            this.HouseSpecialCheckBox.TabIndex = 18;
            this.HouseSpecialCheckBox.UseVisualStyleBackColor = true;
            // 
            // PriceBox
            // 
            this.PriceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.PriceBox.Location = new System.Drawing.Point(100, 92);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(267, 31);
            this.PriceBox.TabIndex = 17;
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.NameBox.Location = new System.Drawing.Point(113, 34);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(254, 31);
            this.NameBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label5.Location = new System.Drawing.Point(27, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label4.Location = new System.Drawing.Point(27, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "House Special:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label3.Location = new System.Drawing.Point(27, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label6.Location = new System.Drawing.Point(27, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Name: ";
            // 
            // showMenuControl1
            // 
            this.showMenuControl1.Location = new System.Drawing.Point(207, 200);
            this.showMenuControl1.Name = "showMenuControl1";
            this.showMenuControl1.Size = new System.Drawing.Size(8, 8);
            this.showMenuControl1.TabIndex = 11;
            // 
            // EditMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MenuGrid);
            this.Name = "EditMenuControl";
            this.Size = new System.Drawing.Size(770, 718);
            ((System.ComponentModel.ISupportInitialize)(this.MenuGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MenuGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox DescriptionTextBox;
        private System.Windows.Forms.CheckBox HouseSpecialCheckBox;
        private System.Windows.Forms.TextBox PriceBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private ShowMenuControl showMenuControl1;
    }
}
