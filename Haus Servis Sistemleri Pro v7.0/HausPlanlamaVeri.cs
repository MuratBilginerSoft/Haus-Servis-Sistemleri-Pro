using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Haus_Servis_Sistemleri_Pro_v7._0
{
    public partial class HausPlanlamaVeri : Form
    {
        public HausPlanlamaVeri()
        {
            InitializeComponent();
        }

        private void PicKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HausPlanlamaVeri_Load(object sender, EventArgs e)
        {

        }

        private void DataPlan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TextMüşteriNo.Text = DataPlan.CurrentRow.Cells[1].Value.ToString();
            TextFirmaİsmi.Text = DataPlan.CurrentRow.Cells[2].Value.ToString();
            Clipboard.SetDataObject(DataPlan.CurrentRow.Cells[0].Value.ToString(), true);
        }
    }
}
