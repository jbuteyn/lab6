using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Generator, please enter a word or sentence to be translated.");
            bool run = true;
            while (run == true)
            {
                string response = Console.ReadLine();
                while (response == "")
                {
                    Console.WriteLine("Please use your words!");

                    response = Console.ReadLine();

                }
                string[] sentence = response.Split(' ');

                for (int i = 0; i<sentence.Length; i++ )
                {
                    string word = sentence[i];
                    string responseLower = word.ToLower();
                    bool vowelcheck = false;
                    //Let's get the first character to check if it's a vowel or not
                    char first = responseLower[0];
                    //method that I wrote to check for the vowel and return a boolean value of true if it is
                    vowelcheck = Vowelmethod(first, vowelcheck);
                    if (vowelcheck == true)
                    {
                        sentence[i]=word + ("ay");

                    }

                    else
                    {

                        
                        sentence[i] = Consonant(word);

                    }
                    
                    
                }
                Console.WriteLine(string.Join(" ", sentence));
                Continue();
                Console.WriteLine("\n Please enter another sentence");
            }

            
        }
        public static bool Vowelmethod(char first, bool vowelcheck)
        {
            switch (first)
            {
                case 'a':
                    vowelcheck = true;
                    break;
                case 'e':
                    vowelcheck = true;
                    break;
                case 'i':
                    vowelcheck = true;
                    break;
                case 'o':
                    vowelcheck = true;
                    break;
                case 'u':
                    vowelcheck = true;
                    break;
                default:
                    vowelcheck = false;
                    break;
            }
            return vowelcheck;
        }

        public static string Consonant(string word)
        {

            int length = word.Length;
            bool consonantCheck = false;
            char[] responseArray = word.ToCharArray();
            char[] responseArrayTwo = new char[length];
            string superFinalResponse = "";
            for (int i = 0; consonantCheck == false; i++)
            {

                char test = responseArray[i];
                

                consonantCheck = Vowelmethod(test, consonantCheck);
                Array.Copy(responseArray, responseArrayTwo, i);
                int arrayLength = responseArray.Length;
                if (consonantCheck == true)
                {
                    String finalResponse = new String(responseArray, i, arrayLength - (i));
                    String addResponse = new String(responseArrayTwo, 0, i);

                    superFinalResponse = superFinalResponse+ (finalResponse + addResponse + "ay");


                }
                
            }


            return superFinalResponse;

        }

        public static Boolean Continue()
        {
            Console.WriteLine("\n Would you like to enter another word? (Y/N)");
            string input = Console.ReadLine();
            Boolean run = true;
            input.ToLower();

            if (input == "n")
            {
                Console.WriteLine("\nThanks for using this program!");
                run = false;
                Environment.Exit(0);


            }
            else if (input == "y")
            {
                run = true;
            }
            else
            {
                Console.WriteLine("\nI'm sorry, I didn't understand your input. Let's try that again!");
                run = Continue();
            }

            return run;
        }
    }
}

