using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSSOkumaUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
           List<Haber> Kayitlar = XMLCevir();
            lstBaslik.DataSource = Kayitlar;
        }

        private List<Haber> XMLCevir ()
        {
            List<Haber> HaberKayitlari = new List<Haber>();

            XDocument XMLKaynak = XDocument.Load(txtRssUrl.Text);

            List<XElement> Rows = XMLKaynak.Descendants("item").ToList();

            foreach (XElement item in Rows) 
            { 

                Haber Temp = new Haber();
                Temp.Baslik = item.Element("title").Value;
                Temp.Link = item.Element("link").Value;
                Temp.Aciklama = item.Element("description").Value;

                HaberKayitlari.Add(Temp);
            }
            return HaberKayitlari;
        }

        private void lstBaslik_SelectedIndexChanged(object sender, EventArgs e)
        {

           ListBox SecilenDeger = (ListBox)sender;

            Haber SecilenHaber = SecilenDeger.SelectedItem as Haber;

            webBrowser.DocumentText = SecilenHaber.Aciklama;



        }
    }
}
