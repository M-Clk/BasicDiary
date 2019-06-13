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
    public partial class MDIParent1 : Form
    {
        public MDIParent1()
        {
            InitializeComponent();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            if (!GirisKontrol()) Application.Exit();
            DosyaIslemleri ds = new DosyaIslemleri();
            Program.personelListesi = ds.DosyadanOku();
        }

        private bool GirisKontrol()
        {
            frmLogin giris = new frmLogin();
            DialogResult openResult = giris.ShowDialog();
            if (openResult != DialogResult.OK)
                return false;

            return true;
        }

        private void personelKayıtEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKayit kayit = new FormKayit();
            kayit.MdiParent = this;
            kayit.Show();
        }

        private void personelAramaEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArama arama = new FormArama();
            arama.MdiParent = this;
            arama.Show();
        }
    }
}
