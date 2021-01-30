
namespace RESToran.PresentationLayer.UserControls
{
    partial class ViewReservationsControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MenuGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuGrid
            // 
            this.MenuGrid.AllowUserToAddRows = false;
            this.MenuGrid.AllowUserToDeleteRows = false;
            this.MenuGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MenuGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MenuGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.MenuGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MenuGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MenuGrid.Location = new System.Drawing.Point(0, 63);
            this.MenuGrid.Name = "MenuGrid";
            this.MenuGrid.ReadOnly = true;
            this.MenuGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.MenuGrid.RowTemplate.ReadOnly = true;
            this.MenuGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MenuGrid.Size = new System.Drawing.Size(787, 639);
            this.MenuGrid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "All reservations in restaurant:";
            // 
            // ViewReservationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MenuGrid);
            this.Name = "ViewReservationsControl";
            this.Size = new System.Drawing.Size(787, 702);
            ((System.ComponentModel.ISupportInitialize)(this.MenuGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MenuGrid;
        private System.Windows.Forms.Label label1;
    }
}
