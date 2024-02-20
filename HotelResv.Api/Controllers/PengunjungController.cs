using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[ApiController]
[Route("api/[controller]")]
public class PengunjungController : ControllerBase
{
    private readonly DbManager _dbManager;
    Response response = new Response();

    public PengunjungController(IConfiguration configuration)
    {
        _dbManager = new DbManager(configuration);
    }

    [HttpGet]
    public IActionResult GetPengunjungs()
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.GetAllPengunjungs();
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("GetPengunjungById")]
    public IActionResult GetPengunjungById(int id)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.GetPengunjungById(id);
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPost]
    public IActionResult CreatePengunjung([FromBody] Pengunjung pengunjung)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.CreatePengunjung(pengunjung);
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = ex.Message;
        }
        return Ok(response);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePengunjung(int id, [FromBody] Pengunjung pengunjung)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.UpdatePengunjung(id, pengunjung);
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = "Error";
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePengunjung(int id)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.DeletePengunjung(id);
        }
        catch (System.Exception)
        {
            response.Status = 500;
            response.Message = "Error";
        }
        return Ok(response);
    }
}