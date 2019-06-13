using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajanda_163301053_
{
    class Ajanda
    {
        private string telefonAdi;
        private string telefonNo;

        public string TelefonAdi { get => telefonAdi; set => telefonAdi = value; }
        public string TelefonNo { get => telefonNo; set => telefonNo = value; }
        public Ajanda(string telefonAdi, string telefonNo)
        {
            this.telefonAdi = telefonAdi;
            this.telefonNo = telefonNo;
        }
    }
}
