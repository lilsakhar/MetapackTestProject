using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using Pizzeria.bl;
using System.IO;
using Pizzeria.DataAccess;

namespace Pizzeria
{

    public partial class Category : Form
    {
        private PizzeriaRepository repository;
        int ID_kategory = 0;

        public Category()
        {
            repository = new PizzeriaRepository(new ConnectionFactory());
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                repository.AddCategory(ID_kategory,txtCategory.Text.Trim());

                if (ID_kategory == 0)
                    MessageBox.Show("Saved successfully", "Information"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Updated successfully", "Information"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgwKategory.DataSource = repository.FillDataGridView(txtSearch.Text); 
                    dgwKategory.Columns[0].Visible = false;
                    dgwKategory.Columns[2].Visible = false;
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dgwKategory.DataSource = repository.FillDataGridView("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void Category_Load(object sender, EventArgs e)
        {
            try
            {
                dgwKategory.DataSource = repository.FillDataGridView("");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            Clear();
        }

        private void btnCansel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            txtCategory.Text = "";
            ID_kategory = 0;
            btnAdd.Text = "Save";
            btnDelete.Enabled = false;

        }

        private void dgwKategory_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if(dgwKategory.CurrentRow.Index != -1)
                {
                    ID_kategory = Convert.ToInt32(dgwKategory.CurrentRow.Cells[0].Value.ToString());
                    txtCategory.Text = dgwKategory.CurrentRow.Cells[1].Value.ToString();
                    btnAdd.Text = "Update";
                    btnDelete.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Do you really want to delete this record?","Message",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    repository.DeleteCategory(ID_kategory);
                    Clear();
                    dgwKategory.DataSource = repository.FillDataGridView("");
                    MessageBox.Show("Deleted successfully", "Information"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgwKategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
