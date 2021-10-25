using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DataLayer;

namespace BusinessLayer
{
    public class İşKatmanı
    {
        #region Değişkenler

        bool Durum = false;

        int gün;

        int zaman1 = 0;

        public static string[] HausKullanıcıVeri = new string[6]; // Database deki Giriş Yapan Admin verilerini diğer formlara aktarabilmek için tutan dizi.

        string Sorgu1,Sorgu3;

        #endregion

        #region Tanımlamalar

        VeriKatmanı DL = new VeriKatmanı();
        
        OleDbCommand Komut;
        OleDbDataAdapter Kayıt;
        public static DataTable Tablo1 = new DataTable();
        public static DataTable Tablo2 = new DataTable();
        public static DataTable Tablo3 = new DataTable();
        public static DataTable Tablo4 = new DataTable();
        public static DataTable Tablo5 = new DataTable();
        public static DataTable Tablo6 = new DataTable();
        public static DataTable Tablo7 = new DataTable();
        public static DataTable Tablo8 = new DataTable();
        public static DataTable Tablo9 = new DataTable();
        public static DataTable Tablo10 = new DataTable();
        public static DataTable Tablo11 = new DataTable();
        public static DataTable Tablo12 = new DataTable();

        Point İlkKonum;

        #endregion

        #region Metodlar

        #region Password Durumu

        public void PasswordAçık(TextBox Textbox1)
        {
            Textbox1.PasswordChar = '\0'; // 
        }

        public void PasswordGizle(TextBox Textbox2)
        {
            Textbox2.PasswordChar = '*';
        }
        #endregion

        #region Picturebox Arka Plan Renk

        public void PicRenk1(PictureBox Picture1)
        {
            // Mouse nesne üzerine gittiğinde nesnenin arka plan rengi

            Picture1.BackColor = Color.DeepSkyBlue;
        }

        public void PicRenk2(PictureBox Picture2)
        {
            // Mouse nesne üzerinden ayrıldığında nesnenin arkaplan rengi

            Picture2.BackColor = Color.Transparent;
        }

        #endregion

        #region Zamanlama Ayarları

        public void AnimasyonSayaç(ProgressBar progressBar1, Timer timer1, Form form1,Form form2)
        {
            if (zaman1 < 10)
            {
                zaman1++;
                progressBar1.Value += 10;
            }

            else
            {
                timer1.Stop();
                form2.Show();
                form1.Close();
                
            }

        }

        #endregion

        #region ErrorProvider

        public void ErrorBildirisi(ErrorProvider ErrorProvider1, Control Control1, string Veri1)
        {
            ErrorProvider1.SetError(Control1, Veri1);
        }

        #endregion

        #region Veri Tabanı İşlemleri

        public void GirişVeriAl(string TabloAdı)
        {
            Sorgu1 = "Select * from " + TabloAdı + "";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo1);
        }

