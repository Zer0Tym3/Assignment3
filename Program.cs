using System.Text;
using System.Text.Json;

/*
 * Zachary Morning
 * CS3626 - Assignment 3
 */


class FeistelCipher
{
    public static Encoding ascii = Encoding.ASCII;
    private static Random rand = new Random();
    static void Main(String[] args)
    {
        string input = "";
        string key = "";
        key = randomKey(4);
        Console.WriteLine("Zach's Feistel Cipher");
        Console.Write("Please Enter a String (Only first 2 letters will be encoded): ");
        input = Console.ReadLine();
        List<string> bInput = strToBin(input);
        Console.WriteLine("~~~\nPlaintext Input: " + input);
        Console.Write("Binary Input: [");
        foreach (string b in bInput)
        {
            Console.Write(b + ", ");
        }
        Console.WriteLine("]");
        List<string> cipherOut = new List<string>();
        foreach (string b in bInput)
        {
            string temp = FeistelCipherRound(b, key);
            cipherOut.Add(temp);
        }
        Console.WriteLine("Random Key: " + key + "\n~~~~\n");
        Console.Write("Ciphertext Output: [");
        foreach (string b in cipherOut)
        {
            Console.Write(b + ", ");
        }
        Console.WriteLine("]");
    }
    private static string randomKey(int keyLength)
    {
        string key = "";
        for (int i = 0; i < keyLength; i++)
        {
            int bit = rand.Next(2);
            key += bit.ToString();
        }
        return key;
    }
    private static string FeistelCipherRound(string input, string key)
    {
        //Step 2: Splitting of String
        string leftZ = input.Substring(0, 4);
        string rightZ = input.Substring(4, 4);
        //Step 3: Setting L1 = R0
        string leftO = rightZ;
        //Step 3: Converting Key to a Decimal to Use for Function
        int dKey = Convert.ToInt32(key, 2);
        //Step 3: Function= F(R0, k) = 2 * R0^k mod 2^4
        int fDecRes = (2 * Convert.ToInt32(rightZ, 2) ^ dKey) % Convert.ToInt32(Math.Pow(2, 4));
        //Step 3: Convert Decimal result to Binary to XOR with L0 (Also Keeping the proper Format)
        string fBinRes = Convert.ToString(fDecRes, 2).PadLeft(4, '0');
        //Step 3: XORing with L0
        string rightO = Convert.ToString(Convert.ToInt32(leftZ, 2) ^ Convert.ToInt32(fBinRes, 2), 2).PadLeft(4, '0');
        //Step 4: Concatinating R1 with L1
        string cipherT = rightO + leftO;
        return cipherT;
    }
    //From Assignment 1, Converting String to Binary
    private static List<String> strToBin (string input)
    {
        List<char> charL = new List<char>(input.ToCharArray());
        List<Byte> byteL = new List<Byte>(ascii.GetBytes(charL.ToArray()));
        List<string> binL = new List<string>(byteL.ToArray().Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray());
        return binL;
    }
}