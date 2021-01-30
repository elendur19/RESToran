
namespace RESToran.PresentationLayer.UserControls
{
    partial class ManageReservationsControl
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
            this.ReservationsGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelReservationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReservationsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ReservationsGrid
            // 
            this.ReservationsGrid.AllowUserToAddRows = false;
            this.ReservationsGrid.AllowUserToDeleteRows = false;
            this.ReservationsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReservationsGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ReservationsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReservationsGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.ReservationsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ReservationsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ReservationsGrid.Location = new System.Drawing.Point(0, 87);
            this.ReservationsGrid.Name = "ReservationsGrid";
            this.ReservationsGrid.ReadOnly = true;
            this.ReservationsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ReservationsGrid.RowTemplate.ReadOnly = true;
            this.ReservationsGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ReservationsGrid.Size = new System.Drawing.Size(787, 615);
            this.ReservationsGrid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "All reservations in restaurant:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(542, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(396, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose date:";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.ConfirmButton.Location = new System.Drawing.Point(542, 50);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(85, 31);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelReservationButton
            // 
            this.CancelReservationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.CancelReservationButton.Location = new System.Drawing.Point(73, 50);
            this.CancelReservationButton.Name = "CancelReservationButton";
            this.CancelReservationButton.Size = new System.Drawing.Size(236, 31);
            this.CancelReservationButton.TabIndex = 6;
            this.CancelReservationButton.Text = "Cancel selected reservation";
            this.CancelReservationButton.UseVisualStyleBackColor = true;
            this.CancelReservationButton.Click += new System.EventHandler(this.CancelReservationButton_Click_1);
            // 
            // ManageReservationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CancelReservationButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReservationsGrid);
            this.Name = "ManageReservationsControl";
            this.Size = new System.Drawing.Size(787, 702);
            ((System.ComponentModel.ISupportInitialize)(this.ReservationsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ReservationsGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancelReservationButton;
    }
}
