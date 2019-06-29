using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GuessNumber
{
    class Program
    {
        public static String s;
        public static int count = 0;
        public static int codeSize = 4;
        public static void Main(String[] args)
        {
            Random rnd = new Random();
            int digit1 = rnd.Next(1, 6);
            int digit2 = rnd.Next(1, 6);
            int digit3 = rnd.Next(1, 6);
            int digit4 = rnd.Next(1, 6);


            string target = digit1.ToString() + digit2.ToString() + digit3.ToString() + digit4.ToString();
            int targetNo = Convert.ToInt32(target);
            int[] targetArray = targetNo.ToString().Select(o => int.Parse(o.ToString())).ToArray();

            for (int i = 0; i < 10; i++)
            {
                int[] userArray = GetGuess(4);
                checkSign(userArray, targetArray);

                if (checkWin(s) == true)
                {
                    Console.WriteLine("Congratulations! You win!");
                    break;
                }
                else
                {
                    count++;
                    Console.WriteLine("Incorrect answer");
                    Console.WriteLine();
                }

            }
            if (count == 10)
            {
                Console.WriteLine("You Lose");
                Console.WriteLine("The correct answer is " + targetNo);
            }
            Console.WriteLine("Press the Enter key to exit.....");
            string exit = Console.ReadLine().ToString();

        }
        public static void checkSign(int[] userArray, int[] targetArray)
        {
            s = "";
            int pluscount = 0;
            int minuscount = 0;

            if (userArray[0] == targetArray[0])
            {
                pluscount++;
            }
            else if (userArray[0] == targetArray[1] || userArray[0] == targetArray[2] || userArray[0] == targetArray[3])
            {
                minuscount++;
            }

            if (userArray[1] == targetArray[1])
            {
                pluscount++;
            }
            else if (userArray[1] == targetArray[0] || userArray[1] == targetArray[2] || userArray[1] == targetArray[3])
            {
                minuscount++;
            }

            if (userArray[2] == targetArray[2])
            {
                pluscount++;
            }
            else if (userArray[2] == targetArray[0] || userArray[2] == targetArray[1] || userArray[2] == targetArray[3])
            {
                minuscount++;
            }

            if (userArray[3] == targetArray[3])
            {
                pluscount++;
            }
            else if (userArray[3] == targetArray[0] || userArray[3] == targetArray[1] || userArray[3] == targetArray[2])
            {
                minuscount++;
            }

            for (int j = 0; j < pluscount; j++)
            {
                s += "+";
            }

            for (int k = 0; k < minuscount; k++)
            {
                s += "-";
            }
            Console.WriteLine(s);
        }
        private static int[] GetGuess(int v)
        {
            int number = 0;
            int userSize = 4;
            int[] Guess = new int[userSize];
            bool lbNumber = false;

            Console.Write("Please enter a four digit number with each digit ranging from 1-6: ");

            string guessnumber = Console.ReadLine().ToString();
            int ialpha = guessnumber.Count(char.IsLetter);

            if (ialpha > 0)
                Console.WriteLine("Input number cannot be an alpha character");
            else
            {
                if (guessnumber.Length > 4)
                    Console.WriteLine("Input number cannot be more than 4 digits");
                else if (guessnumber.Length < 4)
                    Console.WriteLine("Input number cannot be less than 4 digits");
                else
                    lbNumber = int.TryParse(guessnumber, out number);
            }
            if (lbNumber)
            {
                int[] result = number.ToString().Select(o => int.Parse(o.ToString())).ToArray();

                if (result[0] < 1 || result[0] > 6)
                {
                    Console.WriteLine(result[0] + " is an invalid number!");
                }
                else if (result[1] < 1 || result[1] > 6)
                {
                    Console.WriteLine(result[1] + " is an invalid number!");
                }
                else if (result[2] < 1 || result[2] > 6)
                {
                    Console.WriteLine(result[2] + " is an invalid number!");
                }
                else if (result[3] < 1 || result[3] > 6)
                {
                    Console.WriteLine(result[3] + " is an invalid number!");
                }
                if (result.Length == 4)
                    Guess = result;
            }
            return Guess;
        }

        public static bool checkWin(String x)
        {
            if (x == "++++")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
