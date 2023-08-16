namespace backend.entidades
{
    public class DetalleCarrito : Common
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public int IdProducto { get; set; }

        public int IdCarritoCompra { get; set; }

        public static implicit operator DetalleCarrito(DetalleCarrito v)
        {
            throw new NotImplementedException();
        }
    }
}