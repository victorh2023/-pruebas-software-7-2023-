using Microsoft.AspNetCore.Mvc;
using backend.connection;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaProductoController : ControllerBase
{
   private readonly IConfiguration _configuration;
   private readonly string connectionString;

   public CategoriaProductoController(IConfiguration configuration)
   {
    _configuration = configuration;
    connectionString = _configuration[""];
    BDManager.GetInstance.ConnectionString = connectionString; 
   }

   [HttpGet]
    public IActionResult Get()
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

}
