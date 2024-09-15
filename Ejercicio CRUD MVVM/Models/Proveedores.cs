using SQLite;

namespace Ejercicio_CRUD_MVVM.Models
{
    public class Proveedores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Email {  get; set; }

    }
}
