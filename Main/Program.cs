using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionMethods;

namespace Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                               'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' '};


            char[] key = { 'A', 'B', 'C' };

            string enterString = "ONE TWO";
            VigenereCipher cipher = new VigenereCipher(alphabet, 1);

            cipher.PrintKeyCard();

            Console.WriteLine($"Enter string: {enterString}");

            string exitString = cipher.Encryption(enterString, key);

            Console.WriteLine($"Exit string: {exitString}");

            enterString = null;

            enterString = cipher.Dencryption(exitString, key);

            Console.WriteLine($"Enter string: {enterString}");

            Console.ReadLine();
        }
    }
}
