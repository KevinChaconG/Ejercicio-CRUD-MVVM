using SQLite;

namespace Ejercicio_CRUD_MVVM.Models
{
    public class Proveedores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nombre { get; set; }

        [NotNull]
        public string Direccion { get; set; }

        [NotNull]
        public string Telefono { get; set; }

        [NotNull]
        public string Email {  get; set; }

    }
}
