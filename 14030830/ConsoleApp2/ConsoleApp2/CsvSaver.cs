using System.Text;

namespace ConsoleApp2;

public class CsvSaver : ISaver
{
    public void SaveData(string data, string dir)
    {
        string path = dir + @"\CsvData.csv";
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(data);
            }
        }
    }
}