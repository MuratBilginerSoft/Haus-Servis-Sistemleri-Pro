using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataLayer
{
    public class VeriKatmanı
    {
        #region Tanımalamalar

        public static OleDbConnection Bağlantı; // Bağlantı Nesnesi

        #endregion

        #region Veri Tabanı İşlemleri

        public void databasebağlan()
        {
            Bağlantı = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=HausHataÇizelge.accdb"); // Veri Tabanı Bağlatısı

            if (Bağlantı.State == ConnectionState.Closed)  // Bağlantı Açıkmı Kontrolü 
            {
                Bağlantı.Open(); // Bağlantı Açtık
            }

            else
            {
                Bağlantı.Close(); // Açık Bağlantı varsa kapattık.
                Bağlantı.Open();  // Bağlatıyı Açtık
            }
        }

        public void GenelVeriÇek(string sorgux, OleDbCommand komutx, OleDbDataAdapter kayıtx, DataTable tablox)
        {
            databasebağlan(); // Databasebağlan metodu çağrıldı.
            tablox.Clear(); // Tablo Verilerini Temizledik
            tablox.Dispose();
            komutx = new OleDbCommand(sorgux, Bağlantı);  // Sorgumuzun komutunu çalıştırdık.
            kayıtx = new OleDbDataAdapter(komutx); // Komutla çağrılan değerler kayda alındı.
            kayıtx.Fill(tablox); // Kayıda gelen değerler tabloya aktarıldı.
            kayıtx.Dispose(); // Kayıt Temizlendi.
            Bağlantı.Dispose(); // Bağlantı Temizlendi.
            Bağlantı.Close(); // Bağlantı Kapatıldı.
        }

        #endregion

    }
}
