using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaProductoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public CategoriaProductoController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    //Muestra la lista de todos los usuarios registrados

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
}