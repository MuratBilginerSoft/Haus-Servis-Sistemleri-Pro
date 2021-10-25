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
    public partial class HausOperatör : Form
    {
        İşKatmanı BusinesLayer = new İşKatmanı();
        public static int Id=1;

        public HausOperatör()
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

        private void HausOperatör_Load(object sender, EventArgs e)
        {
            BusinesLayer.HausTümOperatörler(DataOperatör);
        }

        private void DataOperatör_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Id =Convert.ToInt16(DataOperatör.CurrentRow.Cells[0].Value.ToString());
            TextSicil.Text = DataOperatör.CurrentRow.Cells[1].Value.ToString();
            TextSicil.Text = Id.ToString();
            Textİsim.Text = DataOperatör.CurrentRow.Cells[3].Value.ToString();
            TextUzmanlık.Text = DataOperatör.CurrentRow.Cells[2].Value.ToString();
            Clipboard.SetDataObject(DataOperatör.CurrentRow.Cells[1].Value.ToString(), true);
        }
    }
}
