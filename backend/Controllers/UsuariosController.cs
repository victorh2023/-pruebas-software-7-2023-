using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[EnableCors("CorsDev")]
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

    //Muestra la lista de todos los usuruarios registrados

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

    //insertando los Id muestra el usuario en una tabla con sus registros

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

    //para Adicionar usuarios en la base de datos

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
