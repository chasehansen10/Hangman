using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static string[] listOfWords = { "animal", "bear", "cattle", "deer", "elephant", "flamingo", "goat", "horse", "insect", "jaguar", "koala", "lizard", "mammoth", "nilgai", "octopus", "platypus", "quail", "rattlesnake", "scorpion", "toad", "urraca", "viper", "walrus", "xerus", "yak", "zebra" };
        static string theAlphabet = "abcdefghijklmnopqrstuvwxyz";
        static void Main(string[] args)
        {
            Random rng = new Random();
            PlayHangman(listOfWords[rng.Next(0, listOfWords.Count())]);
        }

        static void PlayHangman(string theWord)
        {
            //ask for user name
            //display instructions
            //

            bool playing = true;
            int numberOfGuesses = 7;

            //should these be a list?
            string lettersGuessed = "";
            string wrongLetters = "";

            string maskedWord = "";

            foreach (char thisChar in theWord)
            {
                maskedWord += "_";
            }


            Console.WriteLine("Welcome to hangman! We picked a random word for you to guess. Guess either a letter or the whole word at once.");
            Console.WriteLine("What's your name?");
            Console.WriteLine("I don't care. I just thought I'd ask.");
            Console.ReadLine();



            while (playing)
            {
                //display all the instructions and progress:
                PrintTheStuff(maskedWord, numberOfGuesses);

                //get the next guess
                string thisGuess = GetInput(lettersGuessed);

                //if it was a word guess:
                if (thisGuess.Length > 1)
                {
                    if (thisGuess == theWord)
                    {
                        //display "you win"
                        Console.WriteLine("You win!! This time...");
                        playing = false;
                    }
                    else
                    {
                        numberOfGuesses--;
                        if (numberOfGuesses == 0)
                        {
                            Console.WriteLine("You lost... You dummy.");
                            Console.ReadKey();
                            playing = false;
                        }
                        //display "that was wrong"
                    }
                }


                    //if it was a letter guess
                else
                {
                    lettersGuessed += thisGuess;


                    //good guess:
                    if (theWord.Contains(thisGuess))
                    {
                        //replace the underscore(s) with this character
                        maskedWord = String.Empty;
                        for (int i = 0; i < theWord.Length; i++)
                        {
                            if (lettersGuessed.Contains(theWord[i]))
                            {
                                maskedWord += theWord[i];
                            }
                            else
                            {
                                maskedWord += "_";
                            }
                        }

                        if (!maskedWord.Contains('_'))
                        {
                            playing = false;
                            Console.WriteLine("You win!! You still had {0} guesses left...You should be a pro hangman player.", numberOfGuesses);
                        }

                        Console.WriteLine("Good job!");
                    }

                    //bad guess
                    else
                    {
                        numberOfGuesses--;
                        wrongLetters += thisGuess;
                        if (numberOfGuesses == 0)
                        {
                            Console.WriteLine("You lost....You dummy.");
                            Console.ReadKey();
                            playing = false;
                        }
                    }
                }












            }
            //Print out whether you won or lost, data about the game
            Console.ReadKey();

        }

        static string GetInput(string lettersGuessed)
        {
            Console.WriteLine("Try to guess but I doubt you'll get close.");

            while (true)
            {

                string takeAGuess = Console.ReadLine();


                if (takeAGuess.Length == 1)
                {
                    if (theAlphabet.Contains(takeAGuess.ToLower()) && !lettersGuessed.Contains(takeAGuess))
                    {
                        return takeAGuess.ToLower();
                    }
                }

                else
                {
                    bool validWord = true;
                    foreach (char thisChar in takeAGuess)
                    {
                        if (!theAlphabet.Contains(thisChar.ToString().ToLower()))
                        {
                            validWord = false;
                            break;
                        }
                    }
                    if (validWord)
                    {
                        return takeAGuess.ToLower();
                    }
                }

                Console.WriteLine("You already guessed that. How bout we try an educated guess this time.");


            }
        }

        static void PrintTheStuff(string maskedWord, int numberOfGuesses)
        {
            Console.Clear();
            string[] numberOfGuessesArray = new string[] 
            { 
@"       0
      -|-
      / \",
@"       o
      -|-
      / \",
@"       o
      -|-
      /",
@"      o
     -|-", 
@"      o
      |-",
@"      o
      |",
@"    c
o",
            ""};




            Console.WriteLine(numberOfGuessesArray[numberOfGuesses]);





            Console.WriteLine("You have {0} guesses left", numberOfGuesses);
            Console.WriteLine(maskedWord);


        }

        static string Unmask(char userGuess, string wordToUnmask)
        {
            return "";
        }
    }
}

