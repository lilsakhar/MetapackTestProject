using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pizzeria.bl.MailModel;
using Pizzeria.bl.Model;
using Pizzeria.DataAccess;
using Pizzeria.MailServices;


namespace Pizzeria
{
    public partial class MailForm : Form
    {
        private SendMailRepository mailRepository;
        private PizzeriaRepository repository;


        public MailForm()
        {
            mailRepository = new SendMailRepository();
            repository = new  PizzeriaRepository(new ConnectionFactory());
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MailSettings mailSettings = new MailSettings();

            mailSettings.User = txtUserName.Text;
            mailSettings.Pass = txtPass.Text;
            mailSettings.Port = Convert.ToInt32(txtPort.Text);
            mailSettings.Smtptext = txtSmtp.Text;
            mailSettings.Ssl = chkSSL.Checked;

            MailParams mailParams = new MailParams();
            
            mailParams.Totxt = txtTo.Text;
            mailParams.Cctxt = txtCC.Text;
            mailParams.Subject = txtSubject.Text;
            mailParams.Msgbody = txtMessage.Text;
            

            try
            {
                mailRepository.PizzeriaSendOrder(mailSettings, mailParams);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void MailForm_Load(object sender, EventArgs e)
        {

            try
            {
                List<Zamowienie> zamHeader = repository.FillDataGridHistoryList();
                //Bierzemy pierwsze zamówienie poniważ w procedurze jest odwrotnie
                //sortowanie po datach 
                txtTo.Text = zamHeader[0].Email;
                int id_zamowienia = zamHeader[0].ID_zamowienia;
                txtSubject.Text = "Zamówienie N " + id_zamowienia;


                txtMessage.Text = "Dzień dobry, " + zamHeader[0].Klient +
                                  " . Dziękujemy za zamówienie w naszej restauracii. \r\n"
                                  + "Wasze zamówienie zostało wykonane: \r\n";

                var list = repository.FillDataGridDetalsList(id_zamowienia);
                foreach (Szczegoly s in list)
                {
                    txtMessage.Text += s.Nazwa_dania + ", cena: "
                                                                 + s.Cena.ToString()
                                                                 + ", ilość: " + s.Ilosc.ToString()
                                                                 + " \r\n";
                    
                }
                txtMessage.Text += "\r\nCena zamówienia: " + zamHeader[0].Cena_zam.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
