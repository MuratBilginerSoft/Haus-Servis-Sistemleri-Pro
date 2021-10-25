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
    public partial class HausTakvim : Form
    {
        int Yıl, Ay; // DateTimePicker daki yıl ve Ay değerini alan değişkenler.

        İşKatmanı BusinesLayer = new İşKatmanı();

        #region Buton Üret

        Button[] NBDizi = new Button[31];

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
                Btn.ForeColor = Color.White;
                Btn.Anchor = (AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
                Btn.Font = new Font("Georgia", 30, FontStyle.Regular);
                Btn.Size = new System.Drawing.Size(210, 100);
                //Btn.BackgroundImage = Image.FromFile("4 Takvim.png");
                Btn.Click += new EventHandler(Btn_Click);
                NBDizi[i3] = Btn;
                FlowTakvim.Controls.Add(Btn);
            }
        }


        int değer;

        void Btn_Click(object sender, EventArgs e)
        {

            if (RadioPlanlama.Checked == true)
            {
                if ((sender as Button).BackColor != Color.White)
                {
                    değer = Convert.ToInt16((sender as Button).Text);
                    NBDizi[değer - 1].BackColor = Color.Red;
                    TimerButonKontrol.Start();
                    GeriSayım = 10;
                }

                else
                {
                    değer = Convert.ToInt16((sender as Button).Text);
                    BusinesLayer.HausNotlarGözAt(Convert.ToString(değer), Convert.ToString(Yıl), İşKatmanı.Ayismi);
                    //HNGForm.DataGridNot.DataSource = İşKatmanı.Tablo4;
                    //this.Enabled = false;
                    //HNGForm.ShowDialog();
                    //this.Enabled = true;
                }
            }
        }

        int gün;

        public void ButonRenklendirme()
        {
            for (int i = 0; i < İşKatmanı.Tablo9.Rows.Count; i++)
            {
                gün = Convert.ToDateTime(İşKatmanı.Tablo9.Rows[i]["PlanlananTarih"].ToString().Split(' ')[0].ToString()).Day;
                NBDizi[gün - 1].BackgroundImage = Image.FromFile("3 Takvim.png");
                NBDizi[gün - 1].BackColor = Color.White;
                NBDizi[gün - 1].ForeColor = Color.MidnightBlue;
            }
        }

        #endregion
        public HausTakvim()
        {
            InitializeComponent();
        }

        private void PicKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HausTakvim_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            Yıl = DateTimePicker.Value.Year;
            Ay = DateTimePicker.Value.Month;


            FlowTakvim.Visible = false;
            FlowTakvim.Controls.Clear();
            FlowTakvim.Visible = false;
            BusinesLayer.AyBelirle(Ay);

            BusinesLayer.HausPlanlamaVeri(İşKatmanı.Ayismi, Convert.ToString(Yıl));
            ButonOluştur(FlowTakvim, İşKatmanı.Ayismi);
            ButonRenklendirme();

            FlowTakvim.Visible = true;
            
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Yıl = DateTimePicker.Value.Year;
            Ay = DateTimePicker.Value.Month;
            FlowTakvim.Visible = false;
            FlowTakvim.Controls.Clear();
            BusinesLayer.AyBelirle(Ay);
            BusinesLayer.HausNotlarVeri(İşKatmanı.Ayismi, Convert.ToString(Yıl));
            ButonOluştur(FlowTakvim, İşKatmanı.Ayismi);
            ButonRenklendirme();
            FlowTakvim.Visible = true;
        }

        int GeriSayım = 15;

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

                
            }

            GeriSayım--;
        }
    }
}
