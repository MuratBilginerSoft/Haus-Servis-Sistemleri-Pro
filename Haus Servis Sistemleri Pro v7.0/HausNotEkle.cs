using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;

namespace Haus_Servis_Sistemleri_Pro_v7._0
{
    public partial class HausNotEkle : Form
    {
        İşKatmanı BusinesLayer = new İşKatmanı();

        public HausNotEkle()
        {
            InitializeComponent();
        }

       

        private void PicGeri_Click(object sender, EventArgs e)
        {
            TimerSaat.Stop();
            this.Close();
        }

       

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = BusinesLayer.Zaman().ToLongTimeString();
        }

        private void HausNotEkle_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            CheckServisNo.Checked = true;
        }

        private void RadioYok_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void CheckServisNo_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckServisNo.Checked==true)
            {
                TextServisNo.Enabled = true;
                PicYapıştır.Enabled = true;
                PicTemizle.Enabled = true;
                TextServisNo.Text = "";
            }

            else
            {
                TextServisNo.Enabled = false;
                PicYapıştır.Enabled = false;
                PicTemizle.Enabled = false;
                TextServisNo.Text = "M0";
            }
        }

        private void PicKaydet_Click(object sender, EventArgs e)
        {
            if (RichNot.Text=="" || RichNot.Text=="Not Yaz" || TextServisNo.Text=="")
            {
                PanelDurum.BackColor = Color.Red;
                LblDurum.Text = "Kayıt Gerçekleşmedi";
                MessageBox.Show("Kaydedilecek herhangi bir Bilgi girmediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                BusinesLayer.HausNotlarVeriEkle(TextServisNo.Text, RichNot.Text, dateTimePicker1);
                MessageBox.Show("Başarılı");
            }
        }

        private void PicYapıştır_Click(object sender, EventArgs e)
        {
            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                TextServisNo.Text = Nesne.GetData(DataFormats.Text).ToString();
            }
        }

        private void PicTemizle_Click(object sender, EventArgs e)
        {
            TextServisNo.Clear();
        }

       
      

        
    }
}
