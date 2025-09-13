using GeoMasterAPI.DTOs;
using GeoMasterAPI.Models;

namespace GeoMasterAPI.Services;

public class CalculadoraService : ICalculadoraService
{
    public ResultadoDto CalcularArea(FormaRequest req)
    {
        (string tipo, var p) = Normalizar(req);

        return tipo switch
        {
            "circulo" => new ResultadoDto(new Circulo { Raio = Get(p, "raio") }.CalcularArea(), "u�"),
            "retangulo" => new ResultadoDto(new Retangulo { Largura = Get(p, "largura"), Altura = Get(p, "altura") }.CalcularArea(), "u�"),
            _ => throw new ArgumentException("Forma n�o suportada para �rea.")
        };
    }

    public ResultadoDto CalcularPerimetro(FormaRequest req)
    {
        (string tipo, var p) = Normalizar(req);

        return tipo switch
        {
            "circulo" => new ResultadoDto(new Circulo { Raio = Get(p, "raio") }.CalcularPerimetro(), "u"),
            "retangulo" => new ResultadoDto(new Retangulo { Largura = Get(p, "largura"), Altura = Get(p, "altura") }.CalcularPerimetro(), "u"),
            _ => throw new ArgumentException("Forma n�o suportada para per�metro.")
        };
    }

    public ResultadoDto CalcularVolume(FormaRequest req)
    {
        (string tipo, var p) = Normalizar(req);

        return tipo switch
        {
            "esfera" => new ResultadoDto(new Esfera { Raio = Get(p, "raio") }.CalcularVolume(), "u�"),
            _ => throw new ArgumentException("Forma n�o suportada para volume.")
        };
    }

    public ResultadoDto CalcularAreaSuperficial(FormaRequest req)
    {
        (string tipo, var p) = Normalizar(req);

        return tipo switch
        {
            "esfera" => new ResultadoDto(new Esfera { Raio = Get(p, "raio") }.CalcularAreaSuperficial(), "u�"),
            _ => throw new ArgumentException("Forma n�o suportada para �rea superficial.")
        };
    }

    public bool ValidarFormaContida(FormasDuplasRequest req)
    {
        (string tipoOut, var po) = Normalizar(req.Externa);
        (string tipoIn, var pi) = Normalizar(req.Interna);

        if (tipoOut == "retangulo" && tipoIn == "circulo")
        {
            var outRect = new Retangulo { Largura = Get(po, "largura"), Altura = Get(po, "altura") };
            var inCirc = new Circulo { Raio = Get(pi, "raio") };
            var diametro = 2 * inCirc.Raio;
            return diametro <= Math.Min(outRect.Largura, outRect.Altura);
        }

        if (tipoOut == "circulo" && tipoIn == "retangulo")
        {
            var outCirc = new Circulo { Raio = Get(po, "raio") };
            var inRect = new Retangulo { Largura = Get(pi, "largura"), Altura = Get(pi, "altura") };
            var diagonal = Math.Sqrt(Math.Pow(inRect.Largura, 2) + Math.Pow(inRect.Altura, 2));
            var diametro = 2 * outCirc.Raio;
            return diagonal <= diametro;
        }

        if (tipoOut == "circulo" && tipoIn == "circulo")
            return Get(pi, "raio") <= Get(po, "raio");

        if (tipoOut == "retangulo" && tipoIn == "retangulo")
            return Get(pi, "largura") <= Get(po, "largura") && Get(pi, "altura") <= Get(po, "altura");

        if (tipoOut == "esfera" && tipoIn == "esfera")
            return Get(pi, "raio") <= Get(po, "raio");

        throw new ArgumentException("Combina��o de formas n�o suportada para valida��o.");
    }

    private static (string, Dictionary<string, double>) Normalizar(FormaRequest req)
    {
        if (req is null) throw new ArgumentNullException(nameof(req));
        if (req.Propriedades is null || req.Propriedades.Count == 0)
            throw new ArgumentException("Propriedades s�o obrigat�rias.");

        var tipo = (req.TipoForma ?? string.Empty).Trim().ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(tipo))
            throw new ArgumentException("Tipo da forma � obrigat�rio.");

        return (tipo, req.Propriedades!);
    }

    private static double Get(Dictionary<string, double> p, string key)
    {
        if (!p.TryGetValue(key, out var val))
            throw new ArgumentException($"Propriedade '{key}' � obrigat�ria.");
        if (val <= 0)
            throw new ArgumentException($"Propriedade '{key}' deve ser maior que zero.");
        return val;
    }
}
