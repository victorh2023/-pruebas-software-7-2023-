using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestReservarCita
    {
        public UnitTestReservarCita()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=DBVictorhugocondorib.mssql.somee.com;packet size=4096;user id=victorhugo2023_SQLLogin_1;pwd=535xd3kqwg;data source=DBVictorhugocondorib.mssql.somee.com;persist security info=False;initial catalog=DBVictorhugocondorib";
        }

        [Fact]
        public void ReservarCita_Get_Verificar_NotNull()
        {
            var result = ReservarCitaServicios.ObtenerTodo<ReservarCita>();
            Assert.NotNull(result);
        } 
    }
}
