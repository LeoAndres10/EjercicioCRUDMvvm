
using SQLite;

namespace EjercicioCRUDMvvm.Model
{
    public class Proveedor
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nombre { get; set; }
        [NotNull]
        public string Producto { get; set; }

        [NotNull] 
        public string Marca { get; set; }

        [NotNull]
        public string Descripcion { get; set; }

        [NotNull]
        public double Precio { get; set; }

    }
}
