using System;
using EquationSolver;

namespace EqualSolverInConsole
{
    class EqualSolverInConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите уравнение в формате: a*x^2+b*x+c=0"+Environment.NewLine+
                "Если в уравнении есть минус поставьте его после +"+ Environment.NewLine +
            "Например: 4*x^2+-2*x+-19=0");
            Console.Write("Уравнение:");
            string equal = Console.ReadLine();
            while ((ValidationString.ValidateString(equal)&&ValidationString.FindNull(equal)==false))
            {
                Console.WriteLine("Введите уравнение в верном формате)");
                Console.Write("Уравнение:");
                equal = Console.ReadLine();
            }
            int[] parametres= ParsingEquation.GetParametres(equal);
            int discriminant = DiscriminantCalculation.GetDiscriminant(parametres);
            if(RootsFinder.GetX1(parametres, discriminant)== RootsFinder.GetX2(parametres, discriminant))
            {
                Console.WriteLine("В уравнении 1 корень:" + RootsFinder.GetX1(parametres, discriminant));
            }
            else
            {
                Console.WriteLine("Корень первый:" + RootsFinder.GetX1(parametres, discriminant));
                Console.WriteLine("Корень второй:" + RootsFinder.GetX2(parametres, discriminant));
            }
            Console.ReadKey();
        }
    }
}
