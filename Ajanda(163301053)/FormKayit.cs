using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajanda_163301053_
{
    public partial class FormKayit : Form
    {
        public FormKayit()
        {
            InitializeComponent();
        }
        public FormKayit(string adi, string soyadi, string telefon, string gsm, string email, string meslek, string adres, DateTime dogumTarihi, int maas, bool EvliMi, bool KadinMi)
        {
            InitializeComponent();
            rdErkek.Checked = true;
            rdBekar.Checked = true;

            txtAd.Text = adi;
            txtSoyad.Text = soyadi;
            txtTelefon.Text = telefon;
            txtGsm.Text = gsm;
            txtEmail.Text = email;
            txtMeslek.Text = meslek;
            txtAdres.Text = adres;

            dateTimePicker1.Value = dogumTarihi;

            nmrcMaas.Value = maas;
            rdEvli.Checked = EvliMi;//rdEvli ve rdBekar aynı groupBox içinde olduklarından rdEvli aktif olursa rdBekar pasif olur.
            rdKadin.Checked = KadinMi;//yukardakinin aynısı cinsiyet için de geçerli
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Sifirla();
        }
        private void PersonelKaydet()
        {
            Personel instancePersonel = new Personel(txtAd.Text, txtSoyad.Text);
            instancePersonel.DogumT = dateTimePicker1.Text;
            instancePersonel.Meslek = txtMeslek.Text;
            instancePersonel.Cinsiyet = (Program.Cinsiyet)Convert.ToInt32(rdKadin.Checked);//kadın=1 olduğundan rdKadın.Checked durumu neyse cinsiyeti odur.
            instancePersonel.MedeniDurum = (Program.medeniDurum)Convert.ToInt32(rdEvli.Checked);//yukardakinin aynısı bunun için de geçerli
            instancePersonel.Maas = Convert.ToInt32(nmrcMaas.Value);
            instancePersonel.Email = txtEmail.Text;
            instancePersonel.Adres = txtAdres.Text;
            Ajanda evTelefonu = new Ajanda(etiketTemizle(lblIsTelefonu.Text), txtTelefon.Text);
            Ajanda gsm = new Ajanda(etiketTemizle(lblGsm.Text), txtGsm.Text);
            List<Ajanda> ajandaList = new List<Ajanda>();
            ajandaList.Add(evTelefonu);
            ajandaList.Add(gsm);
            instancePersonel.Telefonlar = ajandaList;

            DosyaIslemleri dosya = new DosyaIslemleri();
            dosya.DosyayaYaz(instancePersonel);
            Sifirla();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            PersonelKaydet();
        }
        string etiketTemizle(string etiket)
        {
            return etiket.Remove(etiket.IndexOf(':') - 1);
        }
        void Sifirla()
        {
            foreach (var group in Controls)
            {
                if (group is GroupBox)
                    foreach (var item in ((GroupBox)group).Controls)
                    {
                        if (item is TableLayoutPanel)
                            foreach (var controlOfTable in ((TableLayoutPanel)item).Controls)
                            {
                                if (controlOfTable is TextBox)
                                    ((TextBox)controlOfTable).Clear();
                                if (controlOfTable is DateTimePicker)
                                    ((DateTimePicker)controlOfTable).Value = DateTime.Now;
                                if (controlOfTable is NumericUpDown)
                                    ((NumericUpDown)controlOfTable).Value = 0;
                                if (controlOfTable is GroupBox)
                                    foreach (var radio in ((GroupBox)controlOfTable).Controls)
                                    {
                                        if (radio is RadioButton)
                                        {
                                            AutoCheckDegistir((RadioButton)radio);
                                            ((RadioButton)radio).Checked = false;
                                            AutoCheckDegistir((RadioButton)radio);
                                        }
                                    }
                            }
                    }
            }


        }
        void AutoCheckDegistir(RadioButton rd)
        {
            rd.AutoCheck = !rd.AutoCheck;
        }

        private void FormKayit_Load(object sender, EventArgs e)
        {

        }
    }
}
