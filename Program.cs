using System.ComponentModel;

namespace Shopping_cart
{
    static class Program
    {
        public static CosCumparaturi cos = new CosCumparaturi();
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            Database.InitializeDatabase();
            cos.AdaugaProdus(new Produs(1, "Laptop", 3000m, 1));
            Program.cos.produse = new BindingList<Produs>(Database.LoadProduse());
      
            Application.Run(new Cos());
        }
    }
}