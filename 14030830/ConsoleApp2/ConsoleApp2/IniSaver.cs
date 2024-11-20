using System.Text;

namespace ConsoleApp2;

public class IniSaver : ISaver
{
    public void SaveData(string data, string dir)
    {
        string path = dir + @"\IniData.ini";
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