using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[EnableCors("DevelopmentCors")]
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public UsuariosController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    //Muestra la lista de todos los usuarios registrados en la base de datos

    [HttpGet]
    [Route("GetAllUsuarios")]
    public IActionResult GetAllUsuarios()
    {
        try
        {
            var result = UsuariosServicios.ObtenerTodo<Usuarios>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //para mostrar un usuario, en una tabla con sus registros colocando el ID

    [HttpGet]
    [Route("GetUsuariosById")]
    public IActionResult GetUsuariosById([FromQuery] int id)
    {
        try
        {
            var result = UsuariosServicios.ObtenerById<Usuarios>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //para insertar un nuevo usuarios en la base de datos

    [HttpPost]
    [Route("AddUsuario")]
    public IActionResult AddUsuario(Usuarios usuarios)
    {
        try
        {
            var result = UsuariosServicios.InsertUsuario(usuarios);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //para Actualizar un registro de un usuario en la base de datos


    [HttpPut]
    [Route("UpdateUsuario")]
    public IActionResult UpdateUsuario(Usuarios usuarios)
    {
        try
        {
            var result = UsuariosServicios.UpdateUsuario(usuarios);
            return Ok(result);
        }
        catch (Exception err)
        {
            return StatusCode(500, err.Message);
        }
    }

    //para Eliminar un registro de un Usuario en la base de datos, con llamar un Id

    [HttpDelete]
    [Route("DeleteUsuario")]
    public IActionResult DeleteUsuario([FromQuery] int id)
    {
        try
        {
            var result = UsuariosServicios.DeleteUsuario(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
