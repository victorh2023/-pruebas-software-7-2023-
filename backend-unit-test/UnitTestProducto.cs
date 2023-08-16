using backend.connection;
using backend.entidades;
using backend.servicios;


namespace backend_unit_test
{
    public class UnitTestProducto
    {   
        public UnitTestProducto() 
        {
            BDManager.GetInstance.ConnectionString = "workstation id=DBVictorhugocondorib.mssql.somee.com;packet size=4096;user id=victorhugo2023_SQLLogin_1;pwd=535xd3kqwg;data source=DBVictorhugocondorib.mssql.somee.com;persist security info=False;initial catalog=DBVictorhugocondorib";
        }

        [Fact] 
        public void Producto_Get_Verificar_NotNull()
        {
            var result = ProductoServicios.ObtenerTodo<Producto>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Producto_GetById_VerificarItem()
        {
            var result = ProductoServicios.ObtenerById<Producto>(1);
            Assert.Equal(1, result.Id);
        }
    }
}
