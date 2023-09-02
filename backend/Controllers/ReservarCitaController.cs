using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
/// <summary>
/// hola
/// </summary>
[EnableCors("DevelopmentCors")]
[ApiController]
[Route("api/[controller]")]
public class ReservarCitaController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;
    /// <summary>
/// hola
/// </summary>

    public ReservarCitaController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    //Muestra la lista de todos los usuarios registrados
    /// <summary>
/// hola
/// </summary>

    [HttpGet]
    [Route("GetAllReservarCita")]
    public IActionResult GetAllReservarCita()
    {
        try
        {
            var result = ReservarCitaServicios.ObtenerTodo<ReservarCita>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //insertando los Id muestra el usuario en una tabla con sus registros
    /// <summary>
/// hola
/// </summary>

    [HttpGet]
    [Route("GetReservarCitaById")]
    public IActionResult GetReservarCitaById([FromQuery] int id)
    {
        try
        {
            var result = ReservarCitaServicios.ObtenerById<ReservarCita>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //para Adicionar Registro Usuarios en la base de datos
    /// <summary>
/// hola
/// </summary>

    [HttpPost]
    [Route("AddReservarCita")]
    public IActionResult AddReservarCita(ReservarCita reservarCita)
    {
        try
        {
            var result = ReservarCitaServicios.InsertReservarCita(reservarCita);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    /// <summary>
/// hola
/// </summary>
    [HttpPut]
    [Route("UpdateReservarCita")]
    public IActionResult UpdateReservarCita(ReservarCita reservarCita)
    {
        try
        {
            var result = ReservarCitaServicios.UpdateReservarCita(reservarCita);
            return Ok(result);
        }
        catch (Exception err)
        {
            return StatusCode(500, err.Message);
        }
    }

    /// <summary>
/// hola
/// </summary>
    [HttpDelete]
    [Route("DeleteReservarCita")]
    public IActionResult DeleteReservarCita([FromQuery] int id)
    {
        try
        {
            var result = ReservarCitaServicios.DeleteReservarCita(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}