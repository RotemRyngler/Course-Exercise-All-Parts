using System;

namespace PartThreeExercises
{
    class Program
    {
        public static void Main(string[] args)
        { 
            //Testing 
            LinkedList list = new LinkedList();
            list.Append(100);
            list.Append(1);
            list.Append(2);
            list.PrintList();
            list.Prepend(3);
            list.PrintList();
            Console.WriteLine(list.Pop());
            list.PrintList();
            Console.WriteLine(list.Unqueue());
            list.PrintList();
            IEnumerable<int> x = list.ToList();
            foreach(int i in x)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            list.Sort();
            list.PrintList();
            int num = 300;
            NumericalExpression number = new NumericalExpression(num);
            string result = number.ToString();
            Console.WriteLine(result);
            Console.WriteLine(NumericalExpression.SumLetters(1000));
            Console.WriteLine(NumericalExpression.SumLetters(number));
        }
    }
}
