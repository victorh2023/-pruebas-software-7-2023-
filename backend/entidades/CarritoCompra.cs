namespace backend.entidades
{
    public class CarritoCompra : Common
    {
            /// <summary>
            /// ID
            /// </summary>
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int IdUsuarios { get; set; }
    }
}