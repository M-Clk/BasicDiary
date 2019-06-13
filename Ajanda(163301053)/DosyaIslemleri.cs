using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajanda_163301053_
{
    class DosyaIslemleri
    {
        
        public DosyaIslemleri()
        {
            
        }
        public List<Personel> DosyadanOku()
        {
            FileStream fileStream = new FileStream(Program.path+"\\data.txt", FileMode.OpenOrCreate);
            List<Personel> personels = new List<Personel>();
            StreamReader streamReader = new StreamReader(fileStream);
            string simdikiSatir;
            while ((simdikiSatir = streamReader.ReadLine()) != null) {
                char[] ayrac = { '|' };
                string[] kolonlar = simdikiSatir.Split(ayrac);
                //kolon index sırası=>  ad | soyad | dogum_tarihi | meslek | cinsiyet | medeni_durum | maas | email | adres | telefonlar
                Personel instancePersonel = new Personel(kolonlar[0], kolonlar[1]);
                instancePersonel.DogumT = kolonlar[2];
                instancePersonel.Meslek = kolonlar[3];
                instancePersonel.Cinsiyet = (Program.Cinsiyet)Convert.ToInt32(kolonlar[4]);
                instancePersonel.MedeniDurum = (Program.medeniDurum)Convert.ToInt32(kolonlar[5]);
                instancePersonel.Maas = Convert.ToInt32(kolonlar[6]);
                instancePersonel.Email = kolonlar[7];
                instancePersonel.Adres = kolonlar[8];
                instancePersonel.Telefonlar = AjandaListele(kolonlar[9]);
                personels.Add(instancePersonel);
            }
            streamReader.Close();
            fileStream.Close();
            return personels;
        }
        
        List<Ajanda> AjandaListele(string tumTelefonlar)
        {
            List<Ajanda> telefonListesi= new List<Ajanda>();
            //veri formatı:telAdi,telNo+telAdi2,telNo2+...
                char[] ayrac = { ',','+' };
                string[] kolonlar = tumTelefonlar.Split(ayrac);
            for(int i=0;i<=kolonlar.Length-2;i=i+2)
            {
                Ajanda instanceAjanda = new Ajanda(kolonlar[i],kolonlar[i+1]);
                telefonListesi.Add(instanceAjanda);
            }
            return telefonListesi;
        }
        public void DosyayaYaz(Personel newPersonel)
        {
            FileStream fileStream = new FileStream(Program.path + "\\data.txt", FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            string tumTelefonlar;
            List<string> adVeNo = new List<string>();
            foreach(var seciliAjanda in newPersonel.Telefonlar)
            {
                adVeNo.Add(seciliAjanda.TelefonAdi + "," + seciliAjanda.TelefonNo);
            }
            tumTelefonlar = String.Join("+", adVeNo);

            string[] veriler = { newPersonel.Ad, newPersonel.Soyad, newPersonel.DogumT, newPersonel.Meslek, ((int)newPersonel.Cinsiyet).ToString(), ((int)newPersonel.MedeniDurum).ToString(), newPersonel.Maas.ToString(), newPersonel.Email, newPersonel.Adres, tumTelefonlar };
            for (int i = 0; i < veriler.Length; i++)//verilerin doğru okunması için ayırıcı karakter içeren verilerden o karakteri silme işlemi
            {
                veriler[i]=veriler[i].Replace("|", "");
            }
            streamWriter.WriteLine(String.Join("|", veriler));
            Program.personelListesi.Add(newPersonel);
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
