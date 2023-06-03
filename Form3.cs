using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security;
using System.Net.Mail;


namespace Emlkak_Program
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public bool MailGonder(string konu, string icerik)
        {

            MailMessage email = new MailMessage();
            email.From = new MailAddress("yazilimdunyasi14@hotmail.com");
            email.To.Add(textBox3.Text); //göndereceğimiz mail adresi
            email.Subject = konu; //mail konusu
            email.Body = icerik; //mail içeriği 
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential("yazilimdunyasi14@hotmail.com", "yazilimdunyasi1");
            smtp.Port = 587;
            smtp.Host = "smtp.live.com";
            smtp.EnableSsl = true;
            smtp.Send(email);
            object userState = true;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(email, (object)email);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                MessageBox.Show(ex.Message);
            }
            return kontrol;
        }
        string sifre;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5VLMNHH\\SQLEXPRESS;Initial Catalog=sitelerproje;Integrated Security=True");
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                SqlCommand komut = new SqlCommand("select * from Table_1 where email='" + textBox3.Text + "'");
                komut.Connection = baglanti;
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    sifre = oku["sifre"].ToString();
                    MailGonder("ŞİFRE HATIRLATMA", "Şifreniz: " + sifre);
                    MessageBox.Show("Şifreniz e-postanıza gönderildi.Giriş yapabilirsiniz");
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Girmiş olduğunuz e-posta adresiniz sistemde kayıtlı değil!");
                    baglanti.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Mail gönderme hatası");
            }
        }
    }




        //k.şifre(textBox3,groupBox2);
    
}