        public void SonİşlemlerVeriAl()
        {
            Sorgu1 = "Select * from HausSonİşlemler";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1,Komut,Kayıt,Tablo2);
        
        }

        public void HausNotlarVeri(string Ay, string Yıl)
        {
            Sorgu1 = "Select * from HausNotlar where Format(YapılacakTarih,'MMMM')='" + Ay + "' And Format(YapılacakTarih,'yyyy')='" + Yıl + "'";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo3);
            
        }

        public void HausPlanlamaVeri(string Ay, string Yıl)
        {
            Sorgu1 = "Select * from HausPlan where Format(PlanlananTarih,'MMMM')='" + Ay + "' And Format(PlanlananTarih,'yyyy')='" + Yıl + "'";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo9);
        }

        public void HausNotlarGözAt(string değer,string Yıl, string Ay)
        {
            string Sorgu1 = "Select SicilNo,İsim,ServisNo,Bilgi,YapılacakTarih from HausNotlar where Format(YapılacakTarih,'MMMM')='" + Ay + "' And Format(YapılacakTarih,'yyyy')='" + Yıl + "' And Format(YapılacakTarih,'D')='" + değer + "'";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo4);
        }

        public void HausNotlarVeriEkle(string x3, string x4, DateTimePicker DtPicker1)
        {
            Sorgu1 = "Insert Into HausNotlar(SicilNo,İsim,ServisNo,Bilgi,YapılacakTarih) Values(@1,@2,@3,@4,@5)";
            DL.databasebağlan();
            Komut = new OleDbCommand(Sorgu1, VeriKatmanı.Bağlantı);
            Komut.Parameters.AddWithValue("@1", HausKullanıcıVeri[0]);
            Komut.Parameters.AddWithValue("@2", HausKullanıcıVeri[1]);
            Komut.Parameters.AddWithValue("@3", x3);
            Komut.Parameters.AddWithValue("@4", x4);
            Komut.Parameters.AddWithValue("@5", Convert.ToDateTime(DtPicker1.Text));
            Komut.ExecuteNonQuery();
            VeriKatmanı.Bağlantı.Dispose();
            VeriKatmanı.Bağlantı.Close();
        }


        public void HausİşPlanla(string x1,string x2,string x3,string x4,string x5,int x6, DateTimePicker DataPicker,string x7, string x8, string x9,string x10,string x11,string x12,string x13,string x14,string x15, string x16, string x17, string x18)
        {
            Sorgu1 = "Insert into HausPlan(MüşteriNo,FirmaAdı,Şehir,Telefon,Yapılacakİş,İşSüresi,PlanlananTarih,SicilNo1,Operatör1,Uzmanlık1,SicilNo2,Operatör2,Uzmanlık2,SicilNo3,Operatör3,Uzmanlık3,SicilNo4,Operatör4,Uzmanlık4) Values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19)";

            DL.databasebağlan();
            Komut = new OleDbCommand(Sorgu1, VeriKatmanı.Bağlantı);
            Komut.Parameters.AddWithValue("@1", x1);
            Komut.Parameters.AddWithValue("@2", x2);
            Komut.Parameters.AddWithValue("@3", x3);
            Komut.Parameters.AddWithValue("@4", x4);
            Komut.Parameters.AddWithValue("@5", x5);
            Komut.Parameters.AddWithValue("@6", Convert.ToInt16(x6));
            Komut.Parameters.AddWithValue("@7", Convert.ToDateTime(DataPicker.Text));
            Komut.Parameters.AddWithValue("@8", x7);
            Komut.Parameters.AddWithValue("@9", x8);
            Komut.Parameters.AddWithValue("@10", x9);
            Komut.Parameters.AddWithValue("@11", x10);
            Komut.Parameters.AddWithValue("@12", x11);
            Komut.Parameters.AddWithValue("@13", x12);
            Komut.Parameters.AddWithValue("@14", x13);
            Komut.Parameters.AddWithValue("@15", x14);
            Komut.Parameters.AddWithValue("@16", x15);
            Komut.Parameters.AddWithValue("@17", x16);
            Komut.Parameters.AddWithValue("@18", x17);
            Komut.Parameters.AddWithValue("@19", x18);

            Komut.ExecuteNonQuery();
            VeriKatmanı.Bağlantı.Dispose();
            VeriKatmanı.Bağlantı.Close();
        
        }

        public void HausİşEmriVeriEkle(string ServisNo, string MüşteriNo, string FirmaAdı, string Yapılacakİş, string TahminiSüre, DateTimePicker DataPicker, string SicilNo1, string Ad1, string SicilNo2, string Ad2, string SicilNo3, string Ad3, string SicilNo4, string Ad4)
        {

            Sorgu1 = "Insert into HausİşEmri(ServisNo,MüşteriNo,FirmaAdı,Yapılacakİş,İşSüresi,ServisBaşlamaTarihi,SicilNo1,Ad1,SicilNo2,Ad2,SicilNo3,Ad3,SicilNo4,Ad4) Values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14)";

            DL.databasebağlan();
            Komut = new OleDbCommand(Sorgu1, VeriKatmanı.Bağlantı);
            Komut.Parameters.AddWithValue("@1", ServisNo);
            Komut.Parameters.AddWithValue("@2", MüşteriNo);
            Komut.Parameters.AddWithValue("@3", FirmaAdı);
            Komut.Parameters.AddWithValue("@4", Yapılacakİş);
            Komut.Parameters.AddWithValue("@5", Convert.ToInt16(TahminiSüre));
            Komut.Parameters.AddWithValue("@6", Convert.ToDateTime(DataPicker.Text));
            Komut.Parameters.AddWithValue("@7", SicilNo1);
            Komut.Parameters.AddWithValue("@8", Ad1);
            Komut.Parameters.AddWithValue("@9", SicilNo2);
            Komut.Parameters.AddWithValue("@10", Ad2);
            Komut.Parameters.AddWithValue("@11", SicilNo3);
            Komut.Parameters.AddWithValue("@12", Ad3);
            Komut.Parameters.AddWithValue("@13", SicilNo4);
            Komut.Parameters.AddWithValue("@14", Ad4);
            Komut.ExecuteNonQuery();
            VeriKatmanı.Bağlantı.Dispose();
            VeriKatmanı.Bağlantı.Close();

        }

        public void HausİşEmriBittiVeriEkle(string ServisNo,string MüşteriNo,string FirmaAdı, string Gün,DateTimePicker DataPicker)
        {
            Sorgu1 = "Insert into HausİşEmriBitti(ServisNo,MüşteriNo,FirmaAdı,BitişTarihi,BaşlangıçTarihi) Values(@1,@2,@3,@4,@5)";

            DL.databasebağlan();
            Komut = new OleDbCommand(Sorgu1, VeriKatmanı.Bağlantı);
            Komut.Parameters.AddWithValue("@1", ServisNo);
            Komut.Parameters.AddWithValue("@2", MüşteriNo);
            Komut.Parameters.AddWithValue("@3", FirmaAdı);
            Komut.Parameters.AddWithValue("@4", Convert.ToDateTime(Gün));
            Komut.Parameters.AddWithValue("@5", Convert.ToDateTime(DataPicker.Text));
            Komut.ExecuteNonQuery();
            VeriKatmanı.Bağlantı.Dispose();
            VeriKatmanı.Bağlantı.Close();
        
        }


        public void HausMüşterilerTümVeri(DataGridView DataGrid)
        {
            Sorgu1 = "Select * from HausMüşteri";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo5);
            DataGrid.DataSource = Tablo5;
        }

        public void HausMüsteriVeri(string MüsteriNo)
        {
            Sorgu1 = "Select * from HausMüşteri where MüsteriNo='" + MüsteriNo + "'";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo6);
        }

        public void HausOperatörBelirle(string[] HausUzmanlık)
        {
            Sorgu1 = "Select * from HausOperatör where Durum=0 And (Uzmanlık='" + HausUzmanlık[0] + "' OR Uzmanlık='" + HausUzmanlık[1] + "' OR Uzmanlık='" + HausUzmanlık[2] + "' OR Uzmanlık='" + HausUzmanlık[3] + "' OR Uzmanlık='" + HausUzmanlık[4] + "' OR Uzmanlık='" + HausUzmanlık[5] + "')";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo7);

        }



        public void HausTümOperatörler(DataGridView DataGrid)
        {
            Sorgu1 = "Select * from HausOperatör";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo8);
            DataGrid.DataSource = Tablo8;
        }

        public void HausPlanlamaVeri(DataGridView DataGrid)
        {
            Sorgu1 = "Select * from HausPlan";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo9);
            DataGrid.DataSource = Tablo9;
        
        }

        public void HausPlanlamaTekVeri(int Id)
        {
            Sorgu1 = "Select * from HausPlan where Id="+Id+"";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo10);
            
        }

        public void HausİşEmriTekVeri(string MüsteriNo)
        {
            Sorgu1 = "Select * from HausİşEmri where ServisNo='" + MüsteriNo + "'";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo12);
        }

        public void HausİşEmriVeri(DataGridView DataGrid)
        {
            Sorgu1 = "Select * from HausİşEmri";
            DL.databasebağlan();
            DL.GenelVeriÇek(Sorgu1, Komut, Kayıt, Tablo11);
            DataGrid.DataSource = Tablo11;
        
        }

        #endregion

        #region Form Aç

        public void FormAç(Form Form1, Form Form2)
        {
            Form1.Hide();
            Form2.ShowDialog();
            Form1.Show();
        }

       
        #endregion

        #region Form Simge Durumu

        public void SimgeDurumu(Form Form1)
        {
            Form1.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Günün Zamanı

        public DateTime Zaman()
        {
            return DateTime.Now;
        }

        #endregion

        #region Login Form ToolBilgilendirme

        public void Bilgilendirme(ToolTip tooltip1, Control cntrl1, Control cntrl2, Control cntrl3, Control cntrl4, Control cntrl5, Control cntrl6, Control cntrl7, string str1, string str2, string str3, string str4, string str5, string str6,string str7)
        {
            tooltip1 = new ToolTip();

            tooltip1.SetToolTip(cntrl1, str1);
            tooltip1.SetToolTip(cntrl2, str2);
            tooltip1.SetToolTip(cntrl3, str3);
            tooltip1.SetToolTip(cntrl4, str4);
            tooltip1.SetToolTip(cntrl5, str5);
            tooltip1.SetToolTip(cntrl6, str6);
            tooltip1.SetToolTip(cntrl7, str7);
        }

        #endregion

        #region Form Taşıma

        public void MouseDown(Form Form1, MouseEventArgs mearg)
        {
            Durum = true;
            Form1.Cursor = Cursors.SizeAll;
            İlkKonum = mearg.Location;
        }

        public void MouseMove(Form Form1, MouseEventArgs mearg)
        {
            if (Durum)
            {
                Form1.Left = mearg.X + Form1.Left - (İlkKonum.X);
                Form1.Top = mearg.Y + Form1.Top - (İlkKonum.Y);
            }
        }

        public void MouseUp(Form Form1)
        {
            Durum = false;
            Form1.Cursor = Cursors.Default;
        }

        #endregion

        #region Ekstra İşlemler


        public void AdminVerisiniTut(int i1)
        {
            HausKullanıcıVeri[0] = Tablo1.Rows[i1]["SicilNo"].ToString();
            HausKullanıcıVeri[1] = Tablo1.Rows[i1]["İsim"].ToString();
            HausKullanıcıVeri[2] = Tablo1.Rows[i1]["Yetki"].ToString();
            HausKullanıcıVeri[3] = Tablo1.Rows[i1]["Resim"].ToString();
            HausKullanıcıVeri[4] = Tablo1.Rows[i1]["Mail"].ToString();
            HausKullanıcıVeri[5] = Tablo1.Rows[i1]["Yer"].ToString();
        }

        #endregion

        #region TextBox Üretme

        RichTextBox[] SITextDizi = new RichTextBox[Tablo2.Rows.Count];
        string[] SITZaman = new string[2];

        int SITx;
        int SITz1;


        public void Sonİşlemler(Panel Panel1)
        {
            SITx = -45;
            SonİşlemlerVeriAl();
            Panel1.Controls.Clear();

            Array.Resize(ref SITextDizi, Tablo2.Rows.Count);
            SITz1 = Tablo2.Rows.Count;


            for (int i1 = 0; i1 < Tablo2.Rows.Count; i1++)
            {
                RichTextBox SIText = new RichTextBox();
                SITz1--;

                SITZaman[0] = Tablo2.Rows[SITz1]["Tarih"].ToString().Split(' ')[0].ToString(); // Uzun tarihin sadece tarih kısmını aldık.
                SITZaman[1] = Tablo2.Rows[SITz1]["Tarih"].ToString().Split(' ')[1].ToString(); // Uzun tarihin sadece saat  kısmını aldık.

                SIText.Name = "SIText" + i1;
                SIText.Font = new Font("Century Gothic", 14, FontStyle.Regular);
                SIText.ReadOnly = true;
                SIText.BorderStyle = BorderStyle.FixedSingle;
                SIText.Size = new Size(1037, 42);
                SIText.Anchor = (AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
                SIText.Location = new Point(3, SITx + 48);
                SITextDizi[i1] = SIText;
                Panel1.Controls.Add(SITextDizi[i1]);

                SITx += 48;

                SIText.Text = Tablo2.Rows[SITz1]["Id"].ToString() + " - " + Tablo2.Rows[SITz1]["ServisNo"].ToString() + " Nolu İşlem için " + SITZaman[0] + " Tarihinde Saat " + SITZaman[1] + "\'de " + Tablo2.Rows[SITz1]["İsim"].ToString() + " Tarafından " + Tablo2.Rows[SITz1]["Yapılanİş"].ToString();
               
            }
           
        }

        #endregion

        #endregion

        #region Aylar

        public static string Ayismi;

        public void AyBelirle(int Ay)
        {
            switch (Ay)
            {
                case 1: Ayismi = "Ocak"; break;
                case 2: Ayismi = "Şubat"; break;
                case 3: Ayismi = "Mart"; break;
                case 4: Ayismi = "Nisan"; break;
                case 5: Ayismi = "Mayıs"; break;
                case 6: Ayismi = "Haziran"; break;
                case 7: Ayismi = "Temmuz"; break;
                case 8: Ayismi = "Ağustos"; break;
                case 9: Ayismi = "Eylül"; break;
                case 10: Ayismi = "Ekim"; break;
                case 11: Ayismi = "Kasım"; break;
                case 12: Ayismi = "Aralık"; break;
                default: break;
            }
        
        }

        #endregion
    }
}