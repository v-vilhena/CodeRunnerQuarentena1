using System;

namespace Calculadora
{
    public class Calculadora
    {
        public static void Calculator()
        {
            double a;
            double b;
            double s;
            double m;
            double s2;
            double d = 0;
            double op = 0;
            //string op2 = Convert.ToString(Console.ReadLine());
            while (true)
            {
                Menu();
                op = double.Parse(Console.ReadLine()); //E agora?
                switch (op)
                {//dentro deste switch D nao existe no contexto
                    case 1:
                        Console.WriteLine(" \n Introduza um valor para A\n ");
                        a = double.Parse(Console.ReadLine());
                        Console.WriteLine(" \n Introduza um valor para B\n ");
                        b = double.Parse(Console.ReadLine());
                        s = Soma(ref a, ref b);
                        Console.WriteLine(s);
                        break;
                    case 2:
                        Console.WriteLine(" \n Introduza um valor para A\n ");
                        a = double.Parse(Console.ReadLine());
                        Console.WriteLine(" \n Introduza um valor para B\n ");
                        b = double.Parse(Console.ReadLine());
                        m = Mult(ref a, ref b);
                        Console.WriteLine(m);
                        break;
                    case 3:
                        Console.WriteLine(" \n Introduza um valor para A\n ");
                        a = double.Parse(Console.ReadLine());
                        Console.WriteLine(" \n Introduza um valor para B\n ");
                        b = double.Parse(Console.ReadLine());
                        double c = Div(ref a, ref b, ref d); 
                        Console.WriteLine(d);
                        break;
                    case 4:
                        Console.WriteLine(" \n Introduza um valor para A\n ");
                        a = double.Parse(Console.ReadLine());
                        Console.WriteLine(" \n Introduza um valor para B\n ");
                        b = double.Parse(Console.ReadLine());
                        s2 = Sub(ref a, ref b);
                        Console.WriteLine(s2);
                        break;
                }
                Console.ReadKey();
            }
        }
        static public double Soma(ref double a, ref double b)
        {
            double s1;
            s1 = a + b;
            return s1;
        }
        static public double Mult(ref double a, ref double b)
        {
            double m1;
            m1 = a * b;
            return m1;
        }
        static public double Div(ref double a, ref double b, ref double d)
        {
            if (b != 0)
            {
                d = a / b;
            }
            else
                Console.WriteLine("Não é possível dividir por zero");
            return d;
        }
        static public double Sub(ref double a, ref double b)
        {
            double s1;
            s1 = a - b;
            return s1;
        }
        static public void Menu()
        {
            bool sair = false;
            while (!sair)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("    Calculadora   " + "\n" +
                    " Num Lock  / * -  " + "\n" +
                    "   7   8   9      " + "\n" +
                    "   4   5   6   +  " + "\n" +
                    "   1   2   3      " + "\n" +
                    "   0   .  esc     " + "\n" +
                    "                  ");

            }

        }
    }
}
