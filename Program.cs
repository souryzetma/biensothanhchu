﻿using System;

namespace NumberToWordConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so bat ky < 999,999,999:");
            try
            {
                string input = Console.ReadLine();
                if (input == null)
                {
                    throw new ArgumentNullException("Input cannot be null");
                }                

                int number = Int32.Parse(input);
                
                char[] inputChar = number.ToString().ToCharArray();

                if (number > 999999999 || number < 1)
                {
                    throw new OverflowException("Input needs to be greater than 1 and less than 999,999,999 ");
                }

                //Console.WriteLine("Input Char Count: " + inputChar.Length);

                int hundredthNum = 0;

                int thousandthNum = 0;

                int millionthNum = 0;

                if (inputChar.Length <= 3)
                {
                    //number lss than 1000
                    hundredthNum = number % 1000;
                    //Console.WriteLine("Hundredth Number: " + hundredthNum);
                    Console.WriteLine(ConstructWord(hundredthNum));
                }

                if (inputChar.Length > 3 && inputChar.Length < 7)
                {
                    //number less than a million
                    hundredthNum = number % 1000;
                    thousandthNum = Convert.ToInt32(Math.Truncate((decimal)number / 1000));

                    //Console.WriteLine("Thousandth Number: " + thousandthNum);
                    //Console.WriteLine("Hundredth Number: " + hundredthNum);
                    Console.WriteLine(ConstructWord(thousandthNum) + " Thousand " + ConstructWord(hundredthNum));
                }
                if (inputChar.Length > 6)
                {
                    //greater than Million
                    millionthNum = Convert.ToInt32(Math.Truncate((decimal)number / 1000000));
                    hundredthNum = number % 1000;
                    thousandthNum = Convert.ToInt32(Math.Truncate((decimal)(number % 1000000) / 1000));
                    //Console.WriteLine("Millionth Number: " + millionthNum);
                    //Console.WriteLine("Thousandth Number: " + thousandthNum);
                    //Console.WriteLine("Hundredth Number: " + hundredthNum);

                    Console.WriteLine(ConstructWord(millionthNum) + " Million " + ConstructWord(thousandthNum) + " Thousand " + ConstructWord(hundredthNum));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        public static string ConstructWord(int num)
        {
            String[] top20 = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            String[] Multiple10 = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };

            string word = "";
            int hundredthDigit = Convert.ToInt32(Math.Truncate((decimal)num / 100));

            if (hundredthDigit > 0)
            {
                word = top20[hundredthDigit] + " Hundred and ";
            }

            int tenthDigit = Convert.ToInt32(Math.Truncate((decimal)(num % 100) / 10));

            int digit = num % 10;

            if (tenthDigit > 1)
            {
                word += Multiple10[tenthDigit] + " ";
                word += top20[digit];
            }
            else
            {
                word += top20[num % 100];
            }

            return word;
        }
    }
}