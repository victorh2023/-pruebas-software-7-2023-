using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class ReservarCitaServicios
    {

        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from reservar_cita where estado_registro = 1 order by id desc";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from reservar_cita where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertReservarCita(ReservarCita reservarCita)
        {
            const string sql = "INSERT INTO [dbo].[RESERVAR_CITA]([FECHA_CITA], [HORA_CITA], [MOTIVO_CONSULTA], [ID_USUARIOS], [ID_ODONTOLOGIA]) VALUES (@fecha_cita, @hora_cita, @motivo_consulta, @id_usuarios, @id_odontologia) ";

            var parameters = new DynamicParameters();
            parameters.Add("fecha_cita", reservarCita.FechaCita, DbType.Date);
            parameters.Add("hora_cita", reservarCita.HoraCita, DbType.Date);
            parameters.Add("motivo_consulta", reservarCita.MotivoConsulta, DbType.String);
            parameters.Add("id_usuarios", reservarCita.IdUsuarios, DbType.Int64);
            parameters.Add("id_odontologia", reservarCita.IdOdontologia, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateReservarCita(ReservarCita reservarCita)
        {
            const string sql = "UPDATE [RESERVAR_CITA] SET [FECHA_CITA] = @fecha_cita, [HORA_CITA] = @hora_cita, [MOTIVO_CONSULTA] = @motivo_consulta, [ID_USUARIOS] = @id_usuarios, [ID_ODONTOLOGIA] = @id_odontologia where [ID] = @id ";
            
            var parameters = new DynamicParameters();
            parameters.Add("fecha_cita", reservarCita.FechaCita, DbType.Date);
            parameters.Add("hora_cita", reservarCita.HoraCita, DbType.Date);
            parameters.Add("motivo_consulta", reservarCita.MotivoConsulta, DbType.String);
            parameters.Add("id_usuarios", reservarCita.IdUsuarios, DbType.Int64);
            parameters.Add("id_odontologia", reservarCita.IdOdontologia, DbType.Int64);
            parameters.Add("id", reservarCita.Id, DbType.Int64);
            
            
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }  

        public static int DeleteReservarCita(int id)
        {
            const string sql = "DELETE FROM RESERVAR_CITA where ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }   
    }
}