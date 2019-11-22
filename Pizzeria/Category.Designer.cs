namespace Pizzeria
{
    partial class Category
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
            this.lblKategory = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.dgwKategory = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCalsel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwKategory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKategory
            // 
            this.lblKategory.AutoSize = true;
            this.lblKategory.Location = new System.Drawing.Point(11, 96);
            this.lblKategory.Name = "lblKategory";
            this.lblKategory.Size = new System.Drawing.Size(69, 17);
            this.lblKategory.TabIndex = 0;
            this.lblKategory.Text = "Kategoria";
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(85, 94);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(187, 22);
            this.txtCategory.TabIndex = 1;
            // 
            // dgwKategory
            // 
            this.dgwKategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwKategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwKategory.ColumnHeadersVisible = false;
            this.dgwKategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgwKategory.Location = new System.Drawing.Point(295, 94);
            this.dgwKategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgwKategory.Name = "dgwKategory";
            this.dgwKategory.ReadOnly = true;
            this.dgwKategory.RowHeadersWidth = 30;
            this.dgwKategory.RowTemplate.Height = 20;
            this.dgwKategory.Size = new System.Drawing.Size(404, 224);
            this.dgwKategory.TabIndex = 4;
            this.dgwKategory.DoubleClick += new System.EventHandler(this.dgwKategory_DoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(295, 38);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(297, 22);
            this.txtSearch.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 286);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 29);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(101, 286);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Usuń";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCalsel
            // 
            this.btnCalsel.Location = new System.Drawing.Point(189, 286);
            this.btnCalsel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalsel.Name = "btnCalsel";
            this.btnCalsel.Size = new System.Drawing.Size(83, 29);
            this.btnCalsel.TabIndex = 3;
            this.btnCalsel.Text = "Wyczyść";
            this.btnCalsel.UseVisualStyleBackColor = true;
            this.btnCalsel.Click += new System.EventHandler(this.btnCansel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(616, 34);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Szukaj";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button4_Click);
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 337);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCalsel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgwKategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.lblKategory);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Category";
            this.Text = "Kategoria";
            this.Load += new System.EventHandler(this.Category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwKategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKategory;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.DataGridView dgwKategory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCalsel;
        private System.Windows.Forms.Button btnSearch;
    }
}