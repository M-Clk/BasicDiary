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
    public partial class FormArama : Form
    {
        public FormArama()
        {
            InitializeComponent();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            PersonelArama();   
        }
        void PersonelArama()
        {
            foreach (var instancePersonel in Program.personelListesi)
            {
                if(instancePersonel.Ad.ToLower().Equals(txtAdArama.Text.ToLower()))
                {
                    
                    FormKayit kayit = new FormKayit(
                        instancePersonel.Ad, 
                        instancePersonel.Soyad, 
                        instancePersonel.Telefonlar[0].TelefonNo, 
                        instancePersonel.Telefonlar[1].TelefonNo, 
                        instancePersonel.Email, 
                        instancePersonel.Meslek,
                        instancePersonel.Adres,
                        DateTime.Parse(instancePersonel.DogumT),
                        instancePersonel.Maas,
                        instancePersonel.MedeniDurum == Program.medeniDurum.Evli,
                        instancePersonel.Cinsiyet == Program.Cinsiyet.Kadin);
                    kayit.Show();
                    return ;
                }
            }
            MessageBox.Show("Yaptığınız isimle kayıtlı personel bulunamadı.");
        }
    }
}
