using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ajanda_163301053_
{
    static class Program
    {
        public enum medeniDurum {  Bekar = 0, Evli = 1 }
        public enum Cinsiyet {Erkek = 0, Kadin = 1}
        public static List<Personel> personelListesi;

        public static string path = "C:\\Users\\celik\\Desktop";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIParent1());
        }
        
    }
}
