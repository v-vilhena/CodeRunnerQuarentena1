using System;

namespace JogoDaForca
{
    public static class ExtensionMethods
    {
        public static char CharAt(this string @string, int pos) => @string[pos];
    }

    public class Forca
    {

        public static void Hangman()
        {

            string first = "BANANA";
            string second = "ARROZ";
            string third = "CORONA";
            string forth = "CARRO";
            string fifth = "TAPETE";
            string sixth = "FACIL";
            string seventh = "ESQUEMA";
            string eigth = "DIFICIL";
            string ninth = "MITIGAR";
            string tenth = "QUARENTENA";
            string answer = "";
            string wrong = "";
            string guess = "";
            bool endgame = false;

            #region RandomSelection
            int randomNumber = new Random().Next(1,10);
            switch(randomNumber)
            {
                case 1 :
                    answer = first;
                    break;
                case 2:
                    answer = second;
                    break;
                case 3:
                    answer = third;
                    break;
                case 4:
                    answer = forth;
                    break;
                case 5:
                    answer = fifth;
                    break;
                case 6:
                    answer = sixth;
                    break;
                case 7:
                    answer = seventh;
                    break;
                case 8:
                    answer = eigth;
                    break;
                case 9:
                    answer = ninth;
                    break;
                case 10:
                    answer = tenth;
                    break;
            }
            #endregion

            for (var i = 0; i < answer.Length; i++)
            {
                guess += "_ ";
            }

            while (!endgame)
            {
                PrintForca(guess, wrong);
                Console.WriteLine("Introduz uma letra");
                char letter = Char.ToUpper(Console.ReadKey().KeyChar);

                if (letter >= 'A' && letter <= 'Z')
                {
                    if (answer.Contains(letter))
                    {
                        for (int i = 0; i < answer.Length; i++)
                        {
                            if (ExtensionMethods.CharAt(answer, i) == letter)
                            {
                                guess = guess.Remove(i * 2, 1).Insert(i * 2, letter.ToString());
                            }
                        }
                    }
                    else if (!wrong.Contains(letter))
                    {
                        wrong += letter;
                    }


                    if (answer.Equals(guess.Replace(" ", "")))
                    {
                        PrintForca(guess, wrong);
                        Console.WriteLine("\nGanhaste!");
                        endgame = true;
                    }
                    else if (wrong.Length > 5)
                    {
                        PrintForca(guess, wrong);
                        Console.WriteLine("\nPerdeste!");
                        endgame = true;
                    }
                }
            }
        }

        public static void PrintForca(string guess, string wrong)
        {
            var headHangman = " ";
            var bodyHangman = " ";
            var leftArmHangman = " ";
            var rightArmHangman = " ";
            var leftLegHangman = " ";
            var rightLegHangman = " ";
            if (wrong.Length >= 1)
                headHangman = "O";
            if (wrong.Length >= 2)
                bodyHangman = "|";
            if (wrong.Length >= 3)
                leftArmHangman = "/";
            if (wrong.Length >= 4)
                rightArmHangman = "\\";
            if (wrong.Length >= 5)
                leftLegHangman = "/";
            if (wrong.Length >= 6)
                rightLegHangman = "\\";
            Console.Clear();
            Console.WriteLine(" _____" + '\n' +
                              "/     |" + '\n' +
                              $"|     {headHangman}" + '\n' +
                              $"|    {leftArmHangman}{ bodyHangman}{ rightArmHangman}" + '\n' +
                              $"|     { bodyHangman}" + '\n' +
                              $"|    {leftLegHangman} { rightLegHangman}" + '\n' +
                              "|" + '\n' +
                              "=========     " + guess + '\n' +
                              "              " + wrong);
        }
    }
}
