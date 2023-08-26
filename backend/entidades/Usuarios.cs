namespace backend.entidades
{
    public class Usuarios : Common
    {
        public int Id { get; set; }
        public string nombreCompleto { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}