using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class ProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select * from PRODUCTO";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from PRODUCTO where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertProducto(Producto producto)
        {
            const string sql = "INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES (@nombre, @id_categoria) ";

            var parameters = new DynamicParameters();
            parameters.Add("@nombre", producto.Nombre, DbType.String);
            parameters.Add("@id_categoria", producto.IdCategoria, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateProducto(Producto producto)
        {
            const string sql = "UPDATE [PRODUCTO] SET [NOMBRE] = @nombre where [ID_CATEGORIA] = @id_categoria ";
            var parameters = new DynamicParameters();
            
            parameters.Add("nombre", producto.Nombre, DbType.String);
            parameters.Add("id_categoria", producto.IdCategoria, DbType.Int64);
            
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }  

        public static int DeleteProducto(int id)
        {
            const string sql = "DELETE FROM PRODUCTO where ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        } 

    }
}