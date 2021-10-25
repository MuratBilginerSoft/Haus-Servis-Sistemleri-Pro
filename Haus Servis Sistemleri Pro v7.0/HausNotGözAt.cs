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
    public partial class HausNotGözAt : Form
    {
        İşKatmanı BusinesLayer = new İşKatmanı();

        public HausNotGözAt()
        {
            InitializeComponent();
        }

        private void TimerSaat_Tick(object sender, EventArgs e)
        {
            LblSaat.Text = BusinesLayer.Zaman().ToLongTimeString();
        }

        private void HausNotGözAt_Load(object sender, EventArgs e)
        {
            TimerSaat.Start();
            //DgwDüzenle();
        }

        private void PicGeri_Click(object sender, EventArgs e)
        {
            this.Close();
            TimerSaat.Stop();
        }
    }
}
