namespace backend.entidades
{
    public class ReservarCita : Common
    {
        public int Id { get; set; }

        public DateTime FechaCita { get; set; }

        public DateTime HoraCita { get; set; }

        public string MotivoConsulta { get; set; }

        public int IdUsuarios { get; set; }

        public int IdOdontologia { get; set; }
    }
}