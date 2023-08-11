using backend.connection;

namespace backend.servicios
{
    public static class CategoriaProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>(){
            const string sql = "select * from categoria_producto";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }
    }
}