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
    public partial class HausPlanlama : Form
    {

        İşKatmanı BusinesLayer = new İşKatmanı();
        HausOperatör HOForm = new HausOperatör();

        TimeSpan ZamanFarkı;
        DateTime Gün;

        int[] Operatör = new int[4];

        public static string[] Uzmanlıklar = new string[6];

        string Yapılacakİş;
        string Şehir;
        int Süre;
        int PersonelSayısı;

        int süre1 = 0;

        Random r = new Random();

        public void OperatörFormAç(TextBox TextBox1, TextBox TextBox2, TextBox TextBox3, TextBox TextBox4)
        {
            this.Enabled = false;
            HOForm.ShowDialog();
            this.Enabled = true;

            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                TextBox1.Text = Nesne.GetData(DataFormats.Text).ToString();
                TextBox2.Text = İşKatmanı.Tablo8.Rows[HausOperatör.Id-1]["İsim"].ToString();
                TextBox3.Text = İşKatmanı.Tablo8.Rows[HausOperatör.Id - 1]["Uzmanlık"].ToString();
                TextBox4.Text = İşKatmanı.Tablo8.Rows[HausOperatör.Id - 1]["Şehir"].ToString();
            }
        
        }

        public HausPlanlama()
        {
            InitializeComponent();
        }

        private void HausPlanlama_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void PicKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicSimge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PicBilgi_Click(object sender, EventArgs e)
        {
            HausHakkında HHForm = new HausHakkında();
            BusinesLayer.FormAç(this, HHForm);
        }

        private void PicMüşteriAra_Click(object sender, EventArgs e)
        {
            HausMüşteri HMForm = new HausMüşteri();
            this.Enabled = false;
            HMForm.ShowDialog();
            this.Enabled = true;


            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                TextMüşteriNo.Text = Nesne.GetData(DataFormats.Text).ToString();
            }
        }

        private void PicYapıştır_Click(object sender, EventArgs e)
        {
            IDataObject Nesne = Clipboard.GetDataObject();

            if (Nesne.GetDataPresent(DataFormats.Text))
            {
                TextMüşteriNo.Text = Nesne.GetData(DataFormats.Text).ToString();
            }
        }

        private void PicTemizle_Click(object sender, EventArgs e)
        {
            TextMüşteriNo.Clear();
        }

        private void PicOnayla1_Click(object sender, EventArgs e)
        {
            BusinesLayer.HausMüsteriVeri(TextMüşteriNo.Text);

            if (İşKatmanı.Tablo6.Rows.Count != 0)
            {
                TextFirmaAdı.Text = İşKatmanı.Tablo6.Rows[0]["FirmaAdı"].ToString();
                TextŞehir.Text = İşKatmanı.Tablo6.Rows[0]["FirmaŞehir"].ToString();
                TextTelefon.Text = İşKatmanı.Tablo6.Rows[0]["FirmaTelefon"].ToString();
                TextÜlke.Text = İşKatmanı.Tablo6.Rows[0]["Ülke"].ToString();
                TextAdres.Text = İşKatmanı.Tablo6.Rows[0]["FirmaAdres"].ToString();
            }

            else
            {
                MessageBox.Show("Eşleşen bir müşteri kaydınız bulunmamaktadır");
            }

            GroupBoxİşPlanla.Enabled = true;
        }

        private void RadioOtomatik_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioOtomatik.Checked==true)
            {
                PanelUzmanSeç.Enabled = true;
            }

            else
            {
                PanelUzmanSeç.Enabled = false;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {


            if (NumericPersonel.Value!=0 && NumericSüre.Value!=0 && TextYapılacakİş.Text!="")
            {
                #region Temizle

                foreach (Control item in GroubBoxOperatör.Controls)
                {
                    Type Tip = item.GetType();
                    if (Tip.Name=="TextBox")
                    {
                        item.Text = "";
                    }
                }

                

                #endregion

                PersonelSayısı = Convert.ToInt16(NumericPersonel.Value);
                Süre = Convert.ToInt16(NumericSüre.Value);
                Yapılacakİş = TextYapılacakİş.Text;
                Gün = DateTimeGün.Value;

                #region Manuel Elemanları Açma

                if (RadioManuel.Checked==true)
                {
                    GroubBoxOperatör.Enabled = true;

                    if (PersonelSayısı==1)
                    {
                        TextUzman1.Enabled = true;
                        PicUzmanAra1.Enabled = true;
                        

                        TextUzman2.Enabled = false;
                        PicUzmanAra2.Enabled = false;
                        

                        TextUzman3.Enabled = false;
                        PicUzmanAra3.Enabled = false;
                        

                        TextUzman4.Enabled = false;
                        PicUzmanAra4.Enabled = false;
                        
                    }

                    else if (PersonelSayısı==2)
                    {
                        TextUzman1.Enabled = true;
                        PicUzmanAra1.Enabled = true;
                        

                        TextUzman2.Enabled = true;
                        PicUzmanAra2.Enabled = true;
                        

                        TextUzman3.Enabled = false;
                        PicUzmanAra3.Enabled = false;
                        

                        TextUzman4.Enabled = false;
                        PicUzmanAra4.Enabled = false;
                        
                    }

                    else if (PersonelSayısı == 3)
                    {
                        TextUzman1.Enabled = true;
                        PicUzmanAra1.Enabled = true;
                        

                        TextUzman2.Enabled = true;
                        PicUzmanAra2.Enabled = true;
                        

                        TextUzman3.Enabled = true;
                        PicUzmanAra3.Enabled = true;
                       

                        TextUzman4.Enabled = false;
                        PicUzmanAra4.Enabled = false;
                        
                    }

                    else if (PersonelSayısı == 4)
                    {
                        TextUzman1.Enabled = true;
                        PicUzmanAra1.Enabled = true;
                        

                        TextUzman2.Enabled = true;
                        PicUzmanAra2.Enabled = true;
                       

                        TextUzman3.Enabled = true;
                        PicUzmanAra3.Enabled = true;
                        

                        TextUzman4.Enabled = true;
                        PicUzmanAra4.Enabled = true;
                        
                    }

                }

                #endregion

                #region Otomatik Atama

                else
                {
                    PanelUzmanSeç.Enabled = true;

                    if (checkBox1.Checked == true) Uzmanlıklar[0] = checkBox1.Text;
                    if (checkBox2.Checked == true) Uzmanlıklar[1] = checkBox2.Text;
                    if (checkBox3.Checked == true) Uzmanlıklar[2] = checkBox3.Text;
                    if (checkBox4.Checked == true) Uzmanlıklar[3] = checkBox4.Text;
                    if (checkBox5.Checked == true) Uzmanlıklar[4] = checkBox5.Text;
                    if (checkBox6.Checked == true) Uzmanlıklar[5] = checkBox6.Text;


                    Şehir = TextŞehir.Text;

                    BusinesLayer.HausOperatörBelirle(Uzmanlıklar);

                    int x1;

                    for (int i = 0; i < PersonelSayısı; i++)
                    {
                        do
                        {
                            x1 = r.Next(0, İşKatmanı.Tablo7.Rows.Count);
                        } while (Array.IndexOf(Operatör, x1) != -1);

                        Operatör[i] = x1;
                    }

                    if (PersonelSayısı==1)
                    {
                        TextUzman1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["SicilNo"].ToString();
                        TextAdSoyad1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["İsim"].ToString();
                        TextUzmanlık1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["Uzmanlık"].ToString();
                        TextŞehir1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["Şehir"].ToString();
                    }

                    else if (PersonelSayısı==2)
                    {
                        TextUzman1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["SicilNo"].ToString();
                        TextUzman2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["SicilNo"].ToString();
                        TextAdSoyad1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["İsim"].ToString();
                        TextAdSoyad2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["İsim"].ToString();
                        TextUzmanlık1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["Uzmanlık"].ToString();
                        TextUzmanlık2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["Uzmanlık"].ToString();
                        TextŞehir1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["Şehir"].ToString();
                        TextŞehir2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["Şehir"].ToString();
                    }

                    else if (PersonelSayısı==3)
                    {
                        TextUzman1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["SicilNo"].ToString();
                        TextUzman2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["SicilNo"].ToString();
                        TextUzman3.Text = İşKatmanı.Tablo7.Rows[Operatör[2]]["SicilNo"].ToString();
                        TextAdSoyad1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["İsim"].ToString();
                        TextAdSoyad2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["İsim"].ToString();
                        TextAdSoyad3.Text = İşKatmanı.Tablo7.Rows[Operatör[2]]["İsim"].ToString();
                        TextUzmanlık1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["Uzmanlık"].ToString();
                        TextUzmanlık2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["Uzmanlık"].ToString();
                        TextUzmanlık3.Text = İşKatmanı.Tablo7.Rows[Operatör[2]]["Uzmanlık"].ToString();
                        TextŞehir1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["Şehir"].ToString();
                        TextŞehir2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["Şehir"].ToString();
                        TextŞehir3.Text = İşKatmanı.Tablo7.Rows[Operatör[2]]["Şehir"].ToString();
                    }

                    else
                    {
                        TextUzman1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["SicilNo"].ToString();
                        TextUzman2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["SicilNo"].ToString();
                        TextUzman3.Text = İşKatmanı.Tablo7.Rows[Operatör[2]]["SicilNo"].ToString();
                        TextUzman4.Text = İşKatmanı.Tablo7.Rows[Operatör[3]]["SicilNo"].ToString();

                        TextAdSoyad1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["İsim"].ToString();
                        TextAdSoyad2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["İsim"].ToString();
                        TextAdSoyad3.Text = İşKatmanı.Tablo7.Rows[Operatör[2]]["İsim"].ToString();
                        TextAdSoyad4.Text = İşKatmanı.Tablo7.Rows[Operatör[3]]["İsim"].ToString();

                        TextUzmanlık1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["Uzmanlık"].ToString();
                        TextUzmanlık2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["Uzmanlık"].ToString();
                        TextUzmanlık3.Text = İşKatmanı.Tablo7.Rows[Operatör[2]]["Uzmanlık"].ToString();
                        TextUzmanlık4.Text = İşKatmanı.Tablo7.Rows[Operatör[3]]["Uzmanlık"].ToString();

                        TextŞehir1.Text = İşKatmanı.Tablo7.Rows[Operatör[0]]["Şehir"].ToString();
                        TextŞehir2.Text = İşKatmanı.Tablo7.Rows[Operatör[1]]["Şehir"].ToString();
                        TextŞehir3.Text = İşKatmanı.Tablo7.Rows[Operatör[2]]["Şehir"].ToString();
                        TextŞehir4.Text = İşKatmanı.Tablo7.Rows[Operatör[3]]["Şehir"].ToString();
                    }

                    GroubBoxOperatör.Enabled = true;
                }

                #endregion
            }

            else
            {
                MessageBox.Show("Eksik Veri Girdiniz");
            }
        }

        private void PicUzmanAra1_Click(object sender, EventArgs e)
        {
            OperatörFormAç(TextUzman1, TextAdSoyad1, TextUzmanlık1, TextŞehir1);
        }

        private void PicUzmanAra2_Click(object sender, EventArgs e)
        {
            OperatörFormAç(TextUzman2, TextAdSoyad2, TextUzmanlık2, TextŞehir2);
        }

        private void PicUzmanAra3_Click(object sender, EventArgs e)
        {
            OperatörFormAç(TextUzman3, TextAdSoyad3, TextUzmanlık3, TextŞehir3);
        }

        private void PicUzmanAra4_Click(object sender, EventArgs e)
        {
            OperatörFormAç(TextUzman4, TextAdSoyad4, TextUzmanlık4, TextŞehir4);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BusinesLayer.HausİşPlanla(TextMüşteriNo.Text, TextFirmaAdı.Text, TextŞehir.Text, TextTelefon.Text, TextYapılacakİş.Text, Convert.ToInt16(NumericSüre.Value), DateTimeGün, TextUzman1.Text, TextAdSoyad1.Text, TextUzmanlık1.Text, TextUzman2.Text, TextAdSoyad2.Text, TextUzmanlık2.Text, TextUzman3.Text, TextAdSoyad3.Text, TextUzmanlık3.Text, TextUzman4.Text, TextAdSoyad4.Text, TextUzmanlık4.Text);

            MessageBox.Show("Başarılı Bir Şekilde Planlandı");
        }
    }
}
