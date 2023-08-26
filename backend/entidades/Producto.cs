namespace backend.entidades
{
    public class Producto : Common
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public int IdCategoria { get; set; }
    }
}