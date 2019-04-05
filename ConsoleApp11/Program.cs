using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitThreeHandsOn
{
    class Program
    {
        /// <summary>
        /// Developer: Andrew Miller
        /// Date Written: 1 April 2019
        /// Date Last Updated: 5 April 2019
        /// Title: Unit 3 Hand-On
        /// Purpose: This application prompts the user to input names with associated scores, these inputs are eventually stored in an array
        /// the min, max, and average of scores are reported along with all names and associated scores.
        /// Notes:
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Initialize some necessary variables
            string willContinue = "Y";
            int counter = 0;
            var names = new List<string>();
            var scores = new List<int>();
            string holdScore = "";
            int scoreAsAnInt = 0;
            string holdName = "";
            int scoreInt = 0 ;
            double scoresAvg;
            //Explain purpose of application to user
            Console.WriteLine("This application will store entered player names and scores then report back when finished.");
            while (willContinue == "y" || willContinue == "Y")
            {

                //Prompt for inputs and store as list
                Console.WriteLine("Write the player name and then press enter.");
                holdName = Console.ReadLine();
                names.Add(holdName);
                Console.WriteLine("What score did {0} achieve?", holdName);
                holdScore = Console.ReadLine();

                while (int.TryParse(holdScore, out scoreInt) == false)
                {
                    Console.WriteLine("Non-integer value entered - What score did {0} achieve?", holdName);
                    holdScore = Console.ReadLine();
                    
                }


                while (scoreInt < 0 || scoreInt > 50)
                {
                    Console.WriteLine("Valid scores are from 0 to 50. What score did {0} achieve?", holdName);
                    holdScore = Console.ReadLine();
                    while (int.TryParse(holdScore, out scoreInt) == false)
                    {
                        Console.WriteLine("Non-integer value entered - What score did {0} achieve?", holdName);
                        holdScore = Console.ReadLine();

                    }
                }
                scoreAsAnInt = scoreInt;



                scores.Add(scoreAsAnInt);
                Console.WriteLine("Would you like to continue entering players and scores? Y/N");
                willContinue = Console.ReadLine();
                counter++;
            }
            Console.Clear();
            //Create arrays from lists
            int[] scoresArray = scores.ToArray();
            string[] namesArray = names.ToArray();

            //scoresAvg = scoresArray.Average();
            //manually calculating average instead
            int sumOfScores = 0;
            for (int i = 0; i < scoresArray.Length; i++)
            {
                sumOfScores += scoresArray[i];
            }

            double scoreAverage = sumOfScores / scoresArray.Length;
            
            //Test(namesArray);
            //Test(scoresArray);
            //Console.WriteLine(scoresArray[0]);
            //Console.WriteLine(scoresArray[1]);
            //Console.WriteLine(namesArray[0]);

            //Output information
            Console.WriteLine("----- Player List ----");
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("{0}  {1}", namesArray[i], scoresArray[i]);

            }

            //Determine index of max value
            int maxValue = scoresArray[0];
            int maxIndex = 0;
            for (int i = 1; i < scoresArray.Length; i++)
            {
                int value = scoresArray[i];
                if (value > maxValue)
                {
                    maxValue = value;
                    maxIndex = i;
                }
            }

            //Determine index of min value
            int minValue = scoresArray[0];
            int minIndex = 0;
            for (int i = 1; i < scoresArray.Length; i++)
            {
                int value = scoresArray[i];
                if (value < minValue)
                {
                    minValue = value;
                    minIndex = i;
                }
            }
            Console.Clear();
            Console.WriteLine("----- Player List ----");
            Console.WriteLine("");
            for (int i = 0; i < scoresArray.Length; i++)
            {
                Console.WriteLine("{0}      {1}", scoresArray[i], namesArray[i]);
            }

            Console.WriteLine("Average Strength: {0:F}    Strongest: {1} at {2}   Weakest: {3} at {4}", scoreAverage, namesArray[maxIndex], scoresArray[maxIndex], namesArray[minIndex], scoresArray[minIndex]);
            //Console.WriteLine(scoresArray.Average());
            //Console.WriteLine(scoresArray.Max());
            //Console.WriteLine(scoresArray.Min());
            Console.WriteLine();
            Console.ReadKey();

        }

        //functions for testing that the list was passed to an array appropriately
        static void Test(string[] array)
        {
            Console.WriteLine("Array received: " + array.Length);
        }
        static void Test(int[] array)
        {
            Console.WriteLine("Array received: " + array.Length);
        }
    }
}