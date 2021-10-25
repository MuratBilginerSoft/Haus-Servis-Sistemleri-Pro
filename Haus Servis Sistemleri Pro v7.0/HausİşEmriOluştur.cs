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
    public partial class HausİşEmriOluştur : Form
    {
        #region Tanımlamalar

        İşKatmanı BL = new İşKatmanı();

        #endregion

        public HausİşEmriOluştur()
        {
            InitializeComponent();
        }

        private void PicGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
           
        }

        private void HausİşEmriOluştur_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int Kimlik;
        private void PicUzmanAra1_Click(object sender, EventArgs e)
        {
            HausPlanlamaVeri HPVForm = new HausPlanlamaVeri();
            BL.HausPlanlamaVeri(HPVForm.DataPlan);
            this.Enabled = false;
            HPVForm.ShowDialog();
            this.Enabled = true;

           

            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                Kimlik = Convert.ToInt32(Nesne.GetData(DataFormats.Text));
            }

            BL.HausPlanlamaTekVeri(Kimlik);

            TextMüşteri.Text = İşKatmanı.Tablo10.Rows[0]["MüşteriNo"].ToString();
            TextŞehir.Text = İşKatmanı.Tablo10.Rows[0]["Şehir"].ToString();
            TextFirmaAdı.Text = İşKatmanı.Tablo10.Rows[0]["FirmaAdı"].ToString();
            TextÜlke.Text = İşKatmanı.Tablo10.Rows[0]["Ülke"].ToString();
            TextTelefon.Text = İşKatmanı.Tablo10.Rows[0]["Telefon"].ToString();
            //TextAdres.Text = İşKatmanı.Tablo10.Rows[0]["Adres"].ToString();
            TextYapılacakİş.Text = İşKatmanı.Tablo10.Rows[0]["Yapılacakİş"].ToString();
            TextİşSüresi.Text = İşKatmanı.Tablo10.Rows[0]["İşSüresi"].ToString();
            TextUzman1.Text = İşKatmanı.Tablo10.Rows[0]["SicilNo1"].ToString();
            TextUzman2.Text = İşKatmanı.Tablo10.Rows[0]["SicilNo2"].ToString();
            TextUzman3.Text = İşKatmanı.Tablo10.Rows[0]["SicilNo3"].ToString();
            TextUzman4.Text = İşKatmanı.Tablo10.Rows[0]["SicilNo4"].ToString();
            TextAdSoyad1.Text =İşKatmanı.Tablo10.Rows[0]["Operatör1"].ToString();
            TextAdSoyad2.Text = İşKatmanı.Tablo10.Rows[0]["Operatör2"].ToString();
            TextAdSoyad3.Text = İşKatmanı.Tablo10.Rows[0]["Operatör3"].ToString();
            TextAdSoyad4.Text = İşKatmanı.Tablo10.Rows[0]["Operatör4"].ToString();
            TextUzmanlık1.Text = İşKatmanı.Tablo10.Rows[0]["Uzmanlık1"].ToString();
            TextUzmanlık2.Text = İşKatmanı.Tablo10.Rows[0]["Uzmanlık2"].ToString();
            TextUzmanlık3.Text = İşKatmanı.Tablo10.Rows[0]["Uzmanlık3"].ToString();
            TextUzmanlık4.Text = İşKatmanı.Tablo10.Rows[0]["Uzmanlık4"].ToString();


        }

        string ServisNo;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ServisNo = TextServisNo.Text;
            BL.HausİşEmriVeriEkle(ServisNo, TextMüşteri.Text, TextFirmaAdı.Text, TextYapılacakİş.Text, TextİşSüresi.Text, dateTimePicker1, TextUzman1.Text, TextAdSoyad1.Text, TextUzman2.Text, TextAdSoyad2.Text, TextUzman3.Text, TextAdSoyad3.Text, TextUzman4.Text, TextAdSoyad4.Text);
            MessageBox.Show("KayıtBaşarılı");

        }
    }
}
