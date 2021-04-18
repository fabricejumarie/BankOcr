using System;
using System.Collections.Generic;

namespace BankOcr
{
    public class NumberRecognizer : INumberRecognizer
    {
        private Dictionary<int, Func<string, bool>> NumberRecognizerMappings = new Dictionary<int, Func<string, bool>>
        {
            { 1, IsOne },
            { 2, IsTwo },
            { 3, IsThree },
            { 4, IsFour },
            { 5, IsFive },
            { 6, IsSix },
            { 7, IsSeven },
            { 8, IsEight },
            { 9, IsNine },
            { 0, IsZero },
        };
        public static bool IsOne(string number)
        {
            return number == "     |  |";
        }

        public static bool IsTwo(string number)
        {
            return number == " _  _||_ ";
        }

        public static bool IsThree(string number)
        {
            return number == " _  _| _|";
        }

        public static bool IsFour(string number)
        {
            return number == "   |_|  |";
        }

        public static bool IsFive(string number)
        {
            return number == " _ |_  _|";
        }

        public static bool IsSix(string number)
        {
            return number == " _ |_ |_|";
        }

        public static bool IsSeven(string number)
        {
            return number == " _   |  |";
        }

        public static bool IsEight(string number)
        {
            return number == " _ |_||_|";
        }

        public static bool IsNine(string number)
        {
            return number == " _ |_| _|";
        }

        public static bool IsZero(string number)
        {
            return number == " _ | ||_|";
        }

        public int RecognizeNumber(string number)
        {
            foreach (var numberRecognizerMapping in NumberRecognizerMappings)
            {
                if (numberRecognizerMapping.Value(number))
                {
                    return numberRecognizerMapping.Key;
                }
            }

            throw new InvalidOperationException("Number not recognized");

        }
    }
}
