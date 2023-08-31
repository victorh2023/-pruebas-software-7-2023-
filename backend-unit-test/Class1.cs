using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestOdontologia
    {
        public UnitTestOdontologia()
        {
            BDManager.GetInstance.ConnectionString = "workstation id=DBVictorhugocondorib.mssql.somee.com;packet size=4096;user id=victorhugo2023_SQLLogin_1;pwd=535xd3kqwg;data source=DBVictorhugocondorib.mssql.somee.com;persist security info=False;initial catalog=DBVictorhugocondorib";
        }

        [Fact]
        public void Odontologia_Get_Verificar_NotNull()
        {
            var result = OdontologiaServicios.ObtenerTodo<Odontologia>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Odontologia_GetById_VerificarItem()
        {
            var result = OdontologiaServicios.ObtenerById<Odontologia>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Odontologia_Insertar()
        {
            Odontologia odontologiaTemp = new()
            {
                NombreCompleto = "Nombre Test",
                Direccion = "Direccion Test",
                Telefono = "Telefono Test",
                Especialidad = "Especialidad Test"
            };
            var result = OdontologiaServicios.InsertOdontologia(odontologiaTemp);
            Assert.Equal(1, result);
        }
    }
}
