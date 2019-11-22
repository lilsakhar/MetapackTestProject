using Pizzeria.DataAccess;
using System;
using System.Windows.Forms;

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
                repository.AddCategory(ID_kategory, txtCategory.Text.Trim());

                if (ID_kategory == 0)
                    MessageBox.Show("Categoria została dodana", "Information"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Nazwa categorii została zmieniona", "Information"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgwKategory.DataSource = repository.FillDataGridView(txtSearch.Text);
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
            btnAdd.Text = "Dodaj";
            btnDelete.Enabled = false;

        }

        private void dgwKategory_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgwKategory.CurrentRow.Index != -1)
                {
                    ID_kategory = Convert.ToInt32(dgwKategory.CurrentRow.Cells[0].Value.ToString());
                    txtCategory.Text = dgwKategory.CurrentRow.Cells[1].Value.ToString();
                    btnAdd.Text = "Zmień";
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
                if (MessageBox.Show("Usunąć categorię?", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    repository.DeleteCategory(ID_kategory);
                    Clear();
                    dgwKategory.DataSource = repository.FillDataGridView("");
                    MessageBox.Show("Categoria została usunięta", "Information"
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
