namespace Haus_Servis_Sistemleri_Pro_v7._0
{
    partial class HausNotGözAt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HausNotGözAt));
            this.PanelMenü = new System.Windows.Forms.Panel();
            this.LblSaat = new System.Windows.Forms.Label();
            this.PicGeri = new System.Windows.Forms.PictureBox();
            this.PanelGövde = new System.Windows.Forms.Panel();
            this.DataGridNot = new System.Windows.Forms.DataGridView();
            this.PanelDurum = new System.Windows.Forms.Panel();
            this.TimerSaat = new System.Windows.Forms.Timer(this.components);
            this.PanelMenü.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicGeri)).BeginInit();
            this.PanelGövde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridNot)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMenü
            // 
            this.PanelMenü.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelMenü.BackColor = System.Drawing.Color.Transparent;
            this.PanelMenü.Controls.Add(this.LblSaat);
            this.PanelMenü.Controls.Add(this.PicGeri);
            this.PanelMenü.Location = new System.Drawing.Point(0, 0);
            this.PanelMenü.Name = "PanelMenü";
            this.PanelMenü.Size = new System.Drawing.Size(884, 31);
            this.PanelMenü.TabIndex = 0;
            // 
            // LblSaat
            // 
            this.LblSaat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSaat.BackColor = System.Drawing.Color.Transparent;
            this.LblSaat.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSaat.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LblSaat.Image = global::Haus_Servis_Sistemleri_Pro_v7._0.Properties.Resources._30_Saat1;
            this.LblSaat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblSaat.Location = new System.Drawing.Point(787, 5);
            this.LblSaat.Name = "LblSaat";
            this.LblSaat.Size = new System.Drawing.Size(94, 23);
            this.LblSaat.TabIndex = 11;
            this.LblSaat.Text = "09:02:23";
            this.LblSaat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PicGeri
            // 
            this.PicGeri.BackColor = System.Drawing.Color.Transparent;
            this.PicGeri.Image = global::Haus_Servis_Sistemleri_Pro_v7._0.Properties.Resources.arrow_92_xl_6;
            this.PicGeri.Location = new System.Drawing.Point(0, 1);
            this.PicGeri.Name = "PicGeri";
            this.PicGeri.Size = new System.Drawing.Size(44, 30);
            this.PicGeri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicGeri.TabIndex = 9;
            this.PicGeri.TabStop = false;
            this.PicGeri.Click += new System.EventHandler(this.PicGeri_Click);
            // 
            // PanelGövde
            // 
            this.PanelGövde.BackColor = System.Drawing.Color.Transparent;
            this.PanelGövde.Controls.Add(this.DataGridNot);
            this.PanelGövde.Location = new System.Drawing.Point(0, 37);
            this.PanelGövde.Name = "PanelGövde";
            this.PanelGövde.Size = new System.Drawing.Size(881, 324);
            this.PanelGövde.TabIndex = 2;
            // 
            // DataGridNot
            // 
            this.DataGridNot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridNot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridNot.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridNot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridNot.Location = new System.Drawing.Point(3, 3);
            this.DataGridNot.Name = "DataGridNot";
            this.DataGridNot.Size = new System.Drawing.Size(875, 318);
            this.DataGridNot.TabIndex = 0;
            // 
            // PanelDurum
            // 
            this.PanelDurum.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.PanelDurum.Location = new System.Drawing.Point(3, 367);
            this.PanelDurum.Name = "PanelDurum";
            this.PanelDurum.Size = new System.Drawing.Size(878, 33);
            this.PanelDurum.TabIndex = 3;
            // 
            // TimerSaat
            // 
            this.TimerSaat.Tick += new System.EventHandler(this.TimerSaat_Tick);
            // 
            // HausNotGözAt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Haus_Servis_Sistemleri_Pro_v7._0.Properties.Resources._19_ArkaPlan;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(885, 401);
            this.Controls.Add(this.PanelDurum);
            this.Controls.Add(this.PanelGövde);
            this.Controls.Add(this.PanelMenü);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "HausNotGözAt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HausNotGözAt";
            this.Load += new System.EventHandler(this.HausNotGözAt_Load);
            this.PanelMenü.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicGeri)).EndInit();
            this.PanelGövde.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridNot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenü;
        private System.Windows.Forms.PictureBox PicGeri;
        private System.Windows.Forms.Label LblSaat;
        private System.Windows.Forms.Panel PanelGövde;
        private System.Windows.Forms.Panel PanelDurum;
        private System.Windows.Forms.Timer TimerSaat;
        public System.Windows.Forms.DataGridView DataGridNot;
    }
}