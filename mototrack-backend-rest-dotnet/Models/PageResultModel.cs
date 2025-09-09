namespace mototrack_backend_rest_dotnet.Models;

public class PageResultModel<T>
{
    public required T Data { get; set; }
    public int Deslocamento { get; set; }
    public int RegistrosRetornados { get; set; }
    public int TotalRegistros { get; set; }
}
