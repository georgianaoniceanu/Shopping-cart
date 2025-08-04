using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_cart
{
    public class Produs : INotifyPropertyChanged, IComparable<Produs>
    {
        private int codProdus;
        private string denumire;
        private decimal pret;
        private int cantitate;

        public int Cod
        {
            get => codProdus;
            set
            {
                if (codProdus != value)
                {
                    codProdus = value;
                    OnPropertyChanged(nameof(Cod));
                }
            }
        }

        public string Denumire
        {
            get => denumire;
            set
            {
                if (denumire != value)
                {
                    denumire = value;
                    OnPropertyChanged(nameof(Denumire));
                }
            }
        }

        public decimal Pret
        {
            get => pret;

            set {
                if (value != pret)
                {
                    pret = value;
                    OnPropertyChanged(nameof(Pret));
                }
            }
        }

        public int Cantitate
        {
            get => cantitate;

            set
            {
                if (value != cantitate)
                {
                    cantitate = value;
                    OnPropertyChanged(nameof(Cantitate));
                }
            }
        }

        public decimal Valoare => Pret*Cantitate; 

        public Produs(int codProdus, string denumire, decimal pret, int cantitate)
        {
            Cod = codProdus;
            Denumire = denumire;
            Pret = pret;
            Cantitate = cantitate;
         
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string numeProprietate)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(numeProprietate));
        }

        public int CompareTo(Produs other)
        {
            return string.Compare(this.Denumire, other.Denumire);
        }

        public override string ToString()
        {
            return $"{Denumire} (Cod {Cod} - {Cantitate} x {Pret} lei = {Valoare}";
        }
    }
}
