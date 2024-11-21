namespace ConsoleApp2;

public class Decoder
{
    public string decoder1(string sender, string receiver, string code)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&* ";
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

        int changenumber = (sendercode + receivercode) ; // adadi ke bahash ramzgozari mikhonim
        string decodeddata = "";
        foreach (char c in code)
        {
            int i = 0;
            for (i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    break;
                }
            }

            decodeddata += alphabet[(i - changenumber+ alphabet.Length) % alphabet.Length];
        }

        return decodeddata;
    }
    public string decoder2(string sender, string receiver, string code)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&* ";
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

        int changenumber = (sendercode * receivercode) / (sendercode + receivercode);
        string decodeddata = "";
        foreach (char c in code)
        {
            int i = 0;
            for (i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    break;
                }
            }

            decodeddata += alphabet[Math.Abs(i - changenumber+ alphabet.Length) % alphabet.Length];
        }

        return decodeddata;
    }
}
