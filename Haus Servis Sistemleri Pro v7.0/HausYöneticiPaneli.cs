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
    public partial class HausYöneticiPaneli : Form
    {
        #region Değişkenler

        int GeriSayım = 15; // Not butonlarının renklerinin geri dönmesini sağlamak için Sayaç.

        int Yıl, Ay; // DateTimePicker daki yıl ve Ay değerini alan değişkenler.

        int Kontrol1 = 0; // Takvim butonlarının tekrar tekrar oluşmasını önleyecek kontrol noktası

        int PanelGövdeSabitx, PanelGövdeSabity, PanelGövdeLx, PanelGövdeLy, FormGenişlik; // Menü kapatıldığında ve açıldığında form nesnelerini düzenleme için gereken değişkenler.

        int değer; // Butona tıklandığında yakalanan değer.

        int Kontrol2 = 0;

        #endregion

        #region Tanımlamalar

        İşKatmanı BusinesLayer = new İşKatmanı();
        HausNotGözAt HNGForm = new HausNotGözAt();
        HausNotEkle HNEForm = new HausNotEkle();
        Controller Kontroller = new Controller();

        #endregion

        #region Metodlar 

        #region Buton Üret

        Button[] NBDizi = new Button[31];
        int gün;

        public void ButonOluştur(FlowLayoutPanel FlowTakvim, string x)
        {
            for (int i3 = 0; i3 < 31; i3++)
            {
                Button Btn = new Button();
                Btn.Name = x + "Button" + i3;
                Btn.Text = (i3 + 1).ToString();
                Btn.BackgroundImageLayout = ImageLayout.Stretch;
                Btn.FlatStyle = FlatStyle.Popup;
                Btn.BackColor = Color.Transparent;
                Btn.ForeColor = Color.MidnightBlue;
                Btn.Anchor = (AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
                Btn.Font = new Font("Georgia", 30, FontStyle.Regular);
                Btn.Size = new System.Drawing.Size(210, 100);
                Btn.Click += new EventHandler(Btn_Click);
                NBDizi[i3] = Btn;
                FlowTakvim.Controls.Add(Btn);
            }
        }

        public void Btn_Click(object sender, EventArgs e)
        {
            if (RadioGözat.Checked == true)
            {
                if ((sender as Button).BackColor != Color.White)
                {
                    değer = Convert.ToInt16((sender as Button).Text);
                    NBDizi[değer - 1].BackColor = Color.Red;
                    PanelDurum.BackColor = Color.Red;
                    LblDurum.Text = "Bu Tarihte Alınmış Bir Not Yoktur";
                    TimerButonKontrol.Start();
                    GeriSayım = 10;
                }

                else
                {
                    değer = Convert.ToInt16((sender as Button).Text);
                    BusinesLayer.HausNotlarGözAt(Convert.ToString(değer), Convert.ToString(Yıl), İşKatmanı.Ayismi);
                    HNGForm.DataGridNot.DataSource = İşKatmanı.Tablo4;
                    this.Enabled = false;
                    HNGForm.ShowDialog();
                    this.Enabled = true;
                }
            }
            

        }

        

        public void ButonRenklendirme()
        {
            for (int i = 0; i <İşKatmanı.Tablo3.Rows.Count; i++)
            {
                gün = Convert.ToDateTime(İşKatmanı.Tablo3.Rows[i]["YapılacakTarih"].ToString().Split(' ')[0].ToString()).Day;
                NBDizi[gün - 1].BackColor = Color.White;
                NBDizi[gün - 1].ForeColor = Color.MidnightBlue;
            }
        }

        #endregion

        #region PictureBox Üret

        PictureBox[] SIPicDizi = new PictureBox[İşKatmanı.Tablo2.Rows.Count];

        int SIPx;

        public void SIPÜret(Panel Panel1)
        {
            SIPx = -45;
            Array.Resize(ref SIPicDizi, İşKatmanı.Tablo2.Rows.Count);

            for (int i2 = 0; i2 < İşKatmanı.Tablo2.Rows.Count; i2++)
            {
                PictureBox SIPic = new PictureBox();
                SIPic.Name = "SIPic" + i2;
                SIPic.Size = new Size(45, 42);
                SIPic.Location = new Point(1040, SIPx + 48);
                SIPic.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
                SIPic.Click += new EventHandler(SIPic_Click);
                SIPic.Image = Image.FromFile("2 Kopyala.png");
                SIPic.SizeMode = PictureBoxSizeMode.StretchImage;
                SIPicDizi[i2] = SIPic;
                Panel1.Controls.Add(SIPicDizi[i2]);
                SIPx += 48;
            }
        }

        public void SIPic_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt16((sender as PictureBox).Name.Substring(5));
            Clipboard.SetDataObject(İşKatmanı.Tablo2.Rows[İşKatmanı.Tablo2.Rows.Count - 1 - s1]["ServisNo"].ToString(), true);
            LblDurum.Text = "Servis No Kopyalandı";
            PanelDurum.BackColor = Color.SlateGray;
        }

        #endregion

        #endregion

        #region AnaForm İşlemleri

        public HausYöneticiPaneli()
        {
            InitializeComponent();
        } // Componentler yüklendi

        private void HausYöneticiPaneli_Load(object sender, EventArgs e)
        {
            SistemKontrol.Start(); // Tüm sistem boyunca hiç durmayan saat.
            ForumSaat.Start(); // Formun saati için çalışan Timer.
            this.WindowState = FormWindowState.Maximized; // Formu Maximize yaptık.
            OvalResim.BackgroundImage = Image.FromFile(İşKatmanı.HausKullanıcıVeri[3]); // Form açılırken giriş yapan kişinin resmi gösterildi.
            Lblİsim.Text = İşKatmanı.HausKullanıcıVeri[1]; // Giriş Yapan kişinin ismi yazdırıldı.
            RadioGözat.Checked = true; // Radio Gözat butonu otomatik olarak seçili geldi.
            TabControlAna.SelectedIndex = -1; // Tabindexi -1 ile başlattık. 

            #region FormDüzenleme Kodları
            PanelGövdeSabity = PanelGövde.Size.Height;
            PanelGövdeSabitx = PanelGövde.Size.Width;
            PanelGövdeLx = PanelGövde.Location.X;
            PanelGövdeLy = PanelGövde.Location.Y;
            FormGenişlik = this.Size.Width;
            #endregion

        } // Form Load

        private void ForumSaat_Tick(object sender, EventArgs e)
        {
            LblAnaSaat1.Text = BusinesLayer.Zaman().ToLongTimeString(); // İlk açılıştaki saatin kodları
            LblSaat.Text = BusinesLayer.Zaman().ToLongTimeString(); // Formda sürekli çalışan Saat kodları.
        } // Formda işleyen tüm saatlerin Tick olayı

        private void TimerButonKontrol_Tick(object sender, EventArgs e)
        {
            if (GeriSayım == 0)
            {
                for (int i = 0; i < 31; i++)
                {
                    if (NBDizi[i].BackColor != Color.White)
                    {
                        NBDizi[i].BackColor = Color.Transparent;
                    }
                }

                PanelDurum.BackColor = Color.DeepSkyBlue;
                LblDurum.Text = "Durum Kontrolü";
            }

            GeriSayım--;
        } // Not olmayan butona tıklandığında çalışacak kodlar.

        private void SistemKontrol_Tick(object sender, EventArgs e)
        {
            if (TabControlAna.Visible == true)
            {
                BtnAkış.BackColor = Color.White;
            }

            else
            {
                BtnAkış.BackColor = Color.Transparent;
            }

            if (Kontrol2 < 10)
            {
                HNEForm.Opacity += 10;
            }


        }

        #endregion

        #region PictureBox İşlemleri

        private void PicKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        } // Kapatma İşlemi

        private void PicSimge_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        } // Simge Durumuna Küçültme İşlemi

        private void PicNotEkle_Click(object sender, EventArgs e)
        {
            if (RadioNotEkle.Visible == false)
            {
                RadioGözat.Visible = true;
                RadioNotEkle.Visible = true;

                if (RadioNotEkle.Checked == true) PicKalem.Visible = true;
            }

            else if (RadioNotEkle.Visible == true)
            {
                RadioGözat.Visible = false;
                RadioNotEkle.Visible = false;
                PicKalem.Visible = false;
            }
        } // Notlar ile ilgili işlemler için Açma Kapama

        #endregion

        #region Formlar Arası Geçiş

        private void PicBilgi_Click(object sender, EventArgs e)
        {
            HausYardım HYForm = new HausYardım();
            BusinesLayer.FormAç(this, HYForm);
        }

        private void BtnPlanlama_Click(object sender, EventArgs e)
        {
            HausPlanlama HPForm = new HausPlanlama();
            BusinesLayer.FormAç(this, HPForm);
        }

        private void BtnTakvim_Click(object sender, EventArgs e)
        {
            HausTakvim HTForm = new HausTakvim();
            BusinesLayer.FormAç(this, HTForm);
        }

        private void BtnİşEmriOluştur_Click(object sender, EventArgs e)
        {
            HausİşEmriOluştur HIEOForm = new HausİşEmriOluştur();
            BusinesLayer.FormAç(this, HIEOForm);
        }

        private void BtnİşEmriBitir_Click(object sender, EventArgs e)
        {
            HausİşEmriBitir HIEBForm = new HausİşEmriBitir();
            BusinesLayer.FormAç(this, HIEBForm);
        }

        private void BtnRaporlama_Click(object sender, EventArgs e)
        {
            HausRaporlama HRForm = new HausRaporlama();
            BusinesLayer.FormAç(this, HRForm);
        }

        private void BtnDüzenle_Click(object sender, EventArgs e)
        {
            HausDüzenleme HDForm = new HausDüzenleme();
            BusinesLayer.FormAç(this, HDForm);
        }

        private void PicGeri_Click(object sender, EventArgs e)
        {
            HausLoginPanel HLPForm = new HausLoginPanel();
            BusinesLayer.FormAç(this, HLPForm);
        }

        #endregion

        #region Buton İşlemleri

        private void BtnAkış_Click(object sender, EventArgs e)
        {
            /* Burada Panel sistem akış ve TabControl değerlerini önce false sonra true yapma nedenimiz
             * butonlar oluşurken ve silinirken bu işlemin gözükmemesi daha şık bir görünüm için. */
            if (TabControlAna.SelectedIndex != 0)
            {
                PanelSistemAkış.Visible = false;
                TabControlAna.Visible = false;
                BusinesLayer.Sonİşlemler(PanelSistemAkış); // Son işlemleri listeledik.
                SIPÜret(PanelSistemAkış); // Kopyala butonları oluşturuldu
                TabControlAna.Visible = true;
                PanelSistemAkış.Visible = true;
            }
        }

        private void MenüAkış_Click(object sender, EventArgs e)
        {
            if (TabControlAna.SelectedIndex!=0)
            {
                PanelSistemAkış.Visible = false;
                TabControlAna.Visible = false;
                TabControlAna.SelectedIndex = 0;
                BusinesLayer.Sonİşlemler(PanelSistemAkış);
                SIPÜret(PanelSistemAkış);
                PanelSistemAkış.Visible = true;
                TabControlAna.Visible = true;
            }
           
        }

        #endregion

        #region MenüStripİşlemleri

        private void MenüAnaSayfaGizle_Click(object sender, EventArgs e)
        {
            TabControlAna.Visible = false;
        }

        private void MenüNotlar_Click(object sender, EventArgs e)
        {
            TabControlAna.Visible = true;
            TabControlAna.SelectedIndex = 1;
        }

        private void MenüAçKapa_Click(object sender, EventArgs e)
        {
            if (MenüAçKapa.Text == "Menü Kapat")
            {
                PanelGövde.Visible = false;
                PanelYanMenü.Visible = false;
                MenüAçKapa.Text = "Menü Aç";
                PanelGövde.Location = new Point(0, (PanelMenüAçKapa.Location.Y + PanelMenüAçKapa.Size.Height));
                PanelGövde.Size = new Size(FormGenişlik,PanelGövdeSabity);
                PanelGövde.Visible = true;

            }

            else if (MenüAçKapa.Text == "Menü Aç")
            {
                PanelGövde.Visible = false;
                PanelYanMenü.Visible = true;
                MenüAçKapa.Text = "Menü Kapat";
                PanelGövde.Location = new Point(PanelGövdeLx,PanelGövdeLy);
                PanelGövde.Size = new Size(PanelGövdeSabitx, PanelGövdeSabity);
                PanelGövde.Visible = true;
            }
        }

        private void MenüAltSistemAkış_Click(object sender, EventArgs e)
        {
            if (TabControlAna.SelectedIndex != 0)
            {
                PanelSistemAkış.Visible = false;
                TabControlAna.Visible = false;
                TabControlAna.SelectedIndex = 0;
                BusinesLayer.Sonİşlemler(PanelSistemAkış);
                SIPÜret(PanelSistemAkış);
                PanelSistemAkış.Visible = true;
                TabControlAna.Visible = true;
            }
        }

        private void MenüAltNotlar_Click(object sender, EventArgs e)
        {
            TabControlAna.Visible = true;
            TabControlAna.SelectedIndex = 1;
        }

        private void MenüAltıNotGiriş_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            HNEForm.Opacity = 0;
            Kontrol2 = 0;
            HNEForm.ShowDialog();
            this.Enabled = true;
        }

        private void MenüPlanlama_Click(object sender, EventArgs e)
        {
            HausPlanlama HPForm = new HausPlanlama();
            BusinesLayer.FormAç(this, HPForm);
        }

        private void MenüTakvim_Click(object sender, EventArgs e)
        {
            HausTakvim HTForm = new HausTakvim();
            BusinesLayer.FormAç(this, HTForm);
        }

        private void MenüİsEmriOluştur_Click(object sender, EventArgs e)
        {
            HausİşEmriOluştur HIEOForm = new HausİşEmriOluştur();
            BusinesLayer.FormAç(this, HIEOForm);
        }

        private void MenüİşEmriBitir_Click(object sender, EventArgs e)
        {
            HausİşEmriBitir HIEBForm = new HausİşEmriBitir();
            BusinesLayer.FormAç(this, HIEBForm);
        }

        private void MenüRaporlar_Click(object sender, EventArgs e)
        {
            HausRaporlama HRForm = new HausRaporlama();
            BusinesLayer.FormAç(this, HRForm);
        }

        private void MenüDüzenle_Click(object sender, EventArgs e)
        {
            HausDüzenleme HDForm = new HausDüzenleme();
            BusinesLayer.FormAç(this, HDForm);
        }


        #endregion

        #region Ekstra İşlemler

        private void TabControlAna_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (TabControlAna.SelectedIndex == 1 && Kontrol1==0)
            {
                Kontrol1++;
                
                Yıl = dateTimePicker1.Value.Year;
                Ay = dateTimePicker1.Value.Month;


                FlowTakvim.Visible = false;
                FlowTakvim.Controls.Clear();
                FlowTakvim.Visible = false;
                BusinesLayer.AyBelirle(Ay);

                BusinesLayer.HausNotlarVeri(İşKatmanı.Ayismi, Convert.ToString(Yıl));
                ButonOluştur(FlowTakvim, İşKatmanı.Ayismi);
                ButonRenklendirme();

                FlowTakvim.Visible = true;
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Yıl = dateTimePicker1.Value.Year;
            Ay = dateTimePicker1.Value.Month;
            FlowTakvim.Visible = false;
            FlowTakvim.Controls.Clear();
            BusinesLayer.AyBelirle(Ay);
            BusinesLayer.HausNotlarVeri(İşKatmanı.Ayismi, Convert.ToString(Yıl));
            ButonOluştur(FlowTakvim, İşKatmanı.Ayismi);
            ButonRenklendirme();
            FlowTakvim.Visible = true;
        }

        #endregion

        #region Radio Buton Olayları

        private void RadioNotEkle_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioNotEkle.Checked == true)
            {
                PicKalem.Visible = true;
            }

            else
            {
                PicKalem.Visible = false;
            }
        }

        #endregion

        private void PicKalem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            HNEForm.Opacity = 0;
            Kontrol2 = 0;
            HNEForm.ShowDialog();
            this.Enabled = true;
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelGövde.Visible = false;
            PanelYanMenü.Visible = true;
            MenüAçKapa.Text = "Menü Kapat";
            
            PanelGövde.Location = new Point(PanelGövdeLx, PanelGövdeLy);
            PanelGövde.Size = new Size(PanelGövdeSabitx, PanelGövdeSabity);
            PanelGövde.Visible = true;
           
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelGövde.Visible = false;
            PanelYanMenü.Visible = false;
            MenüAçKapa.Text = "Menü Aç";
            
            PanelGövde.Location = new Point(0, (PanelMenüAçKapa.Location.Y + PanelMenüAçKapa.Size.Height));
            PanelGövde.Size = new Size(FormGenişlik, PanelGövdeSabity);
            PanelGövde.Visible = true;
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HausYardım HYForm = new HausYardım();
            BusinesLayer.FormAç(this, HYForm);
        }

        private void MenüÇıkış_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
