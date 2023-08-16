namespace backend.entidades
{
    public class CarritoCompra : Common
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int IdUsuarios { get; set; }

        public static implicit operator CarritoCompra(CarritoCompra v)
        {
            throw new NotImplementedException();
        }
    }
}