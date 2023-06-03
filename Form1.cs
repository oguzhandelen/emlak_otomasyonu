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

namespace Emlkak_Program
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5VLMNHH\\SQLEXPRESS;Initial Catalog=sitelerproje;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader read;
        public Form1()
        {
            InitializeComponent();
        }
        Emlak_Kayit k = new Emlak_Kayit();
        private void button1_Click(object sender, EventArgs e)
        {
            k.kullanıcı(textBox1, textBox2);
            this.Hide();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 şifre = new Form3();
            şifre.Show();
            this.Hide();
      

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //k.yenikullanıcı(textBox3,textBox4,textBox5,textBox6,textBox7,groupBox2);
            if(textBox3.Text!=""&& textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                if (textBox5.Text == textBox6.Text)
                {

                    baglanti.Open();

                    string kayit = "insert into Table_1 (adsoyad,kullanıcıadı,sifre,sifretekrar,email) values (@adsoyad,@kullanıcıadı,@sifre,@sifretekrar,@email)";
                    komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@adsoyad", textBox3.Text);
                    komut.Parameters.AddWithValue("@kullanıcıadı", textBox4.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox5.Text);
                    komut.Parameters.AddWithValue("@sifretekrar", textBox6.Text);
                    komut.Parameters.AddWithValue("@email", textBox7.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Üye Eklendi");
                    baglanti.Close();

                }
                else
                {
                    MessageBox.Show("şifreler uyuşmuyor", "Hata");

                }
            }
            else
            {
                MessageBox.Show("Bilgileri doldurunuz.");
            }
            

        }
    }

}
// if (textBox1.Text == "siteadmin" && textBox2.Text == "site12345")
            //{
                //Form2 emlakkayit = new Form2();
//emlakkayit.Show();
                //this.Hide();
           // }