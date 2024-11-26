namespace ConsoleApp2;

public class Encoder
{
    public void Encode1(string data, string sender, string receiver, ISaver exportType)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*? ";
        int sendercode = 0;
        int receivercode = 0;
        for (int j = 0; j < alphabet.Length; j++)
        {
            foreach (char i in sender)
            {
                if (i == alphabet[j])
                {
                    sendercode += j;
                }
            }

            foreach (char i in receiver)
            {
                if (i == alphabet[j])
                {
                    receivercode += j;
                }
            }
        }

        int changenumber = (sendercode + receivercode);
        string encodedData = "";
        foreach (char c in data)
        {
            int i = 0;
            for (i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    break;
                }
            }

            encodedData += alphabet[(i + changenumber) % alphabet.Length];
        }


        exportType.SaveData(encodedData,
            @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Encoded1Data");
    }

    public void Encode2(string data, string sender, string receiver, ISaver exportType)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*? ";
        int sendercode = 0;
        int receivercode = 0;
        for (int j = 0; j < alphabet.Length; j++)
        {
            foreach (char i in sender)
            {
                if (i == alphabet[j])
                {
                    sendercode += j;
                }
            }

            foreach (char i in receiver)
            {
                if (i == alphabet[j])
                {
                    receivercode += j;
                }
            }
        }

        int changenumber =
            (sendercode * receivercode) / (sendercode + receivercode); // adadi ke bahash ramzgozari mikhonim
        string encodedData = "";
        foreach (char c in data)
        {
            int i = 0;
            for (i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    break;
                }
            }

            encodedData += alphabet[(i + changenumber) % alphabet.Length];
        }


        exportType.SaveData(encodedData,
            @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Encoded2Data");
    }
}