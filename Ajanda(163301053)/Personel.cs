using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ajanda_163301053_
{


    class Personel
    {
        private string ad;
        private string soyad;
        private string dogumT;//doğum tarihi formatı = dd.MM.yyyy
        private string meslek;
        private string email;
        private string adres;
        private List<Ajanda> telefonlar; 
        private Program.Cinsiyet cinsiyet;
        private Program.medeniDurum medeniDurum;
        private int maas;
        Regex rgx = new Regex(@"\t|\n|\r|\|");

        //textbox tan alınan verilerde altSatır karakteri ve '|' karakteri istenmeyen karkterler olduğudan Replace metodu ile set bloğunda kontrollü kaydediyoruz.
        public int Maas { get => maas; set => maas=value; }
        public string Ad { get => ad; set => ad = rgx.Replace(value,""); }
        public string Soyad { get => soyad; set => soyad = rgx.Replace(value, ""); }
        public string DogumT { get => dogumT; set => dogumT = rgx.Replace(value, ""); }
        public string Meslek { get => meslek; set => meslek = rgx.Replace(value, ""); }
        internal Program.Cinsiyet Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        internal Program.medeniDurum MedeniDurum { get => medeniDurum; set => medeniDurum = value; }
        public int Yas
        {
            get {
                DateTime dogumTarihi = DateTime.Parse(dogumT);
                int yas = DateTime.Today.Year - dogumTarihi.Year;
                if (dogumTarihi > DateTime.Today.AddYears(-yas))
                    yas--;
                return yas;
            }
        }
        public string Email { get => email; set => email = rgx.Replace(value, ""); }
        public string Adres { get => adres; set => adres = rgx.Replace(value, ""); }
        public List<Ajanda> Telefonlar { get => telefonlar; set => telefonlar = value; }


        //private modda açıldı. Property ler ile gerekirse erişilebilir hale gelecek.

        public Personel(string ad, string soyad)
        {
            this.ad = ad;
            this.soyad = soyad;
        }
        void ZamYap(int zam)
        {
            maas += zam;
        }

        int KalanGunSayisi()
        {
             DateTime emekliOlacagiTarih = DateTime.Parse(dogumT).AddYears(57);
            DateTime buGun = DateTime.Today;
            if (buGun >= emekliOlacagiTarih)
                return 0;
            int yilSayisi = emekliOlacagiTarih.Year-buGun.Year;
            int gunFarki = emekliOlacagiTarih.DayOfYear - buGun.DayOfYear;
            return yilSayisi * 365 + gunFarki;
        }
    }
}
