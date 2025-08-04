using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_cart
{
    public partial class FormAdaugare : Form
    {
        private List<Produs> produseDisponibile = new List<Produs>()
        {
            new Produs(1, "Laptop", 3000m, 1),
            new Produs(2, "Mouse", 100m, 1),
            new Produs(3, "Tastatura", 200m, 1),
            new Produs(4, "Monitor", 1500m, 1)
        };

        public Produs prodSelectat { get; private set; }
        public FormAdaugare()
        {
            InitializeComponent();
            InitializeList();
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 100;
            numericUpDown1.Value = 1;
        }

        private void InitializeList()
        {
            listaProduse.View = View.Details;
            listaProduse.FullRowSelect = true;
            listaProduse.Columns.Add("Cod", 50);
            listaProduse.Columns.Add("Denumire", 100);
            listaProduse.Columns.Add("Pret", 100);
            foreach (var p in produseDisponibile)
            {
                var item = new ListViewItem(p.Cod.ToString());
                item.SubItems.Add(p.Denumire);
                item.SubItems.Add(p.Pret.ToString("0.00"));
                item.Tag = p;
                listaProduse.Items.Add(item);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormAdaugare_Load(object sender, EventArgs e)
        {

        }

        private void listaProduse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listaProduse.SelectedItems.Count > 0)
            {
                var item = listaProduse.SelectedItems[0];
                var produs = (Produs)item.Tag;
                prodSelectat = new Produs(produs.Cod,
                    produs.Denumire, produs.Pret, (int)numericUpDown1.Value);
                Close();
            }
            else MessageBox.Show("Selecteaza un produs din lista!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
