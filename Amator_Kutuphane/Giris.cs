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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\ddbb.mdb");
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DodgerBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string sifre = textBox2.Text; 
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Kullanicilar where kullanici_adi='" + textBox1.Text + "' AND parola='" + textBox2.Text + "'";
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form frm = new Form1();
                frm.Show();
                
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış...","[Giriş Hatası]");
            }

            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string girilen = Interaction.InputBox("Lütfen Yönetici Parolasını Giriniz...", "[Yönetici Parola Girişi]","",500,200);
            if (girilen == "Bilgim1711")
            {
                Form frm = new YeniKayit();
                frm.Show();
                this.Hide();
            }
            else MessageBox.Show("Yanlış Parola!", "Hata!");
        }
    }
}
