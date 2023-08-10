mamespace backend.entidades
{
    plublic class Detalle_Carrito : Common
    {
        public int Id { get; set; }
        public string Cantidad { get; set; }
        public string Id_Producto { get; set; }
        public string Id_Carrito_Compra { get; set; }

    }
}