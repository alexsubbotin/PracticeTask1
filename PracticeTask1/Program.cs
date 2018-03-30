using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Library for work with files

namespace PracticeTask1
{
    class Program
    {
        // The 1st practice task. Student: Alexey Subbotin. Group: SE-17-1.

        // Input data consists of 2 numbers – S and K, K<=100 (Number with K > 20 is bigger than ulong, that's why this program works with strings)
        // S defines the sum of digits in output numbers, K defines the number of digits in output numbers.
        // Two output numbers must be the greatest possible and the least possible
        // It is GUARANTEED that it is possible to get at least ONE output number with S sum and K number of digits.

        static void Main(string[] args)
        {
            // Getting input string from the INPUT FILE.
            StreamReader sr = new StreamReader("INPUT.txt");
            string input = sr.ReadLine();
            sr.Close();

            // Decomposing into 2 numbers.
            string[] sNum = input.Split(' ');

            // Getting the sum.
            int S = Convert.ToInt32(sNum[0]);
            // Getting the number of digits.
            int K = Convert.ToInt32(sNum[1]);

            // Array of digits in max.
            int[] max = new int[K];
            // Array of digits in min.
            int[] min = new int[K];

            // Initial value for the 1st digit in min.
            min[0] = 1;

            for (int i = 0; i < K; i++)
            // Go through each element in arrays.
            {
                if (S / 9 != 0)
                // If S greater than 9 then add 9s.
                {
                    max[i] = 9;
                    min[K - i - 1] = 9;

                    S -= 9;
                }
                else
                // If S less than 9.
                {
                    // Adding S.
                    max[i] = S;

                    if (i == K - 1)
                    // If it's the first digit in min.
                    {
                        if (S != 0)
                        // If S is not zero yet then add S.
                            min[K - i - 1] = S;
                    }
                    else
                    // If it's not the first digit in min yet.
                    {
                        if (S != 0)
                        // If S is not zero yet then add S - 1.
                            min[K - i - 1] = S - 1;
                        else
                        // If S is zero then add zero.
                            min[K - i - 1] = S;
                    }

                    // S becomes zero.
                    S = 0;
                }
            }

            string finalMax = "";
            string finalMin = "";

            for (int i = 0; i < K; i++)
            {
                finalMax += max[i].ToString();
                finalMin += min[i].ToString();
            }

            //Console.WriteLine(finalMax + " " + finalMin);

            // Writing the result to the OUTPUT file.
            StreamWriter sw = new StreamWriter("OUTPUT.txt");
            sw.WriteLine(finalMax + " " + finalMin);
            sw.Close();

            //Console.ReadLine();
        }
    }
}
