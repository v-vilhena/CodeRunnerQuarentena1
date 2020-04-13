using System;
using System.Threading;

namespace PPT
{
    public class PedraPapelTesoura
    {
        private const char ROCK = 'r';
        private const char PAPER = 'p';
        private const char SCISSORS = 's';

        public static void Start()
        {

            Console.WriteLine("Best of how many?");
            int numOfPlays = int.Parse(Console.ReadLine());
            Console.WriteLine("Name of the player?");
            string playerName = Console.ReadLine();
            Console.Clear();
            int counter = 1;
            int playerWins = 0;
            int pcWins = 0;
            char p1 = ' ';
            char p2 = ' ';



            #region for do counter
            while (counter <= numOfPlays)
            {
                //PlayerPlay(ref p1); comentámos isto, porque o Play já os chama
                //Console.Clear();
                //PCPlay(ref p2);
                
                Display(p1, p2, 4);
                Play(ref p1, ref p2, ref playerWins, ref pcWins/*, numOfPlays*/);
                if (playerWins >= (numOfPlays / 2))
                    break;
                else if (pcWins >= (numOfPlays / 2))
                    break;
                counter++;
                Console.Clear();
            }

            #endregion


            if (playerWins >= (numOfPlays / 2))
                DisplayWinner(playerName);
            else if (pcWins >= (numOfPlays / 2))
                DisplayLoser(playerName);
            else
                DisplayTie();

        }
    

        public static char PlayerPlay(ref char p1)
        {
            Console.WriteLine("1 - ROCK" + '\n' +
                              "2 - PAPER" + '\n' +
                              "3 - SCISSORS");
            int p1Number = int.Parse(Console.ReadLine());
            bool isp1Valid = true;
            while (!isp1Valid)
            {
                Console.WriteLine("\nInvalid choice!" + '\n' + '\n' +
                                  "1 - ROCK" + '\n' +
                                  "2 - PAPER" + '\n' +
                                  "3 - SCISSORS");
                p1Number = Console.ReadKey().KeyChar;
                if ((p1Number < 1 || p1Number > 3))
                isp1Valid = false;
            }
            switch (p1Number)
            {
                case 1: p1 = 'r'; break;
                case 2: p1 = 'p'; break;
                case 3: p1 = 's'; break;
            }
            Console.Clear();
            return p1;
        }

        public static char PCPlay(ref char p2)
        {
            int p2Number = Aleatorio(1, 3);
            switch (p2Number)
            {
                case 1: p2 = 'r'; break;
                case 2: p2 = 'p'; break;
                case 3: p2 = 's'; break;
            }
            return p2;
        }

        public static int Play(ref char p1, ref char p2, ref int PlayerWins, ref int PCWins/*, ref int numOfPlays*/)
        {
            PlayerPlay(ref p1);
            PCPlay(ref p1);

            while (p1 != p2)
            {
                PlayerPlay(ref p1);
                PCPlay(ref p1);
            }
            if ((p1 == 'r' && p2 == 's') || (p1 == 's' && p2 == 'p') || (p1 == 'p' && p2 == 'r'))
            {
                PlayerWins++;
                return PlayerWins;

            }
            else
            {
                PCWins++;
                return PCWins;
            }
        }

        #region Suporte
        public static char ConvChar(string num)
    {
        var parseOk = char.TryParse(num, out char parsedChar);
        if (parseOk)
        {
            return parsedChar;
        }
        else
        {
            return '0';
        }
    }
        private static void DisplayLoser(string name)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Roses are Red");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("A longboard is also called a cruiser");
        Console.Write("I'm sorry ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write(name);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("!\nYou are the loser");
    }

        private static void DisplayTie()
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Roses are Red");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("I must say goodbye");
        Console.WriteLine("This game is over!");
        Console.WriteLine("It ended in a tie");
        }
        private static int Aleatorio(int min, int max)
        {
        return new Random().Next(max) + min;
        }

        private static void Display(char p1, char p2, int rounds = 4)
        {
            for (var i = 0; i < rounds; i++)
            {
                var @switch = false;
                var pos = 0;
                while (!(@switch && pos == 0))
                {
                    Console.Clear();
                    if (i == rounds - 1 && pos == 2)
                    {
                        DisplayResult(pos, p1, p2);
                        Thread.Sleep(500);
                        break;
                    }
                    else
                        DisplayResult(pos, 'r', 'r');
                    Thread.Sleep(50);
                    pos = pos + (@switch ? -1 : 1);
                    if (pos == 4) @switch = !@switch;
                }
            }
        }

        private static void DisplayWinner(string playerName)
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Roses are Red");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Violets are blue");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Congratulations ");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write(playerName);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("!\nA winner is you");
        }

        private static void DisplayResult(int lines, char p1, char p2)
        {
        while (lines > 0)
            {
            Console.WriteLine();
            lines--;
            }
        //1
        Console.Write("          _______");
        Console.CursorLeft = 30;
        Console.WriteLine(p2 == 'r' ? "  _______" : p2 == 'p' ? "       _______" : "       _______");

        //2
        Console.Write(p1 == 'r' ? "      ---'   ____)" : p1 == 'p' ? "      ---'   ____)____ " : "      ---'   ____)____");
        Console.CursorLeft = 30;
        Console.WriteLine(p2 == 'r' ? " (____   '---      " : p2 == 'p' ? "  ____(____   '---      " : "  ____(____   '---      ");

        //3
        Console.Write(p1 == 'r' ? "            (_____)" : "                ______)");
        Console.CursorLeft = 30;
        Console.WriteLine(p2 == 'r' ? "(____   '---      " : " (______");

        //4
        Console.Write(p1 == 'r' ? "            (_____)" : p1 == 'p' ? "                _______)" : "             __________)");
        Console.CursorLeft = 30;
        Console.WriteLine(p2 == 'r' ? "(_____)" : p2 == 'p' ? "(_______" : "(__________");

        //5
        Console.Write(p1 == 'r' ? "             (____)" : p1 == 'p' ? "               _______)" : "            (____)");
        Console.CursorLeft = 30;
        Console.WriteLine(p2 == 'r' ? "(____)" : p2 == 'p' ? " (_______" : "     (____)");

        //6
        Console.Write(p1 == 'r' ? "      ---.__(___) " : p1 == 'p' ? "      ---.__________)" : "      ---.__(___)");
        Console.CursorLeft = 30;
        Console.WriteLine(p2 == 'r' ? "  (___)__.---" : p2 == 'p' ? "   (__________.---" : "      (___)__.---");
    }

    #endregion
    }
}
