using backend.connection;
using backend.entidades;
using backend.servicios;

namespace backend_unit_test
{
    public class UnitTestUsuarios
    {   
        public UnitTestUsuarios() 
        {
            BDManager.GetInstance.ConnectionString = "workstation id=DBVictorhugocondorib.mssql.somee.com;packet size=4096;user id=victorhugo2023_SQLLogin_1;pwd=535xd3kqwg;data source=DBVictorhugocondorib.mssql.somee.com;persist security info=False;initial catalog=DBVictorhugocondorib"; 
        }  

        [Fact]
        public void Usuarios_Get_Verificar_NotNull()
        {
            var result = UsuariosServicios.ObtenerTodo<Usuarios>();
            Assert.NotNull(result);
        }

        [Fact]
        public void Usuarios_GetById_VerificarItem()
        {
            var result = UsuariosServicios.ObtenerById<Usuarios>(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void Usuarios_Insertar()
        {
            Usuarios usuarioTemp = new()
            {
                NombreCompleto = "Nombre Test",
                UserName = "UserName Test",
                Password = "password Test"
            };
            var result = UsuariosServicios.InsertUsuario(usuarioTemp);
            Assert.Equal(1, result); 
        }
    }
}