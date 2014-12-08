using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman();
            Console.ReadKey();
        }
        static void Hangman()
        {
            //declare the variables that we need to keep track of
            int numberOfGuesses = 7;
            List<string> wordBank = new List<string>() { "carrot", "nickleback" };
            Random rng = new Random();
            string wordToGuess = wordBank[rng.Next(0, wordBank.Count())];
            string lettersGuessed = string.Empty;
            bool playing = true;
            //this is the loop that drives the game
            while(playing)
            {
                DisplayRoundInfo(lettersGuessed,wordToGuess,numberOfGuesses);
                string input = GetUserInput(lettersGuessed);
                if(input.Length==1)
                {
                    lettersGuessed += input;
                    if(wordToGuess.ToLower().Contains(input))
                    {
                        Console.WriteLine("correct guess");
                        if(!GetMaskedWord(lettersGuessed,wordToGuess).Contains('_'))
                        {
                            playing = false;
                        }
                    }
                    else
                    {
                        numberOfGuesses--;
                        playing = (numberOfGuesses > 0);
                    }
                }
                else
                {
                    if(input.ToLower()==wordToGuess.ToLower())
                    {
                        playing = false;
                    }
                    else
                    {
                        Console.WriteLine("The word you guessed was wrong");
                        numberOfGuesses--;
                        playing = (numberOfGuesses > 0);
                    }
                }


            }
            if (numberOfGuesses > 0)
            {
                Console.WriteLine("way to go");
            }
            else
            {
                Console.WriteLine("you blow...at this game");
            }


        }
        static void DisplayRoundInfo(string lettersGuessed,string wordToGuess,int numberOfGuesses)
        {
            //before any output we need to clear the screen
            Console.Clear();
            Console.WriteLine(GetMaskedWord(lettersGuessed, wordToGuess));
            Console.WriteLine("# of guesses left: " + numberOfGuesses);
            Console.WriteLine("Letters Guessed: " + lettersGuessed);
            Console.WriteLine("Your Guess: ");

        }
        static string GetMaskedWord(string lettersGuessed, string wordToGuess)
        {
            string returnString = string.Empty;
            for(int i=0;i<wordToGuess.Length;i++)
            {
                
                string currentLetter = wordToGuess[i].ToString().ToLower();
                if(lettersGuessed.ToLower().Contains(currentLetter))
                {
                    returnString += currentLetter + " ";

                }
                else
                {
                    returnString += "_ ";
                }

            }
            return returnString;
        }
        static string GetUserInput(string lettersGuessed)
        {
            string returnString;
            bool IsValid= true;
            do
            {
                Console.WriteLine("Enter a guess");
                
                returnString = Console.ReadLine();
                if (returnString.Length == 0)
                {
                    Console.WriteLine("You need to enter something.");
                    
                    IsValid = false;
                }
                else if (returnString.Length == 1)
                {
                    Console.WriteLine("Guess a letter you havent yet.");
                    

                    IsValid = char.IsLetter(returnString[0]);
                    if (IsValid)
                    {
                        IsValid = !lettersGuessed.ToLower().Contains(returnString.ToLower());
                    }

                }

            }
            while (IsValid == false);
            {
                return returnString;
            }
        }
    }
}
