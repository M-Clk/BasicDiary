using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajanda_163301053_
{
    public partial class frmLogin : Form
    {
        private static bool girisYapildiMi = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void GirisYap()
        {
            if (KullaniciKontrol(txtKullaniciAdi.Text, txtSifre.Text))
            {
                this.DialogResult = DialogResult.OK; //Sadece şifre doğruysa dialogResult OK olsun.
                this.Close();
            }
            else
            {
                txtKullaniciAdi.Clear();
                txtSifre.Clear();
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış. Tekrar deneyin.");
            }
        }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            GirisYap();
        }
        public static bool getGirisDurumu()
        { return girisYapildiMi; }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool KullaniciKontrol(string kullaniciAdi, string sifre)
        {
            FileStream fileStream = new FileStream(Program.path + "\\users.txt", FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            string simdikiSatir;
            while ((simdikiSatir = streamReader.ReadLine()) != null)
            {
                char[] ayrac = { '|' };
                string[] kolonlar = simdikiSatir.Split(ayrac);
                //kolon index sırası =>  kullanici_adi | sifre
                if (kolonlar[0].ToLower().Equals(kullaniciAdi.ToLower()) && kolonlar[1].Equals(sifre))
                {
                    streamReader.Close();
                    fileStream.Close();
                    return true;
                }
            }
            streamReader.Close();
            fileStream.Close();
            return false;

        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GirisYap();
        }
    }
}
