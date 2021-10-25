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
    public partial class HausLoginPanel : Form
    {
        #region Değişkenler
         
        string TabloAdı;  // Veri tabanındaki tablo adını aldığımız değişken. Giriş için gerekli.

        Form FormAdı; // Yöneticimi yoksa Personel mi seçimine göre form kontrolü.

        int i1 = 0; // Kullanıcı Girişinde Bir Sayaç

        #endregion

        #region Tanımlamalar

        İşKatmanı BusinesLayer = new İşKatmanı(); // Business Layer a ait İşKatmanı sınıfından bir nesne türetildi.
      
        #endregion

        #region Ana  Form İşlemleri

        public HausLoginPanel()
        {
            InitializeComponent();
        }

        private void HausLoginPanel_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();

            BusinesLayer.Bilgilendirme(ToolBilgilendirme1, TxtKAdı, TxtŞifre, BtnGiriş, PicBilgi, PicSimge,PicGöz, PicKapat, "Kullanıcı Adınızı Giriniz", "Şifrenizi Giriniz", "Giriş Yap","Bilgilendirme Formu Aç", "Simge Durumu", "Şifre Gösteriliyor", "Kapat");
        }

        private void BtnGiriş_Click(object sender, EventArgs e)
        {
            if (TxtKAdı.Text == "") BusinesLayer.ErrorBildirisi(errorProvider1, TxtKAdı, "Kullanıcı Adı Bölümü Boş Bırakılamaz"); // Giriş eksik ise bilgilendirme.

            if (TxtŞifre.Text == "") BusinesLayer.ErrorBildirisi(errorProvider1, PicGöz, "Şifre Bölümü Boş Bırakılamaz"); // Giriş eksik ise bilgilendirme.

            if (TxtKAdı.Text != "" && TxtŞifre.Text != "")
            {
                #region Giriş Verileri

                HausYöneticiPaneli HYPForm = new HausYöneticiPaneli(); // HausYöneticiPaneli Formunun bir nesnesi oluşturuldu.

                HausPersonelPaneli HPPForm = new HausPersonelPaneli(); // HausPersonelPaneli Formunun bir nesnesi oluşturuldu.

                if (RadioYönetici.Checked == true) { TabloAdı = "HausAdmin"; FormAdı = HYPForm; } // Seçime göre hangi tablodan veri çekileceğine karar verdik

                else if (RadioPersonel.Checked == true) { TabloAdı = "HausPersonel"; FormAdı = HPPForm; }

                BusinesLayer.GirişVeriAl(TabloAdı); // GiriVerial Metodu ile giriş verilerini aldık.

                #endregion

                #region Giriş Değeri Kontrolü

                for (i1 = 0; i1 < İşKatmanı.Tablo1.Rows.Count; i1++)
                {
                    if (TxtKAdı.Text.Trim() == İşKatmanı.Tablo1.Rows[i1]["KullanıcıAdı"].ToString() && TxtŞifre.Text.Trim() == İşKatmanı.Tablo1.Rows[i1]["Şifre"].ToString())
                    {
                        BusinesLayer.AdminVerisiniTut(i1); // Kullanıcı girişi doğru ise admin verilerini AdminVerisiTut metodu ile tuttuk.
                        BusinesLayer.FormAç(this, FormAdı); // Form açtık.
                        break; // Durdurduk döngüyü.
                    }
                }

                if (i1 == İşKatmanı.Tablo1.Rows.Count)
                {
                    BusinesLayer.ErrorBildirisi(errorProvider1, BtnGiriş, "Kullanıcı Adı veya Şifre Yanlış Tekrar Deneyiniz"); // Yanlış girilmiş Kullanıcı Adı ve şifre için uyarı.
                    MessageBox.Show("Kullanıcı Adınız veya Şifre Yanlıştır.\nKontrol Edip Tekrar Giriş Yapmayı Deneyiniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                #endregion
            }
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = BusinesLayer.Zaman().ToLongTimeString(); // Anlık saat Zaman metodu ile yazdırılıyor.
        }
       
        #endregion

        #region PictureBox İşlemleri

        private void PicBilgi_Click(object sender, EventArgs e)
        {
            HausHakkında HHForm = new HausHakkında();
            BusinesLayer.FormAç(this, HHForm);
        }

        private void PicSimge_Click(object sender, EventArgs e)
        {
            BusinesLayer.SimgeDurumu(this);
        }

        private void PicKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicBilgi_MouseHover(object sender, EventArgs e)
        {
            // Kapat Minimize Bilgi

            BusinesLayer.PicRenk1((sender as PictureBox));
        }

        private void PicBilgi_MouseLeave(object sender, EventArgs e)
        {
            // Kapat Minimize Bilgi

            BusinesLayer.PicRenk2((sender as PictureBox));
        }

        private void PicGöz_MouseHover(object sender, EventArgs e)
        {
            BusinesLayer.PicRenk1(PicGöz);
            BusinesLayer.PasswordAçık(TxtŞifre);
        }

        private void PicGöz_MouseLeave(object sender, EventArgs e)
        {
            BusinesLayer.PicRenk2(PicGöz);
            BusinesLayer.PasswordGizle(TxtŞifre);
        }

        #endregion
      
        #region Menü Strip Olayları

        private void MenüYöneticii_Click(object sender, EventArgs e)
        {
            RadioYönetici.Checked = true;
        }

        private void MenüPersonell_Click(object sender, EventArgs e)
        {
            RadioPersonel.Checked = true;
        }

        private void MenüYardım_Click(object sender, EventArgs e)
        {
            HausYardım HYForm = new HausYardım();
            BusinesLayer.FormAç(this, HYForm);
        }

        private void MenüHakkındaa_Click(object sender, EventArgs e)
        {
            HausHakkında HHForm = new HausHakkında();
            BusinesLayer.FormAç(this, HHForm);
        }

        private void MenüÇıkışş_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Form Olayları

        private void HausLoginPanel_MouseDown(object sender, MouseEventArgs e)
        {
            BusinesLayer.MouseDown(this, e);
        }

        private void HausLoginPanel_MouseMove(object sender, MouseEventArgs e)
        {
            BusinesLayer.MouseMove(this, e);
        }

        private void HausLoginPanel_MouseUp(object sender, MouseEventArgs e)
        {
            BusinesLayer.MouseUp(this);
        }

        #endregion
    }
}
