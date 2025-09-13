using GeoMasterAPI.DTOs;

namespace GeoMasterAPI.Services;

public interface ICalculadoraService
{
    ResultadoDto CalcularArea(FormaRequest request);
    ResultadoDto CalcularPerimetro(FormaRequest request);
    ResultadoDto CalcularVolume(FormaRequest request);
    ResultadoDto CalcularAreaSuperficial(FormaRequest request);

    bool ValidarFormaContida(FormasDuplasRequest request);
}
