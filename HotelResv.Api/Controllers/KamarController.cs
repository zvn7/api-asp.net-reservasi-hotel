using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[ApiController]
[Route("api/[controller]")]
public class KamarController : ControllerBase
{
    private readonly DbManager _dbManager;
    Response response = new Response();

    public KamarController(IConfiguration configuration)
    {
        _dbManager = new DbManager(configuration);
    }

    [HttpGet]
    public IActionResult GetKamars()
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.GetAllKamars();
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("GetKamarById")]
    public IActionResult GetKamarById(int id)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.GetKamarById(id);
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPost]
    public IActionResult CreateKamar([FromBody] Kamar kamar)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.CreateKamar(kamar);
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateKamar(int id, [FromBody] Kamar kamar)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.UpdateKamar(id, kamar);
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = "Error";
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteKamar(int id)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.DeleteKamar(id);
        }
        catch (System.Exception)
        {
            response.Status = 500;
            response.Message = "Error";
        }
        return Ok(response);
    }
}