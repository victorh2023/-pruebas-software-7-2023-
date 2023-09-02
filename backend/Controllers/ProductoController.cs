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
public class ProductoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;
    /// <summary>
/// hola
/// </summary>
    public ProductoController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }
    /// <summary>
    /// hola
    /// </summary>
    [HttpGet]
    [Route("GetAllProductos")]
    public IActionResult GetAllProductos()
    {
        try
        {
            var result = ProductoServicios.ObtenerTodo<Producto>();
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
    [HttpGet]
    [Route("GetProductoById")]
    public IActionResult GetProductoById([FromQuery] int id)
    {
        try
        {
            var result = ProductoServicios.ObtenerById<Producto>(id);
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
    [HttpPost]
    [Route("AddProducto")]
    public IActionResult AddProducto(Producto producto)
    {
        try
        {
            var result = ProductoServicios.InsertProducto(producto);
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
    [Route("UpdateProducto")]
    public IActionResult UpdateProducto(Producto producto)
    {
        try
        {
            var result = ProductoServicios.UpdateProducto(producto);
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
    [Route("DeleteProducto")]
    public IActionResult DeleteProducto([FromQuery] int id)
    {
        try
        {
            var result = ProductoServicios.DeleteProducto(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}