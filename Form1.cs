using System;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Shopping_cart
{
    public partial class Cos : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        public Cos()
        {
            InitializeComponent();
            dataGridView1.DataSource = Program.cos.produse;
            Program.cos.AdaugareProdus += Modificare_Cos;
            Program.cos.StergereProdus += Modificare_Cos;
            Program.cos.ModificareProdus += Modificare_Cos;
            ActualizeazaStatus();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            printDocument.PrintPage += PrintDocument_PrintPage;
            printPreviewDialog.Document = printDocument;
            panelGrafic.Paint += panelGrafic_Paint;
            panelGrafic.Invalidate();

        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                StergeProdusSelectat();
            }

        }

        private void Modificare_Cos(object sender, Produs produs)
        {
            dataGridView1.Refresh();
            ActualizeazaStatus();
            panelGrafic.Invalidate();
        }

        private void ActualizeazaStatus()
        {
            lblNumarProduse.Text = $"Numar produse: {Program.cos.NumarProduse}";
            lblValoareCos.Text = $"Valoarea cosului: {Program.cos.ValoreTotala}";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void adaugaProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formular2 = new FormAdaugare();
            if (formular2.ShowDialog() == DialogResult.OK)
            {
                Produs produsDeAdaugat = formular2.prodSelectat;
                if (produsDeAdaugat != null) Program.cos.AdaugaProdus(produsDeAdaugat);
            }

        }

        private void stergeProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StergeProdusSelectat();
        }

        private void StergeProdusSelectat()
        {
            if (dataGridView1.CurrentRow != null)
            {
                var produs = dataGridView1.CurrentRow.DataBoundItem as Produs;
                if (produs != null)
                {
                    var confirmare = MessageBox.Show("Esti sigur ca vrei sa stergi produsul selectat? :(", "Confirmare", MessageBoxButtons.YesNo);
                    if (confirmare == DialogResult.Yes)
                    {
                        Program.cos.StergeProdus(produs.Cod);
                        MessageBox.Show("Produsul a fost sters, dar inca te poti razgandi!");
                    }
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void tiparesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 16);
            float y = 100;
            float x = 100;
            float lineHeight = font.GetHeight(e.Graphics) + 5;

            e.Graphics.DrawString("Cosul de cumparaturi", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, x, y);
            y += 40;

            foreach (var produs in Program.cos.produse)
            {
                string line = $"Cod: {produs.Cod} | Denumire: {produs.Denumire} | Pret: {produs.Pret:0.00} | Cantitate: {produs.Cantitate}";
                e.Graphics.DrawString(line, font, Brushes.Black, x, y);
                y += lineHeight;
            }

            y += 20;
            string total = $"Total: {Program.cos.ValoreTotala:0.00} RON";
            e.Graphics.DrawString(total, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, x, y);
            e.HasMorePages = false;
        }

        private void Cos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.SaveProduse(Program.cos.produse.ToList());
        }

        private void panelGrafic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var produse = Program.cos.produse.ToList();

            if (produse.Count == 0)
            {
                g.DrawString("Nu exista produse în cos pentru a afisa graficul.",
                             new Font("Arial", 10), Brushes.Gray, 10, 10);
                return;
            }

            decimal total = produse.Sum(p => p.Pret * p.Cantitate);
            if (total == 0)
            {
                g.DrawString("Valoarea totala a cosului este 0.",
                             new Font("Arial", 10), Brushes.Gray, 10, 10);
                return;
            }

            int availableWidth = panelGrafic.Width - 40;
            int availableHeight = panelGrafic.Height - 40;


            int pieDiameter = (int)(Math.Min(availableWidth, availableHeight) * 0.8);

            if (pieDiameter <= 0) return;
            int pieX = (panelGrafic.Width - pieDiameter) / 2;
            int pieY = 20;
            Rectangle pieRect = new Rectangle(pieX, pieY, pieDiameter, pieDiameter);

            float startAngle = 0f;
            Random rnd = new Random();
            List<Color> colors = new List<Color>();
            foreach (var produs in produse)
            {
                decimal valoare = produs.Pret * produs.Cantitate;
                float sweepAngle = (float)(valoare / total * 360);

                Color culoare = Color.FromArgb(rnd.Next(50, 200), rnd.Next(50, 200), rnd.Next(50, 200));
                colors.Add(culoare);

                using (Brush brush = new SolidBrush(culoare))
                {
                    g.FillPie(brush, pieRect, startAngle, sweepAngle);
                    g.DrawPie(Pens.Black, pieRect, startAngle, sweepAngle);
                }

                startAngle += sweepAngle;
            }


            int legendX = 20;
            int legendY = pieRect.Bottom + 30;

            int lineHeight = 20;
            int colorBoxSize = 15;
            Font legendFont = new Font("Arial", 9);

            g.DrawString("Distributia Valorii Produselor:", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, legendX, legendY);
            legendY += 25;

            for (int i = 0; i < produse.Count; i++)
            {
                var produs = produse[i];
                decimal valoare = produs.Pret * produs.Cantitate;
                string eticheta = $"{produs.Denumire}: {valoare:C2} ({(valoare / total * 100):0.0}%)";

                Rectangle colorRect = new Rectangle(legendX, legendY, colorBoxSize, colorBoxSize);
                using (Brush legendBrush = new SolidBrush(colors[i]))
                {
                    g.FillRectangle(legendBrush, colorRect);
                    g.DrawRectangle(Pens.Black, colorRect);
                }

                g.DrawString(eticheta, legendFont, Brushes.Black, legendX + colorBoxSize + 5, legendY);

                legendY += lineHeight;
            }

            string chartTitle = "Analiza Valorii Cosului";
            Font titleFont = new Font("Arial", 11, FontStyle.Bold);
            SizeF titleSize = g.MeasureString(chartTitle, titleFont);
            g.DrawString(chartTitle, titleFont, Brushes.Black,
                         (panelGrafic.Width / 2) - (titleSize.Width / 2), -5);
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void importaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Fisiere text (*.txt)|*.txt|Toate fisierele (*.*)|*.*";
                openFileDialog.Title = "Importa cosul de cumparaturi";

                if (openFileDialog.ShowDialog() == DialogResult.OK) 
                {
                    try
                    {
                        List<Produs> produseImportate = new List<Produs>();

                        using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] parts = line.Split(';');

                                if (parts.Length == 4)
                                {
                                    int cod = int.Parse(parts[0]);
                                    string denumire = parts[1];
                                    decimal pret = decimal.Parse(parts[2]);
                                    int cantitate = int.Parse(parts[3]);

                                    produseImportate.Add(new Produs(cod, denumire, pret, cantitate));
                                }
                            }
                        }

                        Program.cos.produse.Clear();
                        foreach (var p in produseImportate)
                        {
                            Program.cos.AdaugaProdus(p);
                        }

                        MessageBox.Show("Cosul a fost importat cu succes!");
                        panelGrafic.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la importul cosului: {ex.Message}\nAsigura-te că fisierul are formatul corect.", "Eroare import", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void exportaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Fisiere text (*.txt)|*.txt|Toate fisierele (*.*)|*.*";
                openFileDialog.Title = "Importa cosul de cumparaturi";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        List<Produs> produseImportate = new List<Produs>();

                        using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] parts = line.Split(';');

                                if (parts.Length == 4)
                                {
                                    int cod = int.Parse(parts[0]);
                                    string denumire = parts[1];
                                    decimal pret = decimal.Parse(parts[2]);
                                    int cantitate = int.Parse(parts[3]);

                                    produseImportate.Add(new Produs(cod, denumire, pret, cantitate));
                                }
                            }
                        }

                        Program.cos.produse.Clear();
                        foreach (var p in produseImportate)
                        {
                            Program.cos.AdaugaProdus(p);
                        }

                        MessageBox.Show("Cosul a fost importat cu succes!");
                        panelGrafic.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Eroare la importul cosului: {ex.Message}\nAsigura-te ca fisierul are formatul corect.", "Eroare import", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }
        }
    }
    }
}
