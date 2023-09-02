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
public class CategoriaProductoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;
    /// <summary>
    /// hola
    /// </summary>
    public CategoriaProductoController(IConfiguration configuration)
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
    [Route("GetAllCategoriaProducto")]
    public IActionResult GetAllCategoriaProducto()
    {
        try
        {
            var result = CategoriaProductoServicios.ObtenerTodo<CategoriaProducto>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //insertando los Id muestra el Categoria en una tabla con sus registros

    /// <summary>
    /// hola
    /// </summary>
    [HttpGet]
    [Route("GetCategoriaProductoById")]
    public IActionResult GetCategoriaProductoById([FromQuery] int id)
    {
        try
        {
            var result = CategoriaProductoServicios.ObtenerById<CategoriaProducto>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //para Adicionar Registro de Categoria en la base de datos
    /// <summary>
    /// hola
    /// </summary>
    [HttpPost]
    [Route("AddCategoriaProducto")]
    public IActionResult AddCategoriaProducto(CategoriaProducto categoriaProducto)
    {
        try
        {
            var result = CategoriaProductoServicios.InsertCategoriaProducto(categoriaProducto);
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
    [Route("UpdateCategoriaProducto")]
    public IActionResult UpdateCategoriaProducto(CategoriaProducto categoriaProducto)
    {
        try
        {
            var result = CategoriaProductoServicios.UpdateCategoriaProducto(categoriaProducto);
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
    [Route("DeleteCategoriaProducto")]
    public IActionResult DeleteCategoriaProducto([FromQuery] int id)
    {
        try
        {
            var result = CategoriaProductoServicios.DeleteCategoriaProducto(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}