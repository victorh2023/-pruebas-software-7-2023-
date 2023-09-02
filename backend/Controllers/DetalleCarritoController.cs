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
public class DetalleCarritoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    /// <summary>
    /// hola
    /// </summary>
    public DetalleCarritoController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    //Muestra la lista de todos los usuruarios registrados
    /// <summary>
    /// hola
    /// </summary>
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
    /// <summary>
    /// hola
    /// </summary>
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
    /// <summary>
    /// hola
    /// </summary>
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
    /// <summary>
    /// hola
    /// </summary>
    [HttpPut]
    [Route("UpdateDetalleCarrito")]
    public IActionResult UpdateDetalleCarrito(DetalleCarrito detalleCarrito)
    {
        try
        {
            var result = DetalleCarritoServicios.UpdateDetalleCarrito(detalleCarrito);
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
    [Route("DeleteDetalleCarrito")]
    public IActionResult DeleteDetalleCarrito([FromQuery] int id)
    {
        try
        {
            var result = DetalleCarritoServicios.DeleteDetalleCarrito(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}