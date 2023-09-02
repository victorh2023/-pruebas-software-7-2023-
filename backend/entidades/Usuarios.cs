namespace backend.entidades
{
    /// <summary>
    /// usuario
    /// </summary>
    public class Usuarios : Common
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}