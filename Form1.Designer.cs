namespace Shopping_cart
{
    partial class Cos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            lblNumarProduse = new ToolStripStatusLabel();
            lblValoareCos = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            adaugaProdusToolStripMenuItem = new ToolStripMenuItem();
            stergeProdusToolStripMenuItem = new ToolStripMenuItem();
            tiparesteToolStripMenuItem = new ToolStripMenuItem();
            fisiereToolStripMenuItem = new ToolStripMenuItem();
            importaToolStripMenuItem = new ToolStripMenuItem();
            exportaToolStripMenuItem = new ToolStripMenuItem();
            splitter1 = new Splitter();
            dataGridView1 = new DataGridView();
            panelGrafic = new Panel();
            splitter2 = new Splitter();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelGrafic.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblNumarProduse, lblValoareCos });
            statusStrip1.Location = new Point(0, 418);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(780, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblNumarProduse
            // 
            lblNumarProduse.Name = "lblNumarProduse";
            lblNumarProduse.Size = new Size(179, 25);
            lblNumarProduse.Text = "toolStripStatusLabel1";
            lblNumarProduse.Click += toolStripStatusLabel1_Click;
            // 
            // lblValoareCos
            // 
            lblValoareCos.Name = "lblValoareCos";
            lblValoareCos.Size = new Size(179, 25);
            lblValoareCos.Text = "toolStripStatusLabel2";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adaugaProdusToolStripMenuItem, stergeProdusToolStripMenuItem, tiparesteToolStripMenuItem, fisiereToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(780, 33);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // adaugaProdusToolStripMenuItem
            // 
            adaugaProdusToolStripMenuItem.Image = Properties.Resources._360_F_766163454_FWF3w2m7xvVhd4DRlfT9Pj5mAVZdte4d;
            adaugaProdusToolStripMenuItem.Name = "adaugaProdusToolStripMenuItem";
            adaugaProdusToolStripMenuItem.Size = new Size(175, 29);
            adaugaProdusToolStripMenuItem.Text = "Adauga Produs";
            adaugaProdusToolStripMenuItem.Click += adaugaProdusToolStripMenuItem_Click;
            // 
            // stergeProdusToolStripMenuItem
            // 
            stergeProdusToolStripMenuItem.Image = Properties.Resources.pngimg_com___minus_PNG64;
            stergeProdusToolStripMenuItem.Name = "stergeProdusToolStripMenuItem";
            stergeProdusToolStripMenuItem.Size = new Size(163, 29);
            stergeProdusToolStripMenuItem.Text = "Sterge Produs";
            stergeProdusToolStripMenuItem.Click += stergeProdusToolStripMenuItem_Click;
            // 
            // tiparesteToolStripMenuItem
            // 
            tiparesteToolStripMenuItem.Image = Properties.Resources.ModernXP_04_Printer_icon;
            tiparesteToolStripMenuItem.Name = "tiparesteToolStripMenuItem";
            tiparesteToolStripMenuItem.Size = new Size(123, 29);
            tiparesteToolStripMenuItem.Text = "Tipareste";
            tiparesteToolStripMenuItem.Click += tiparesteToolStripMenuItem_Click;
            // 
            // fisiereToolStripMenuItem
            // 
            fisiereToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importaToolStripMenuItem, exportaToolStripMenuItem });
            fisiereToolStripMenuItem.Image = Properties.Resources._4807934;
            fisiereToolStripMenuItem.Name = "fisiereToolStripMenuItem";
            fisiereToolStripMenuItem.Size = new Size(101, 29);
            fisiereToolStripMenuItem.Text = "Fisiere";
            // 
            // importaToolStripMenuItem
            // 
            importaToolStripMenuItem.Image = Properties.Resources.import_icon_1024x853_zp8147mg;
            importaToolStripMenuItem.Name = "importaToolStripMenuItem";
            importaToolStripMenuItem.Size = new Size(270, 34);
            importaToolStripMenuItem.Text = "Importa";
            importaToolStripMenuItem.Click += importaToolStripMenuItem_Click;
            // 
            // exportaToolStripMenuItem
            // 
            exportaToolStripMenuItem.Image = Properties.Resources.export_icon_512x512_gmcapptp;
            exportaToolStripMenuItem.Name = "exportaToolStripMenuItem";
            exportaToolStripMenuItem.Size = new Size(270, 34);
            exportaToolStripMenuItem.Text = "Exporta";
            exportaToolStripMenuItem.Click += exportaToolStripMenuItem_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 33);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(10, 385);
            splitter1.TabIndex = 3;
            splitter1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(499, 382);
            dataGridView1.TabIndex = 4;
            // 
            // panelGrafic
            // 
            panelGrafic.Controls.Add(splitter2);
            panelGrafic.Location = new Point(505, 36);
            panelGrafic.Name = "panelGrafic";
            panelGrafic.Size = new Size(282, 382);
            panelGrafic.TabIndex = 5;
            // 
            // splitter2
            // 
            splitter2.Location = new Point(0, 0);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(4, 382);
            splitter2.TabIndex = 0;
            splitter2.TabStop = false;
            // 
            // Cos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 450);
            Controls.Add(panelGrafic);
            Controls.Add(dataGridView1);
            Controls.Add(splitter1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Cos";
            Text = "Cosul tau:";
            FormClosing += Cos_FormClosing;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelGrafic.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblNumarProduse;
        private ToolStripStatusLabel lblValoareCos;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem adaugaProdusToolStripMenuItem;
        private ToolStripMenuItem stergeProdusToolStripMenuItem;
        private ToolStripMenuItem tiparesteToolStripMenuItem;
        private Splitter splitter1;
        private DataGridView dataGridView1;
        private Panel panelGrafic;
        private Splitter splitter2;
        private ToolStripMenuItem fisiereToolStripMenuItem;
        private ToolStripMenuItem importaToolStripMenuItem;
        private ToolStripMenuItem exportaToolStripMenuItem;
    }
}
