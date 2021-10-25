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
    public partial class HausStartPage : Form
    {
        #region Tanımlamalar

        İşKatmanı BusinesLayer = new İşKatmanı(); // Business Layer a ait iş katmanı sınıfından bir nesne türetildi.

        HausLoginPanel HLPForm = new HausLoginPanel(); // HausloginPanel Form nesnesi türetildi.

        #endregion

        #region Ana İşlemler

        public HausStartPage()
        {
            InitializeComponent();
        }

        private void HausStartPage_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BusinesLayer.AnimasyonSayaç(progressBar1, timer1, this,HLPForm);
        }

        #endregion
    }
}
