using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetalleCarritoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public DetalleCarritoController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    //Muestra la lista de todos los usuruarios registrados

    [HttpGet]
    [Route("GetAllDetalleCarrito")]
    public IActionResult GetAllDetalleCarrito()
    {
        try
        {
            var result = DetalleCarritoServicios.ObtenerTodo<DetalleCarrito>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //insertando los Id muestra el usuario en una tabla con sus registros

    [HttpGet]
    [Route("GetDetalleCarritoById")]
    public IActionResult GetDetalleCarritoById([FromQuery] int id)
    {
        try
        {
            var result = DetalleCarritoServicios.ObtenerById<DetalleCarrito>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //para Adicionar usuarios en la base de datos

    [HttpPost]
    [Route("AddDetalleCarrito")]
    public IActionResult AddDetalleCarrito(DetalleCarrito detalleCarrito)
    {
        try
        {
            var result = DetalleCarritoServicios.InsertDetalleCarrito(detalleCarrito);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}