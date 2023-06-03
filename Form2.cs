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
using System.Drawing;
using System.Drawing.Printing;

namespace Emlkak_Program
{
    //add ıtems
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
          SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-5VLMNHH\\SQLEXPRESS;Initial Catalog=sitelerproje;Integrated Security=True");
            private void verilerigöster()
            {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Table_4", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());
                ekle.SubItems.Add(oku["il"].ToString());
                ekle.SubItems.Add(oku["mahalle"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
            }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void BtnGoruntule_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Table_4 (id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira,il,mahalle) values ('" + textBox7.Text.ToString() + "','" + textBox10.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox9.Text.ToString()+ "')", baglan);
            komut.ExecuteNonQuery();
            bool aranankayitkontrolu = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox7.Text)
                {
                    aranankayitkontrolu = true;
                    MessageBox.Show(textBox7.Text + "Bu kayıt zaten mevcut");
                }
            }
            baglan.Close();
            verilerigöster();
        }
        int id = 0;
        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from Table_4 where id =(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox7.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox10.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[11].Text;
            textBox9.Text = listView1.SelectedItems[0].SubItems[12].Text;

        }

        private void BtnDüzelt_Click(object sender, EventArgs e)
        {
           baglan.Open();
            SqlCommand komut = new SqlCommand("update Table_4 set id='" + textBox7.Text.ToString() + "',site='" + textBox10.Text.ToString() + "',oda='" + comboBox3.Text.ToString() + "',metre='" + textBox1.Text.ToString() + "',fiyat='" + textBox2.Text.ToString() + "',blok='" + comboBox4.Text.ToString() + "',no='" + textBox6.Text.ToString() + "',adsoyad='" + textBox4.Text.ToString() + "',telefon='" + textBox5.Text.ToString() + "',notlar='" + textBox3.Text.ToString() + "',satkira='" + comboBox2.Text.ToString() + "',il='" + textBox8.Text.ToString() + "',mahalle='" + textBox9.Text.ToString() + "' where id=" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_TextChanged(object sender, EventArgs e)
        {
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from Table_4 where mahalle like '%" + textBox11.Text + "%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());
                ekle.SubItems.Add(oku["il"].ToString());
                ekle.SubItems.Add(oku["mahalle"].ToString());

                listView1.Items.Add(ekle);

            }
            
            baglan.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox5.TextLength == 12)
            {
                MessageBox.Show("Lütfen geçerli bir numara giriniz!");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            pd.Print();

        }
        private void pd_PrintPage(Object sender,PrintPageEventArgs e)
        {
            Font print_font = new Font("Times New Roman", 12);
            e.Graphics.DrawString(textBox12.Text, print_font, Brushes.Black, 0, 0);

        }
    }




    
}
//id like '%" + textBox7.Text + "%' and site like '%" + textBox10.Text + "%' and oda like '%" + comboBox3.Text + "%' and metre like '%" + textBox1.Text + "%' and fiyat like '%" + textBox2.Text + "%' and blok like '%" + comboBox4.Text + "%' and no like '%" + textBox6.Text + "%' and adsoyad like '%" + textBox4.Text + "%' and telefon like '%" + textBox5.Text + "%' and notlar like '%" + textBox3.Text + "%' and satkira like '%" + comboBox2.Text + "%' and il like '%" + textBox8.Text +
                