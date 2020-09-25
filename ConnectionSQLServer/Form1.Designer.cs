namespace ConnectionSQLServer
{
    partial class Form1
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
            this.dvgInts = new System.Windows.Forms.DataGridView();
            this.btnAllTransactions = new System.Windows.Forms.Button();
            this.btnInsertTr = new System.Windows.Forms.Button();
            this.btnDeleteTr = new System.Windows.Forms.Button();
            this.btnUpdates = new System.Windows.Forms.Button();
            this.btnCustom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgInts)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgInts
            // 
            this.dvgInts.AccessibleName = "dvgInts";
            this.dvgInts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgInts.Location = new System.Drawing.Point(207, 12);
            this.dvgInts.Name = "dvgInts";
            this.dvgInts.Size = new System.Drawing.Size(942, 344);
            this.dvgInts.TabIndex = 0;
            this.dvgInts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgInts_CellContentClick);
            // 
            // btnAllTransactions
            // 
            this.btnAllTransactions.Location = new System.Drawing.Point(25, 288);
            this.btnAllTransactions.Name = "btnAllTransactions";
            this.btnAllTransactions.Size = new System.Drawing.Size(150, 23);
            this.btnAllTransactions.TabIndex = 2;
            this.btnAllTransactions.Text = "All Transactions";
            this.btnAllTransactions.UseVisualStyleBackColor = true;
            this.btnAllTransactions.Click += new System.EventHandler(this.btnAllTransactions_Click);
            // 
            // btnInsertTr
            // 
            this.btnInsertTr.Location = new System.Drawing.Point(25, 40);
            this.btnInsertTr.Name = "btnInsertTr";
            this.btnInsertTr.Size = new System.Drawing.Size(150, 23);
            this.btnInsertTr.TabIndex = 3;
            this.btnInsertTr.Text = "INSERT TRANSACTIONS";
            this.btnInsertTr.UseVisualStyleBackColor = true;
            this.btnInsertTr.Click += new System.EventHandler(this.btnInsertTr_Click);
            // 
            // btnDeleteTr
            // 
            this.btnDeleteTr.Location = new System.Drawing.Point(25, 83);
            this.btnDeleteTr.Name = "btnDeleteTr";
            this.btnDeleteTr.Size = new System.Drawing.Size(150, 23);
            this.btnDeleteTr.TabIndex = 4;
            this.btnDeleteTr.Text = "DELETE TRANSACTIONS";
            this.btnDeleteTr.UseVisualStyleBackColor = true;
            this.btnDeleteTr.Click += new System.EventHandler(this.btnDeleteTr_Click);
            // 
            // btnUpdates
            // 
            this.btnUpdates.Location = new System.Drawing.Point(25, 125);
            this.btnUpdates.Name = "btnUpdates";
            this.btnUpdates.Size = new System.Drawing.Size(150, 23);
            this.btnUpdates.TabIndex = 5;
            this.btnUpdates.Text = "UPDATE TRANSACTIONS";
            this.btnUpdates.UseVisualStyleBackColor = true;
            this.btnUpdates.Click += new System.EventHandler(this.btnUpdates_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(25, 173);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(150, 23);
            this.btnCustom.TabIndex = 6;
            this.btnCustom.Text = "CUSTOMIZED TRANSACTION";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 369);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnUpdates);
            this.Controls.Add(this.btnDeleteTr);
            this.Controls.Add(this.btnInsertTr);
            this.Controls.Add(this.btnAllTransactions);
            this.Controls.Add(this.dvgInts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dvgInts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgInts;
        private System.Windows.Forms.Button btnAllTransactions;
        private System.Windows.Forms.Button btnInsertTr;
        private System.Windows.Forms.Button btnDeleteTr;
        private System.Windows.Forms.Button btnUpdates;
        private System.Windows.Forms.Button btnCustom;
    }
}

