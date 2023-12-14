namespace PrimerNet.Models
{
    public class Productos
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public double Cosoto { get; set; }
        public int Categoria { get; set; }
        public int SubCategorias { get; set;}
        public int idVendedor { get; set;}
        public float Calificacion { get; set; }
        public int Unidades { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set;}
    }
}
