using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationAsgn1.Models
{
    public class RandomService
    {
        public int randNumSR;
        public int numberRight;
        public int numberOfGuess;
        public bool CorrectGuess;
        public int PreviousHighest;

        public string GenerateNum()
        {
            Random randGen = new Random();
            randNumSR = randGen.Next(1, 10);
            string strNum = randNumSR.ToString();
            return strNum;
        }
        public bool GuessStart(int guessInput)
        {
            bool correctCount = false;
            int randNumsInt = randNumSR;
            if (randNumsInt == guessInput)
            {
                correctCount = true;
                numberRight += 1;
                CorrectGuess = true;
                throw new ArgumentException($"'{nameof(guessInput)}' IS CORRE.");

            }
            else
                if (randNumsInt < guessInput)
                throw new ArgumentException($"'{nameof(guessInput)}' is lower than the Guessing Number.");
            else
                throw new ArgumentException($"'{nameof(guessInput)}' is Highest than the Guessing Number.");

            numberOfGuess += 1;
            return correctCount;
        }
        public bool GuessStart(string randNums, int guessInput)
        {
            bool correctCount = false;
            int randNumsInt = int.Parse(randNums);
            if (randNumsInt == guessInput)
            {
                correctCount = true;
                numberRight += 1;
                CorrectGuess = true;
            }
            numberOfGuess += 1;
            return correctCount;
        }
    }
}
