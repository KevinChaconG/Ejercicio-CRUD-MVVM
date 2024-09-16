using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Ejercicio_CRUD_MVVM.Models;

namespace Ejercicio_CRUD_MVVM.Services
{
    public class ProveedoresService
    {
        private readonly SQLiteConnection dbConnection;

        public ProveedoresService()
        {

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedores.db3");

            dbConnection = new SQLiteConnection(dbPath);

            dbConnection.CreateTable<Proveedores>();

        }

        public List<Proveedores> GetAll()
        {
            var res = dbConnection.Table<Proveedores>().ToList();
            return res;
        }

        public int Insert(Proveedores proveedores)
        {
            return dbConnection.Insert(proveedores);
        }

        public int Update(Proveedores proveedores)
        {
            return dbConnection.Update(proveedores);
        }

        public int Delete(Proveedores proveedores)
        {
            return dbConnection.Delete(proveedores);
        }

    }
}
