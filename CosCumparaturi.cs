using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Shopping_cart
{
    class CosCumparaturi
    {
        public BindingList<Produs> produse = new BindingList<Produs>();

        public int NumarProduse => produse.Count;

        public Produs this[int index] => produse[index];

        public decimal ValoreTotala => produse.Sum(p => p.Valoare);

        public event EventHandler<Produs> AdaugareProdus;
        public event EventHandler<Produs> StergereProdus;
        public event EventHandler<Produs> ModificareProdus;

        public void AdaugaProdus(Produs produs)
        {
            var produsExistent = produse.FirstOrDefault(p => p.Cod == produs.Cod);
            if (produsExistent != null)
            {
                produsExistent.Cantitate += produs.Cantitate;
                ModificareProdus?.Invoke(this, produsExistent);
            }

            else
            {
                produse.Add(produs);
                produs.PropertyChanged += Produs_PropertyChanged;
                AdaugareProdus?.Invoke(this, produs);
            }
        }

        public void StergeProdus(int cod)
        {
            var produs = produse.FirstOrDefault(p => p.Cod == cod);
            if (produs != null)
            {
                produse.Remove(produs);
                StergereProdus?.Invoke(this, produs);
            }
        }

        private void Produs_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is Produs produs) ModificareProdus?.Invoke(this, produs);
        }
    }
}
