using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
[EnableCors("DevelopmentCors")]
[ApiController]
[Route("api/[controller]")]
public class CarritoCompraController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public CarritoCompraController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    //Muestra la lista de todos los usuarios registrados

    [HttpGet]
    [Route("GetAllCarritoCompra")]
    public IActionResult GetAllCarritoCompra()
    {
        try
        {
            var result = CarritoCompraServicios.ObtenerTodo<CarritoCompra>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //insertando los Id muestra el usuario en una tabla con sus registros

    [HttpGet]
    [Route("GetCarritoCompraById")]
    public IActionResult GetCarritoCompraById([FromQuery] int id)
    {
        try
        {
            var result = CarritoCompraServicios.ObtenerById<CarritoCompra>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    //para Adicionar Registro Usuarios en la base de datos

    [HttpPost]
    [Route("AddCarritoCompra")]
    public IActionResult AddCarritoCompra(CarritoCompra carritoCompra)
    {
        try
        {
            var result = CarritoCompraServicios.InsertCarritoCompra(carritoCompra);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut]
    [Route("UpdateCarritoCompra")]
    public IActionResult UpdateCarritoCompra(CarritoCompra carritoCompra)
    {
        try
        {
            var result = CarritoCompraServicios.UpdateCarritoCompra(carritoCompra);
            return Ok(result);
        }
        catch (Exception err)
        {
            return StatusCode(500, err.Message);
        }
    }


    [HttpDelete]
    [Route("DeleteCarritoCompra")]
    public IActionResult DeleteCarritoCompra([FromQuery] int id)
    {
        try
        {
            var result = CarritoCompraServicios.DeleteCarritoCompra(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}