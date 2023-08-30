using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class CategoriaProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "select top 5 * from categoria_producto where estado_registro = 1 order by id desc";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "select * from categoria_producto where ID = @Id and estado_registro = 1";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            const string sql = "INSERT INTO [dbo].[CATEGORIA_PRODUCTO]([NOMBRE]) VALUES (@nombre) ";

            var parameters = new DynamicParameters();
            parameters.Add("nombre", categoriaProducto.Nombre, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UpdateCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            const string sql = "UPDATE [CATEGORIA_PRODUCTO] SET [NOMBRE] = @nombre where [ID] = @id ";
            var parameters = new DynamicParameters();
            
            parameters.Add("nombre", categoriaProducto.Nombre, DbType.String);
            parameters.Add("id", categoriaProducto.Id, DbType.Int64);
            
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }  

        public static int DeleteCategoriaProducto(int id)
        {
            const string sql = "DELETE FROM CATEGORIA_PRODUCTO where ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);
            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        } 
    }
}