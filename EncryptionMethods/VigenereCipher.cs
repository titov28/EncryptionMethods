using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionMethods
{
    public class VigenereCipher
    {

        char[,] keyCard;


        public VigenereCipher(char[] alphabet, int offset)
        {
            InitKeyCard(alphabet, offset);
        }

        private void InitKeyCard(char[] alphabet, int offset)
        {
            int lenghtAlphabet = alphabet.Length;
            keyCard = new char[lenghtAlphabet, lenghtAlphabet];


            int count = 0;

            for(int i = 0; i < lenghtAlphabet; i++)
            {
                for(int j = 0; j < lenghtAlphabet; j++)
                {
                    if(count > lenghtAlphabet - 1)
                    {
                        count = count - (lenghtAlphabet - 1) - 1;
                    }

                    keyCard[i, j] = alphabet[count];
                    count++;
                }

                count += offset;
            }

        }


        public void PrintKeyCard()
        {
            int lenght = keyCard.GetUpperBound(0) + 1;

            Console.WriteLine();
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    Console.Write($"{keyCard[i, j]} ");
                }
                Console.Write("\n");
            }
        }

        public string Encryption(string enterString, char[] key)
        {
            char[] enterStringCharArray = enterString.ToCharArray();
            char[] exitStringCharArray = new char[enterStringCharArray.Length];

            for(int i = 0, j = 0; i < enterStringCharArray.Length; i++, j++)
            {
                if(j == key.Length)
                {
                    j = 0;
                }

                exitStringCharArray[i] = GetEncriptionElement(enterStringCharArray[i], key[j]);
            }

            return new string(exitStringCharArray);
        }

        public string Dencryption(string enterString, char[] key)
        {
            char[] enterStringCharArray = enterString.ToCharArray();
            char[] exitStringCharArray = new char[enterStringCharArray.Length];

            for (int i = 0, j = 0; i < enterStringCharArray.Length; i++, j++)
            {
                if (j == key.Length)
                {
                    j = 0;
                }

                exitStringCharArray[i] = GetDencriptionElement(enterStringCharArray[i], key[j]);
            }

            return new string(exitStringCharArray);
        }


        private char GetEncriptionElement(char enterStringElem, char keyElem)
        {
            int indexEnterStringElem = -1;
            int indexKeyElem = -1;

            for (int i = 0; i < keyCard.GetUpperBound(0) + 1; i++)
            {
                if(indexEnterStringElem != -1 && indexKeyElem != -1)
                {
                    break;
                }

                if (enterStringElem == keyCard[0, i])
                {
                    indexEnterStringElem = i;
                }

                if(keyElem == keyCard[0, i])
                {
                    indexKeyElem = i;
                }
            }


            return keyCard[indexEnterStringElem, indexKeyElem];
        }

        private char GetDencriptionElement(char enterStringElem, char keyElem)
        {
            int indexEnterStringElem = -1;
            int indexKeyElem = -1;

            for(int i = 0; i < keyCard.GetUpperBound(0) + 1; i++)
            {
                if (keyElem == keyCard[0, i])
                {
                    indexKeyElem = i;
                    break;
                }
            }

            for (int i = 0; i < keyCard.GetUpperBound(0) + 1; i++)
            {
                if (enterStringElem == keyCard[i, indexKeyElem])
                {
                    indexEnterStringElem = i;
                    break;
                }
            }

            return keyCard[0, indexEnterStringElem];

        }
    }
}
