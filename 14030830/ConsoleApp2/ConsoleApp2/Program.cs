using ConsoleApp2;

string myData="How You Doing?";
string sender="ali";
string receiver="ali";
Decoder decoder = new Decoder();
Encoder encoder=new Encoder();

#region  Example
encoder.Encode1(myData,sender,receiver,SaverFactory.GetFormat("csv"));
encoder.Encode1(myData,sender,receiver,SaverFactory.GetFormat("txt"));
encoder.Encode1(myData,sender,receiver,SaverFactory.GetFormat("ini"));
encoder.Encode2(myData,sender,receiver,SaverFactory.GetFormat("csv"));
encoder.Encode2(myData,sender,receiver,SaverFactory.GetFormat("txt"));
encoder.Encode2(myData,sender,receiver,SaverFactory.GetFormat("ini"));

using (StreamReader reader = new StreamReader(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Encoded1Data\CsvData.csv"))//example
{
    string line;
    string txt="";
    while ((line = reader.ReadLine()) != null)
    {
        txt += line;
    }
    Console.WriteLine( decoder.decoder1(sender,receiver,txt));
}
using (StreamReader reader = new StreamReader(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Encoded2Data\IniData.ini"))//example
{
    string line;
    string txt="";
    while ((line = reader.ReadLine()) != null)
    {
        txt += line;
    }
    Console.WriteLine( decoder.decoder2(sender,receiver,txt));
}
#endregion
