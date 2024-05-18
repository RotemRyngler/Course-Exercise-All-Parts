using System;

namespace PartThreeExercises
{
    public class NumericalExpression
    {
        public int Number { get; }
        private string[] _digitExpressions = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private string[] _tenToTwenty = {"", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private string[] _tensExpressions = { "", "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private string[] _placeWords = {"", "thousand", "million", "billion"};

        public NumericalExpression(int number)
        {
            Number = number; 
        }
        public override string ToString()
        {
            int number = Number;
            string resultExpression = "";
            int placeWordIndex = 0;
            if (number == 0)
            {
                return "Zero";
            }
            while(number>0)
            {
                string currentNumber = ExpressionPerThreeDigits(number%1000) + " " + _placeWords[placeWordIndex] + " ";
                resultExpression = currentNumber + resultExpression;
                placeWordIndex++;
                number /= 1000;
            }
            return resultExpression;
        }
        private string ExpressionPerThreeDigits(int number)
        {
            string ones = "";
            string tens = "";
            string hundreds = "";
            if(number % 100 < 20 && number%100 >=10)
            {
                tens = _tenToTwenty[number % 10];
            }
            else
            {
                ones = _digitExpressions[number % 10];
                tens = _tensExpressions[(number / 10) % 10];
            }
            if (number / 100 != 0)
            {

                hundreds = _digitExpressions[number / 100] + " hundred";
            }
            string result = hundreds + " " + tens + " " + ones;
            return result;

        }
        public int GetValue()
        {
            return Number;
        }
        public static int SumLetters(int number)
        {
            int countLetters = 0;
            for(int i=0; i<=number; i++)
            {
                NumericalExpression numericalExpression = new NumericalExpression(i);
                countLetters += numericalExpression.RemoveSpaces(numericalExpression.ToString()).Length;
            }
            return countLetters;
        }
        private string RemoveSpaces(string numberString)
        {
            string noSpaces = "";
            for (int i = 0; i < numberString.Length; i++)
            {
                if (numberString[i] != ' ')
                {
                    noSpaces += numberString[i];
                }
            }
            return noSpaces;
        } 
        //This is polymorphism, there are two functions with the same name but different parameters
        ////and this one uses an instance of the class itself
        public static int SumLetters(NumericalExpression numericalExpression)
        {
            return SumLetters(numericalExpression.Number);
        }
    }
}
