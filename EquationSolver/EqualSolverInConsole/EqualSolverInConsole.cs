using System;
using EquationSolver;

namespace EqualSolverInConsole
{
    class EqualSolverInConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello,git!!!");


            Console.WriteLine("Введите уравнение в формате: a*x^2+b*x+c=0"+Environment.NewLine+
                "Если в уравнении есть минус поставьте его после +"+ Environment.NewLine +
            "Например: 4*x^2+-2*x+-19=0");
            Console.Write("Уравнение:");
            string equation = Console.ReadLine();
            while ((ValidationString.ValidateString(equation)&&ValidationString.FindNull(equation)==false))
            {
                Console.WriteLine("Введите уравнение в верном формате)");
                Console.Write("Уравнение:");
                equation = Console.ReadLine();
            }
            int[] parameters= ParsingEquation.GetParameters(equation);
            int discriminant = DiscriminantCalculation.GetDiscriminant(parameters);
            if (discriminant < 0) 
            {
                Console.WriteLine("Действительных корней нет!");
                Console.ReadKey();
                return;
            }
            double x1 = RootsFinder.GetX1(parameters, discriminant);
            double x2 = RootsFinder.GetX2(parameters, discriminant);
            if(x1== x2)
            {
                Console.WriteLine("В уравнении 1 корень:" + x1);
            }
            else
            {
                Console.WriteLine("Корень первый:" + x1);
                Console.WriteLine("Корень второй:" + x2);
            }
            Console.ReadKey();
        }
    }
}
