class FeistelCipher
{
    static void Main(String[] args)
    {
        string input = "01111010";
        string key = "1101";
        string output = FeistelCipherRound(input, key);
        Console.WriteLine(output);

        Console.WriteLine("Zach's Feistel Cipher");
        Console.Write("Please Enter a String (Only first 2 letters will be encoded): ");
        input = Console.ReadLine();


    }
    private static int randomKey(int keyLength)
    {
        return 0;
    }
    private static string FeistelCipherRound(string input, string key)
    {
        //Step 1: Taking Input



        //Step 2: Splitting of String
        string leftZ = input.Substring(0, 4);
        string rightZ = input.Substring(4, 4);
        //Step 3: Setting L1 = R0
        string leftO = rightZ;
        //Step 3: Converting Key to a Decimal to Use for Function
        int dKey = Convert.ToInt32(key, 2);
            //Console.WriteLine("dKey = " + dKey);
        //Step 3: Function= F(R0, k) = 2 * R0^k mod 2^4
        int fDecRes = (2 * Convert.ToInt32(rightZ, 2) ^ dKey) % Convert.ToInt32(Math.Pow(2, 4));
            //Console.WriteLine("fDecRes = " + fDecRes);
        //Step 3: Convert Decimal result to Binary to XOR with L0 (Also Keeping the proper Format)
        string fBinRes = Convert.ToString(fDecRes, 2).PadLeft(4, '0');
            //Console.WriteLine("fBinRes = " + fBinRes);
        //Step 3: XORing with L0
        string rightO = Convert.ToString(Convert.ToInt32(leftZ, 2) ^ Convert.ToInt32(fBinRes, 2), 2).PadLeft(4, '0');
            //Console.WriteLine(rightO + " = " + leftZ + " XOR " + fBinRes);
        //Step 4: Concatinating R1 with L1
        string cipherT = rightO + leftO;

        return cipherT;
    }
}