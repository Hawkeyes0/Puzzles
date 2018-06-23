using System;
using System.Collections.Generic;
using System.Text;

namespace triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input three numers: ");
            string input = Console.ReadLine();
            string[] temp = input.Split(',');
            List<int> numbers = new List<int> {
                Convert.ToInt32(temp[0]),
                Convert.ToInt32(temp[1]),
                Convert.ToInt32(temp[2])
            };
            numbers.Sort();
            Triangles result = Calc(numbers);

            StringBuilder sb = new StringBuilder("These numbers ");
            if(result == Triangles.None)
            {
                sb.Append("can't make triangle.");
                Console.WriteLine(sb);
                return;
            }
            sb.Append("can make a ");
            sb.Append(result).Append(" triangle.");
            Console.WriteLine(sb);
        }

        private static Triangles Calc(List<int> numbers)
        {
            // can made triangle?
            if (numbers[0] + numbers[1] < numbers[2])
            {
                return Triangles.None;
            }

            // what kind
            if(numbers[0] == numbers[1] && numbers[0] == numbers[2])
            {
                return Triangles.Equilateral;
            }
            Triangles result = Triangles.None;
            if(numbers[0] == numbers[1])
            {
                result |= Triangles.Isosceles;
            }
            int pxy = numbers[0] * numbers[0] + numbers[1] * numbers[1];
            int pz = numbers[2] * numbers[2];
            if(pxy < pz)
            {
                result |= Triangles.Obtuse;
            }
            else if (pxy == pz)
            {
                result |= Triangles.Right;
            }
            else
            {
                result |= Triangles.Acute;
            }
            return result;
        }
    }

    [Flags]
    enum Triangles
    {
        None = 0,
        Isosceles = 1,
        Equilateral = 2,
        Acute = 4,
        Obtuse = 8,
        Right = 16
    }
}
