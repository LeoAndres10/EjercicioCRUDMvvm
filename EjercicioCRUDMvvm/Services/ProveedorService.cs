using EjercicioCRUDMvvm.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUDMvvm.Services
{
    public class ProveedorService
    {
        private readonly SQLiteConnection dbConnection;


        public ProveedorService()
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");

            dbConnection = new SQLiteConnection(ruta);

            dbConnection.CreateTable<Proveedor>();
        }

        public int Insert(Proveedor proveedor)
        {
            return dbConnection.Insert(proveedor);
        }


        public int Delete(Proveedor proveedor)
        {
            return dbConnection.Delete(proveedor);

        }


        public int Update(Proveedor proveedor)
        {
            return dbConnection.Update(proveedor);
        }

        public List<Proveedor> GetAll()
        {
            var get=  dbConnection.Table<Proveedor>().ToList();

            return get;
        }
    }
}