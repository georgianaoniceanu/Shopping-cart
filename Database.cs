using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
namespace Shopping_cart { 
   public static class Database
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cos.db");
        private static string connectionString = $"Data Source={dbPath}";

        public static void InitializeDatabase()
        {
            bool dbNou = !File.Exists(dbPath);

            if (dbNou)
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(
                    @"CREATE TABLE IF NOT EXISTS Produse (
                        Cod INTEGER PRIMARY KEY,
                        Denumire TEXT,
                        Pret REAL,
                        Cantitate INTEGER
                    )", conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static void SaveProduse(List<Produs> produse)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var deleteCmd = new SQLiteCommand("DELETE FROM Produse", conn);
                deleteCmd.ExecuteNonQuery();

                foreach (var produs in produse)
                {
                    var cmd = new SQLiteCommand(
                        "INSERT INTO Produse (Cod, Denumire, Pret, Cantitate) VALUES (@c, @d, @p, @q)", conn);
                    cmd.Parameters.AddWithValue("@c", produs.Cod);
                    cmd.Parameters.AddWithValue("@d", produs.Denumire);
                    cmd.Parameters.AddWithValue("@p", produs.Pret);
                    cmd.Parameters.AddWithValue("@q", produs.Cantitate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Produs> LoadProduse()
        {
            var lista = new List<Produs>();
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT Cod, Denumire, Pret, Cantitate FROM Produse", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int cod = reader.GetInt32(0);
                    string denumire = reader.GetString(1);
                    decimal pret = reader.GetDecimal(2);
                    int cantitate = reader.GetInt32(3);
                    lista.Add(new Produs(cod, denumire, pret, cantitate));
                }
            }
            return lista;
        }
    }
}
