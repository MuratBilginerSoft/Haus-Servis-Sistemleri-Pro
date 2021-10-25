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
    public partial class HausMüşteri : Form
    {
        İşKatmanı BusinesLayer = new İşKatmanı();

        int süre1 = 0;

        public HausMüşteri()
        {
            InitializeComponent();
        }

        private void PicGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HausMüşteri_Load(object sender, EventArgs e)
        {
            BusinesLayer.HausMüşterilerTümVeri(dataGridView1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TextMüşteri.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TextFirma.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Clipboard.SetDataObject(dataGridView1.CurrentRow.Cells[1].Value.ToString(), true);
            
        }

        private void Menüİpucu1_Click(object sender, EventArgs e)
        {
            Lblİpucu.Text = "İpucu: Seçmek istediğiniz müşteri üzerine çift tıkladığınızda panoya Müşteri No kopyalanacaktır.";
        }

        private void Menüİpucu2_Click(object sender, EventArgs e)
        {
            Lblİpucu.Text = "Geri dönerek kopyalanmış müşteri kaydı ile Müşteri bilgilerini ekrana yansıtabilirsiniz.";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
