using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class CarritoCompraServicios
    {

        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from carrito_compra where estado_registro = 1 order by id desc";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from carrito_compra where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertCarritoCompra(CarritoCompra carritoCompra)
        {
            const string sql = "INSERT INTO [dbo].[CARRITO_COMPRA]([FECHA], [ID_USUARIO]) VALUES (@fecha, @id_usuario) ";

            var parameters = new DynamicParameters();
            parameters.Add("fecha", carritoCompra.Fecha, DbType.Date);
            parameters.Add("id_usuario", carritoCompra.IdUsuarios, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateCarritoCompra(CarritoCompra carritoCompra)
        {
            const string sql = "UPDATE [CARRITO_COMPRA] SET [FECHA] = @fecha where [ID_USUARIO] = @id_usuario ";
            var parameters = new DynamicParameters();
            
            parameters.Add("fecha", carritoCompra.Fecha, DbType.String);
            parameters.Add("id_usuario", carritoCompra.IdUsuarios, DbType.Int64);
            
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }  

        public static int DeleteCarritoCompra(int id)
        {
            const string sql = "DELETE FROM CARRITO_COMPRA where ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }   
    }
}