
namespace ConsoleApp2;

public static class SaverFactory
{
    public static ISaver GetFormat(string format)
    {
        return format.ToLower() switch
        {
            "txt" => new TxtSaver(),
            "csv" => new CsvSaver(),
            "ini" => new IniSaver(),
            _ => throw new Exception($"Unsupported format")
        };
    }
}