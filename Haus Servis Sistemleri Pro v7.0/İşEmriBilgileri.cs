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
    public partial class İşEmriBilgileri : Form
    {
        İşKatmanı BL = new İşKatmanı();

        public İşEmriBilgileri()
        {
            InitializeComponent();
        }

        private void PicGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void İşEmriBilgileri_Load(object sender, EventArgs e)
        {
            BL.HausİşEmriVeri(dataGridView1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TextServisNo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Clipboard.SetDataObject(dataGridView1.CurrentRow.Cells[1].Value.ToString(), true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
