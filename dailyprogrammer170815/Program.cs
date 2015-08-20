using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* 
Description:
A handful of words have their letters in alphabetical order, that is nowhere in the word do you change direction 
in the word if you were to scan along the English alphabet. An example is the word "almost", which has its letters in alphabetical order.
Your challenge today is to write a program that can determine if the letters in a word are in alphabetical order.
As a bonus, see if you can find words spelled in reverse alphebatical order.

*/
namespace dailyprogrammer170815
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load in some test words
            string[] inputs = { "billowy", "biosy", "chinos", "defaced", "chintz", "sponged", "bijoux", "abhors", "fiddle", "begins", "chimps", "wronged" };


            
            foreach (string word in inputs)
            {
                Console.WriteLine(isOrdered(word));
            }
            Console.ReadKey();
        }

        static string isOrdered(string word)
        {
            bool isOrdered = true;
            bool isReversed = true;

            //Convert string to char arry
            char[] wordCharArray = word.ToCharArray(0, word.Length);

            //Convert each char into its corresponding unicode int
            int[] asciiArray = new int[word.Length];
            int i = 0;
            foreach (char currentLetter in wordCharArray)
            {

                asciiArray[i] = (int)currentLetter;
                i++;
            }

            //Check if the currentCode is smaller or larger than the previous one
            int currentCode = asciiArray[0];
            foreach (int ascii in asciiArray)
            {
                if (ascii > currentCode)
                {
                    currentCode = ascii;
                    isReversed = false;
                    continue;
                }

                else if (ascii < currentCode)
                {
                    currentCode = ascii;
                    isOrdered = false;
                    continue;
                }
                
            }

            //Return if the word is ordered, reversed or not ordered.
            if(isOrdered == true)
            {
                return word + " IS ORDERED";
            }
            if (isReversed == true && isOrdered == false)
            {
                return word + " IS REVERSED";
            }
            else if(isOrdered == false)
            {
                return word + " IS NOT ORDERED";
            }

            return word;
        }
    }
}
