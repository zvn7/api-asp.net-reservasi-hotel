using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

[ApiController]
[Route("api/[controller]")]
public class ReservasiController : ControllerBase
{
    private readonly DbManager _dbManager;
    Response response = new Response();

    public ReservasiController(IConfiguration configuration)
    {
        _dbManager = new DbManager(configuration);
    }

    [HttpGet]
    public IActionResult GetAllReservasis()
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.GetAllReservasis();
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("GetReservasiById")]
    public IActionResult GetReservasiById(int id)
    {
        try
        {
            response.Status = 200;
            response.Message = "Success";
            response.Data = _dbManager.GetReservasiById(id);
        }
        catch (Exception ex)
        {
            response.Status = 500;
            response.Message = ex.Message;
        }
        return Ok(response);
    }
}
