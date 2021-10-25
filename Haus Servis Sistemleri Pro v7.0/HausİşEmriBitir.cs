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
    public partial class HausİşEmriBitir : Form
    {

        İşKatmanı BL = new İşKatmanı();

        public HausİşEmriBitir()
        {
            InitializeComponent();
        }

        string ServisNo;

        private void PicUzmanAra1_Click(object sender, EventArgs e)
        {
            
            İşEmriBilgileri HİEBForm = new İşEmriBilgileri();
            this.Enabled = false;
            HİEBForm.ShowDialog();

            this.Enabled = true;

            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                ServisNo = (Nesne.GetData(DataFormats.Text)).ToString();
            }

            TextServisNo.Text = ServisNo;

            BL.HausİşEmriTekVeri(ServisNo);

            TextMüşteri.Text = İşKatmanı.Tablo12.Rows[0]["MüşteriNo"].ToString();
            TextFirmaAdı.Text = İşKatmanı.Tablo12.Rows[0]["FirmaAdı"].ToString();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BL.HausİşEmriBittiVeriEkle(ServisNo, TextMüşteri.Text, TextFirmaAdı.Text, İşKatmanı.Tablo12.Rows[0]["ServisBaşlamaTarihi"].ToString(), dateTimePicker1);
            MessageBox.Show("İş Emri Bitirildi");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
