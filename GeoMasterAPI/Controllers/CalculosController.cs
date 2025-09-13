using GeoMasterAPI.DTOs;
using GeoMasterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoMasterAPI.Controllers;

[ApiController]
[Route("api/v1/calculos")]
public class CalculosController : ControllerBase
{
    private readonly ICalculadoraService _service;

    public CalculosController(ICalculadoraService service)
    {
        _service = service;
    }

    [HttpPost("area")]
    [ProducesResponseType(typeof(ResultadoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public IActionResult CalcularArea([FromBody] FormaRequest request)
    {
        try { return Ok(_service.CalcularArea(request)); }
        catch (ArgumentException ex) { return BadRequest(new ProblemDetails { Title = "Entrada inválida", Detail = ex.Message, Status = 400 }); }
    }

    [HttpPost("perimetro")]
    [ProducesResponseType(typeof(ResultadoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public IActionResult CalcularPerimetro([FromBody] FormaRequest request)
    {
        try { return Ok(_service.CalcularPerimetro(request)); }
        catch (ArgumentException ex) { return BadRequest(new ProblemDetails { Title = "Entrada inválida", Detail = ex.Message, Status = 400 }); }
    }

    [HttpPost("volume")]
    [ProducesResponseType(typeof(ResultadoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public IActionResult CalcularVolume([FromBody] FormaRequest request)
    {
        try { return Ok(_service.CalcularVolume(request)); }
        catch (ArgumentException ex) { return BadRequest(new ProblemDetails { Title = "Entrada inválida", Detail = ex.Message, Status = 400 }); }
    }

    [HttpPost("superficie")]
    [ProducesResponseType(typeof(ResultadoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public IActionResult CalcularAreaSuperficial([FromBody] FormaRequest request)
    {
        try { return Ok(_service.CalcularAreaSuperficial(request)); }
        catch (ArgumentException ex) { return BadRequest(new ProblemDetails { Title = "Entrada inválida", Detail = ex.Message, Status = 400 }); }
    }

    [HttpPost("validacoes/forma-contida")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public IActionResult ValidarFormaContida([FromBody] FormasDuplasRequest request)
    {
        try { return Ok(_service.ValidarFormaContida(request)); }
        catch (ArgumentException ex) { return BadRequest(new ProblemDetails { Title = "Entrada inválida", Detail = ex.Message, Status = 400 }); }
    }
}
