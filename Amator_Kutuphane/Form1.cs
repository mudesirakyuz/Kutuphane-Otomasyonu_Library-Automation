using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace Amator_Kutuphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ Application.StartupPath + "\\ddbb.mdb");
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        BindingSource bs = new BindingSource();
        BindingSource bss = new BindingSource();
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = button3.Visible = true;
            button1.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = button3.Visible = false;
            button1.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            comboBox1.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool a = true;
            con.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Kitaplar (barkod,kitap_adi,yazar,sayfa,tur) Values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() +"','"+int.Parse(textBox4.Text)+"','"+comboBox1.SelectedItem.ToString()+ "')", con);
            try
            {
                a = true;
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException)
            {
                a = false;
                MessageBox.Show("Bu barkod kullanılmaktadır. Lütfen farklı bir barkod giriniz...", "[Barkod Çakışması]");
            }
            if (a==true)
            {
                MessageBox.Show("Kayıt Başarıyla Gerçekleşti...");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.Text = "";
            }
            verileri_cek_guncelle();
            con.Close();
        }
        void verileri_cek_guncelle()
        {
            string sec = "select * from Kitaplar";//bölümlerdeki bütün kayıtları fieldlerı seç(tanımlama)
            OleDbDataAdapter da = new OleDbDataAdapter(sec, con);//(uygulama)kayıtlar çekildi şuan data adaptörde
            if (ds.Tables["Kitaplar1"] == null) { }
            else ds.Tables["Kitaplar1"].Clear();
            da.Fill(ds, "Kitaplar1");//ds nin bölümler tablosuna doldur
            

        }
        void verileri_cek_sil()
        {
            string sec = "select * from Kitaplar";//bölümlerdeki bütün kayıtları fieldlerı seç(tanımlama)
            OleDbDataAdapter da = new OleDbDataAdapter(sec, con);//(uygulama)kayıtlar çekildi şuan data adaptörde
            if (ds.Tables["Kitaplar2"] == null) { }
            else ds.Tables["Kitaplar2"].Clear();
            da.Fill(ds, "Kitaplar2");//ds nin bölümler tablosuna doldur
            

        }
        void verileri_cek_ara()
        {
            string sec = "select * from Kitaplar";//bölümlerdeki bütün kayıtları fieldlerı seç(tanımlama)
            OleDbDataAdapter da = new OleDbDataAdapter(sec, con);//(uygulama)kayıtlar çekildi şuan data adaptörde
            if (ds.Tables["Kitaplar3"] == null) { }
            else ds.Tables["Kitaplar3"].Clear();
            da.Fill(ds, "Kitaplar3");//ds nin bölümler tablosuna doldur
            

        }
        void verileri_cek_kullanici()
        {
            string sec = "select kullanici_adi from Kullanicilar";//bölümlerdeki bütün kayıtları fieldlerı seç(tanımlama)
            OleDbDataAdapter da = new OleDbDataAdapter(sec, con);//(uygulama)kayıtlar çekildi şuan data adaptörde
            if (dss.Tables["Kullanicilar"] == null) { }
            else dss.Tables["Kullanicilar"].Clear();
            da.Fill(dss, "Kullanicilar");//ds nin bölümler tablosuna doldur
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button5.Visible = button6.Visible = false;
            button4.Enabled = true;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            comboBox2.Enabled = false;
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button6.Visible = button5.Visible = true;
            button4.Enabled = false;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            bool a = true;
            OleDbCommand cmd = new OleDbCommand("update Kitaplar set barkod = @barkod, kitap_adi = @kitap_adi, yazar = @yazar, sayfa = @sayfa, tur = @tur where kitap_sayisi = @kitap_sayisi", con);
            cmd.Parameters.AddWithValue("@barkod", textBox5.Text); 
            cmd.Parameters.AddWithValue("@kitap_adi", textBox6.Text);
            cmd.Parameters.AddWithValue("@yazar", textBox7.Text);
            cmd.Parameters.AddWithValue("@sayfa", int.Parse(textBox8.Text));
            cmd.Parameters.AddWithValue("@tur", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@kitap_sayisi", int.Parse(textBox10.Text));
            
            try
            {
                a = true;
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException)
            {
                a = false;
                MessageBox.Show("Bu barkod kullanılmaktadır. Lütfen farklı bir barkod giriniz...", "[Barkod Çakışması]");
            }
            if (a == true)
            {
                MessageBox.Show("Kayıt Başarıyla Gerçekleşti...");
            }
            verileri_cek_guncelle();
            con.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox11.Enabled = textBox12.Enabled = false;
            if(textBox9.Text=="") textBox11.Enabled = textBox12.Enabled = true;
            string sorgu = "Select * From Kitaplar Where kitap_adi Like '%" + textBox9.Text + "%'";//string olduğundan Like % işareti ilk girilen harften itibaren aramaya başlar
            OleDbDataAdapter dr = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            dr.Fill(ds, "Kitaplar1");
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox12.Enabled = textBox9.Enabled = false;
            if (textBox11.Text == "") textBox9.Enabled = textBox12.Enabled = true;
            string sorgu = "Select * From Kitaplar Where barkod Like '%" + textBox11.Text + "%'";//string olduğundan Like % işareti ilk girilen harften itibaren aramaya başlar
            OleDbDataAdapter dr = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            dr.Fill(ds, "Kitaplar1");
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox11.Enabled = textBox9.Enabled = false;
            if (textBox12.Text == "") textBox9.Enabled = textBox11.Enabled = true;
            string sorgu = "Select * From Kitaplar Where yazar Like '%" + textBox12.Text + "%'";//string olduğundan Like % işareti ilk girilen harften itibaren aramaya başlar
            OleDbDataAdapter dr = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            dr.Fill(ds, "Kitaplar1");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            DialogResult c = MessageBox.Show("Bu kaydı silmek istedğinize emin misiniz?", "Bilgi", MessageBoxButtons.YesNo);
            if (c == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from Kitaplar where kitap_sayisi=@kitap_sayisi";
                cmd.Parameters.AddWithValue("@kitap_sayisi", int.Parse(textBox10.Text));
                cmd.ExecuteNonQuery();
                verileri_cek_guncelle();
                MessageBox.Show("Kaydınız Silindi");

            }
            con.Close();
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox14.Enabled = textBox15.Enabled = false;
            if (textBox13.Text == "") textBox14.Enabled = textBox15.Enabled = true;
            string sorgu = "Select * From Kitaplar Where yazar Like '%" + textBox13.Text + "%'";//string olduğundan Like % işareti ilk girilen harften itibaren aramaya başlar
            OleDbDataAdapter dr = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            dr.Fill(ds, "Kitaplar2");
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            textBox13.Enabled = textBox15.Enabled = false;
            if (textBox14.Text == "") textBox13.Enabled = textBox15.Enabled = true;
            string sorgu = "Select * From Kitaplar Where barkod Like '%" + textBox14.Text + "%'";//string olduğundan Like % işareti ilk girilen harften itibaren aramaya başlar
            OleDbDataAdapter dr = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            dr.Fill(ds, "Kitaplar2");
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            textBox13.Enabled = textBox14.Enabled = false;
            if (textBox15.Text == "") textBox13.Enabled = textBox14.Enabled = true;
            string sorgu = "Select * From Kitaplar Where kitap_adi Like '%" + textBox15.Text + "%'";//string olduğundan Like % işareti ilk girilen harften itibaren aramaya başlar
            OleDbDataAdapter dr = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            dr.Fill(ds, "Kitaplar2");
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            textBox17.Enabled = false;
            if (textBox19.Text == "") textBox17.Enabled = true;
            string sorgu = "Select * From Kitaplar Where kitap_adi Like '%" + textBox19.Text + "%'";//string olduğundan Like % işareti ilk girilen harften itibaren aramaya başlar
            OleDbDataAdapter dr = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            dr.Fill(ds, "Kitaplar3");
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            textBox19.Enabled =  false;
            if (textBox17.Text == "") textBox19.Enabled = true;
            string sorgu = "Select * From Kitaplar Where yazar Like '%" + textBox17.Text + "%'";//string olduğundan Like % işareti ilk girilen harften itibaren aramaya başlar
            OleDbDataAdapter dr = new OleDbDataAdapter(sorgu, con);
            ds.Clear();
            dr.Fill(ds, "Kitaplar3");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string girilen = Interaction.InputBox("Lütfen Yönetici Parolasını Giriniz...", "[Yönetici Parola Girişi]", "", 500, 200);
            if (girilen == "Bilgim1711")
            {
                con.Open();
                DialogResult c = MessageBox.Show("Bu kaydı silmek istedğinize emin misiniz?", "Bilgi", MessageBoxButtons.YesNo);
                if (c == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from Kullanicilar where kullanici_adi=@kullanici_adi";
                    cmd.Parameters.AddWithValue("@kullanici_adi", textBox18.Text);
                    cmd.ExecuteNonQuery();
                    verileri_cek_kullanici();
                    MessageBox.Show("Kaydınız Silindi");

                }
                con.Close();
            }
            else MessageBox.Show("Yanlış Parola!", "Hata!");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Kitaplar1"] == null)
            {
                verileri_cek_guncelle();
                bs.DataSource = ds.Tables["Kitaplar1"];
                dataGridView1.DataSource = bs;
                textBox10.DataBindings.Add("Text", bs, "kitap_sayisi");
                textBox5.DataBindings.Add("Text", bs, "barkod");
                textBox6.DataBindings.Add("Text", bs, "kitap_adi");
                textBox7.DataBindings.Add("Text", bs, "yazar");
                textBox8.DataBindings.Add("Text", bs, "sayfa");
                comboBox2.DataBindings.Add("SelectedItem", bs, "tur");

            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Kitaplar2"] == null)
            {
                verileri_cek_sil();
                bs.DataSource = ds.Tables["Kitaplar2"];
                dataGridView2.DataSource = bs;
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Kitaplar3"] == null)
            {
                verileri_cek_ara();
                bs.DataSource = ds.Tables["Kitaplar3"];
                dataGridView3.DataSource = bs;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (ds.Tables["Kullanicilar"] == null)
            {
                verileri_cek_kullanici();
                bss.DataSource = dss.Tables["Kullanicilar"];
                dataGridView4.DataSource = bss;
                textBox18.DataBindings.Add("Text", bss, "kullanici_adi");
            }
            
        }
    }
}
