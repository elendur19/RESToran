
namespace RESToran.PresentationLayer.UserControls
{
    partial class EditTablesControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.TablesGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.EditTablePanel = new System.Windows.Forms.Panel();
            this.DescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.NumberOfSeatsBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TablesGrid)).BeginInit();
            this.EditTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F);
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "All restaurant tables";
            // 
            // TablesGrid
            // 
            this.TablesGrid.AllowUserToAddRows = false;
            this.TablesGrid.AllowUserToDeleteRows = false;
            this.TablesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TablesGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TablesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablesGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.TablesGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TablesGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TablesGrid.Location = new System.Drawing.Point(0, 62);
            this.TablesGrid.Name = "TablesGrid";
            this.TablesGrid.ReadOnly = true;
            this.TablesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.TablesGrid.RowTemplate.ReadOnly = true;
            this.TablesGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TablesGrid.Size = new System.Drawing.Size(775, 654);
            this.TablesGrid.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.button1.Location = new System.Drawing.Point(582, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditTablePanel
            // 
            this.EditTablePanel.Controls.Add(this.DescriptionTextBox);
            this.EditTablePanel.Controls.Add(this.NumberOfSeatsBox);
            this.EditTablePanel.Controls.Add(this.label5);
            this.EditTablePanel.Controls.Add(this.label2);
            this.EditTablePanel.Controls.Add(this.label3);
            this.EditTablePanel.Location = new System.Drawing.Point(0, 62);
            this.EditTablePanel.Name = "EditTablePanel";
            this.EditTablePanel.Size = new System.Drawing.Size(775, 654);
            this.EditTablePanel.TabIndex = 5;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.DescriptionTextBox.Location = new System.Drawing.Point(269, 235);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(385, 214);
            this.DescriptionTextBox.TabIndex = 27;
            this.DescriptionTextBox.Text = "";
            // 
            // NumberOfSeatsBox
            // 
            this.NumberOfSeatsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.NumberOfSeatsBox.Location = new System.Drawing.Point(309, 162);
            this.NumberOfSeatsBox.Name = "NumberOfSeatsBox";
            this.NumberOfSeatsBox.Size = new System.Drawing.Size(254, 31);
            this.NumberOfSeatsBox.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label5.Location = new System.Drawing.Point(122, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(122, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Number of seats: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label3.Location = new System.Drawing.Point(121, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 31);
            this.label3.TabIndex = 23;
            this.label3.Text = "Add Food to Menu";
            // 
            // EditTablesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditTablePanel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TablesGrid);
            this.Name = "EditTablesControl";
            this.Size = new System.Drawing.Size(775, 716);
            ((System.ComponentModel.ISupportInitialize)(this.TablesGrid)).EndInit();
            this.EditTablePanel.ResumeLayout(false);
            this.EditTablePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView TablesGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel EditTablePanel;
        private System.Windows.Forms.RichTextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox NumberOfSeatsBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
