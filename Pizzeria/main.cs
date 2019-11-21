using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Pizzeria.bl;
using System.IO;
using System.Linq;
using Pizzeria.bl.MailModel;
using Pizzeria.bl.Model;
using Pizzeria.DataAccess;

namespace Pizzeria
{
    public partial class Main : Form
    {
        private PizzeriaRepository repository;
        private TabPage[] tabPageArray;
        private DataGridView[] dataGridArray;

        public Main()
        {
            repository = new PizzeriaRepository(new ConnectionFactory());
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            var list = repository.GetAllCategories();
            tabPageArray = new TabPage[list.Count];
            dataGridArray = new DataGridView[list.Count];
            
            int i = 0;
            foreach (Kategoria k in list)
            {
                string tabName = k.Nazwa_Kategoria;
                TabPage tp = new TabPage(tabName);
                
                tbCategory.TabPages.Add(tp);
                tp.Name = "TabPage" + i;
  
                tabPageArray[i] = tp;

                DataGridView dataGridView = new DataGridView();
                tbCategory.TabPages[i].Controls.Add(dataGridView);

                dataGridView.DataSource = repository.FillDataGrid(tabName);

                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView.AutoGenerateColumns = false;
                dataGridView.Cursor = Cursors.Hand;
                dataGridView.Location = new Point(10, 10);
                dataGridView.ColumnHeadersVisible = true;
                dataGridView.ReadOnly = true;
                dataGridView.RowHeadersWidth = 30;
                dataGridView.RowTemplate.Height = 20;
                dataGridView.Size = new Size(454, 150);
                dataGridView.Columns[2].DisplayIndex = 0;

                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[3].Visible = false;
                //dataGridView.Columns[2].HeaderText = "Nazwa";
                //dataGridView.Columns[1].HeaderText = "Cena, zl";
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dataGridView.EnableHeadersVisualStyles = false;
                dataGridView.Name = "DataGrid" + i;
                dataGridArray[i] = dataGridView;

                PictureBox pbKategory = new PictureBox();
                tbCategory.TabPages[i].Controls.Add(pbKategory);
                pbKategory.Location = new Point(500, 10);
                pbKategory.Size = new Size(150, 150);
                try
                {
                    FillPictureBox(k.ID_kategoria, pbKategory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                i++;
            }
            repository.ClearOrderLines(0);
        }

        void FillPictureBox(int id, PictureBox pb)
        { 
            var pictureBytes = repository.GetPicture(id);
            if (pictureBytes != null && pictureBytes.Length > 0)
            {
                var mem = new MemoryStream(pictureBytes);
                pb.Image = Image.FromStream(mem);
                pb.Visible = true;
            }
        }
        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category f = new Category();    
            f.ShowDialog();                 
            f.Dispose();                    
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (TabPage tabPage in tabPageArray)
                {
                    if (tbCategory.SelectedTab == tabPage)
                    {
                        if (dataGridArray[i].SelectedRows.Count > 0)
                        {
                            DataGridViewSelectedRowCollection rows = dataGridArray[i].SelectedRows;
                            foreach (DataGridViewRow row in rows)
                            {
                                int iD_dania = Convert.ToInt32(row.Cells[0].Value.ToString());
                                repository.AddLine(iD_dania);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Zaznać danie w górnej tabieli", "Information"
                                , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    i++;
                }
                        
                dgwOrder.DataSource = repository.FillDataGridOrder();
                dgwOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgwOrder.RowCount > 0)
                {
                    dgwOrder.Columns[0].Visible = false;
                    dgwOrder.Visible = true;
                    lblText.Text = "Zamówienie";
                    btnMinus.Enabled = true;
                    btnMakeOrder.Enabled = true;
                    lblCena.Text = repository.CalculateOrderSum();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bntMinus_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgwOrder.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                int iD_dania = Convert.ToInt32(row.Cells[0].Value.ToString());
                repository.ClearOrderLines(iD_dania);
                //Refresh grid
                dgwOrder.DataSource = repository.FillDataGridOrder();
                //Refresh price
                lblCena.Text = (repository.CalculateOrderSum());
            }
        }

        private void btnMakeOrder_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Proszę wypelnić imię klienta", "Information"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txtName;
                return;
            }
            if (txtSurname.Text == "")
            {
                MessageBox.Show("Proszę wypelnić nazwisko klienta", "Information"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txtSurname;
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Proszę wypelnić email klienta", "Information"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ActiveControl = txtEmail;
                return;
            }
            try
            {
                repository.CreateOrder(txtName.Text,
                                           txtSurname.Text,
                                           txtEmail.Text,
                                      txtUwagi.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("Zamówienie zostało wykonane", "Information"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSend.Enabled = true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            repository.ClearOrderLines(0);
        }

        private void History_Click(object sender, EventArgs e)
        {
            History h = new History();  
            
            h.ShowDialog();                 
            h.Dispose();                    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            repository.ClearOrderLines(0);
            ActiveForm.Close();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MailForm m = new MailForm();
            m.ShowDialog();
            m.Dispose();
        }
    }
}
