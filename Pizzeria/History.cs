using System;
using System.Windows.Forms;
using Pizzeria.DataAccess;

namespace Pizzeria
{
    public partial class History : Form
    {
        private PizzeriaRepository repository;
        public History()
        {
            repository = new PizzeriaRepository(new ConnectionFactory());
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            try
            {
                dgwOrder.DataSource = repository.FillDataGridHistoryList();
                dgwOrder.Columns[0].Visible = false;
                dgwOrder.Columns[2].HeaderText = "Cena zamówienia, zl";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgwOrder_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgwOrder.Rows[e.RowIndex];
                    int id_zamowienia = Convert.ToInt32(row.Cells["ID_zamowienia"].Value.ToString());

                    dgwDetails.DataSource = repository.FillDataGridDetalsList(id_zamowienia);
                    dgwDetails.Columns[0].Visible = false;
                    dgwDetails.Columns[2].HeaderText = "Cena, zl";
                    dgwDetails.Columns[1].HeaderText = "Nazwa dania";
                    dgwDetails.Columns[4].HeaderText = "Kategoria";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
