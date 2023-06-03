using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Emlkak_Program
{
    class Emlak_Kayit
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5VLMNHH\\SQLEXPRESS;Initial Catalog=sitelerproje;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader read;
        Form2 emlakkayit = new Form2();
        public SqlDataReader kullanıcı(TextBox kullanıcıadı, TextBox sifre)
        {
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select *from Table_1 where kullanıcıadı = '" + kullanıcıadı.Text + "'AND sifre='" + sifre.Text + "'  ";
            read = komut.ExecuteReader();
            if (read.Read() == true)
            {
                MessageBox.Show("Giriş Başarılı");
                emlakkayit.Show();

            }
            else
            {
                MessageBox.Show("Bilgilerinizi kontrol ediniz");
               

            }

            baglanti.Close();
            return read;
        }
        public void yenikullanıcı(TextBox adsoyad, TextBox kullanıcıadı, TextBox şifre, TextBox şifretekrar, TextBox email,GroupBox grup)

        {
            if (şifre.Text == şifretekrar.Text)
            {
                
                baglanti.Open();
                
                string kayit = "insert into Table_1 (adsoyad,kullanıcıadı,sifre,sifretekrar,email) values (@adsoyad,@kullanıcıadı,@sifre,@sifretekrar,@email)";
                komut = new SqlCommand(kayit,baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Üye Eklendi");
                baglanti.Close();
                foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
            }
            else
            {
                MessageBox.Show("şifreler uyuşmuyor", "Hata");

            }
        }
       
        //public void şifre(TextBox email, GroupBox grup)
        //{
            /*if (email.Text == read["email"].ToString() )
            {
                baglanti.Open();
                komut = new SqlCommand("select *from Table_1 where email='" + email.Text + "'", baglanti);
                read = komut.ExecuteReader();
                if (read.Read() == true)
                {
                    
                        baglanti.Close();
                        baglanti.Open();
                    komut = new SqlCommand("update Table_1 set email='" + email.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("İşlem başarılı");
                        foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";

       
                }
             
                else
                {
                    MessageBox.Show("Bilgilerinizi kontrol ediniz", "Hata1");

                }
                baglanti.Close();
            }
            else
            {
              MessageBox.Show("Şifreler uyuşmuyor", "Hata2");
            }*/
        //}
    }
}           
       
   

//else
                  /// {
                    //MessageBox.Show("Kullanıcı adı hariç bilgilerinizi kontrol ediniz");
                  /// }
