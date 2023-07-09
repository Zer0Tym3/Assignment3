using System.Text;

class FeistelCipher
{
    public static Encoding ascii = Encoding.ASCII;
    static void Main(String[] args)
    {

    }
    private static int randomKey(int keyLength)
    {
        return 0;
    }
    private static List<String> strToBin (string input)
    {
        List<char> tempC = new List<char>(input.ToCharArray());
        List<Byte> tempB = new List<Byte>(ascii.GetBytes(tempC.ToArray()));
        List<string> binOut = new List<string>(tempB.ToArray().Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray());
        return binOut;
    
    }
}