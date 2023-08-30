using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class OdontologiaServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from Odontologia where estado_registro = 1 order by id desc";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from odontologia where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertOdontologia(Odontologia odontologia)
        {
            const string sql = "INSERT INTO [dbo].[ODONTOLOGIA]([NOMBRE_COMPLETO], [DIRECCION], [TELEFONO], [ESPECIALIDAD]) VALUES (@nombre_completo, @direccion, @telefono, @especialidad) ";

            var parameters = new DynamicParameters();
            parameters.Add("nombre_completo", odontologia.NombreCompleto, DbType.String);
            parameters.Add("direccion", odontologia.Direccion, DbType.String);
            parameters.Add("telefono", odontologia.Telefono, DbType.String);
            parameters.Add("especialidad", odontologia.Especialidad, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

          public static int UpdateOdontologia(Odontologia odontologia)
        {
            const string sql = "UPDATE [ODONTOLOGIA] SET [NOMBRE_COMPLETO] = @nombre_completo, [DIRECCION] = @direccion, [TELEFONO] = @telefono, [ESPECIALIDAD] = @especialidad where [ID] = @id ";
            var parameters = new DynamicParameters();
          
            parameters.Add("nombre_completo", odontologia.NombreCompleto, DbType.String);
            parameters.Add("direccion", odontologia.Direccion, DbType.String);
            parameters.Add("telefono", odontologia.Telefono, DbType.String);
            parameters.Add("especialidad", odontologia.Especialidad, DbType.String);
            parameters.Add("id", odontologia.Id, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }  

        public static int DeleteOdontologia(int id)
        {
            const string sql = "DELETE FROM ODONTOLOGIA where ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        } 
    }
}