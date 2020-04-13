using System;

namespace JogoDoGalo
{
    public class Galo
    {
        public static void TicTacToe()
        {
            char field1 = ' ';
            char field2 = ' ';
            char field3 = ' ';
            char field4 = ' ';
            char field5 = ' ';
            char field6 = ' ';
            char field7 = ' ';
            char field8 = ' ';
            char field9 = ' ';

            char playerOne = 'X';
            char playerTwo = 'O';

            char currentPlayer = playerOne;

            char line;
            char column;

            bool validMove = false;
            bool endGame = false;

            while (!endGame)
            {
                Console.Clear();
                ShowBoard(ref field1, ref field2, ref field3, ref field4, ref field5, ref field6, ref field7, ref field8, ref field9);
                while (!validMove)
                {
                    Console.WriteLine($"\n{currentPlayer} - Escolhe a linha");
                    line = Console.ReadKey().KeyChar;
                    Console.WriteLine($"\n{currentPlayer} - Escolhe a coluna");
                    column = Console.ReadKey().KeyChar;

                    if (line == '1' && column == '1')
                    {
                        CheckAndPlay(ref currentPlayer, ref field1, ref validMove);
                    }
                    else if (line == '1' && column == '2')
                    {
                        CheckAndPlay(ref currentPlayer, ref field2, ref validMove);
                    }
                    else if (line == '1' && column == '3')
                    {
                        CheckAndPlay(ref currentPlayer, ref field3, ref validMove);
                    }
                    else if (line == '2' && column == '1')
                    {
                        CheckAndPlay(ref currentPlayer, ref field4, ref validMove);
                    }
                    else if (line == '2' && column == '2')
                    {
                        CheckAndPlay(ref currentPlayer, ref field5, ref validMove);
                    }
                    else if (line == '2' && column == '3')
                    {
                        CheckAndPlay(ref currentPlayer, ref field6, ref validMove);
                    }
                    else if (line == '3' && column == '1')
                    {
                        CheckAndPlay(ref currentPlayer, ref field7,  ref validMove);
                    }
                    else if (line == '3' && column == '2')
                    {
                        CheckAndPlay(ref currentPlayer, ref field8, ref validMove);
                    }
                    else if (line == '3' && column == '3')
                    {
                        CheckAndPlay(ref currentPlayer, ref field9, ref validMove);
                    }
                }
                CheckWin(ref endGame, ref currentPlayer, ref field1, ref field2, ref field3, ref field4, ref field5, ref field6, ref field7, ref field8, ref field9);
                ChangePlayer(ref currentPlayer, ref playerOne, ref playerTwo);
                validMove = false;
            }
            ShowBoard(ref field1, ref field2, ref field3, ref field4, ref field5, ref field6, ref field7, ref field8, ref field9);
        }

        public static void CheckAndPlay(ref char currentPlayer, ref char field, ref bool validMove)
        {
            if (field == ' ')
            {
                field = currentPlayer;
                validMove = true;
            }
            else
            {
                Console.WriteLine("\nPosição inválida");
            }
        }

        public static void ChangePlayer(ref char currentPlayer, ref char playerOne, ref char playerTwo)
        {
            if (currentPlayer == playerOne)
            {
                currentPlayer = playerTwo;
            }
            else if (currentPlayer == playerTwo)
            {
                currentPlayer = playerOne;
            }
        }

        public static void CheckWin(ref bool endGame, ref char currentPlayer, ref char field1, ref char field2, ref char field3, ref char field4, ref char field5, ref char field6, ref char field7, ref char field8, ref char field9)
        {
            if (field1 == currentPlayer && field2 == currentPlayer && field3 == currentPlayer ||  // Linha 1
                field4 == currentPlayer && field5 == currentPlayer && field6 == currentPlayer ||  // Linha 2
                field7 == currentPlayer && field8 == currentPlayer && field9 == currentPlayer ||  // Linha 3
                field1 == currentPlayer && field4 == currentPlayer && field7 == currentPlayer ||  // Coluna 1
                field2 == currentPlayer && field5 == currentPlayer && field8 == currentPlayer ||  // Coluna 2
                field3 == currentPlayer && field6 == currentPlayer && field9 == currentPlayer ||  // Coluna 3
                field1 == currentPlayer && field5 == currentPlayer && field9 == currentPlayer ||  // Diagonal 1
                field3 == currentPlayer && field5 == currentPlayer && field7 == currentPlayer) // Diagonal 2
            {
                Console.Clear();
                endGame = true;
                Console.WriteLine($"\n{currentPlayer} venceu!");
            }
            else if (field1 != ' ' && field2 != ' ' && field3 != ' ' &&
                     field4 != ' ' && field5 != ' ' && field6 != ' ' &&
                     field7 != ' ' && field8 != ' ' && field9 != ' ')
            {
                Console.Clear();
                endGame = true;
                Console.WriteLine("\nEmpate.");
            }
        }

            public static void ShowBoard(ref char field1, ref char field2, ref char field3, ref char field4, ref char field5, ref char field6, ref char field7, ref char field8, ref char field9)
            {
                Console.WriteLine($"" + '\n' +
                                  $"      1  |  2  |  3     -->  linha" + '\n' +
                                  $"" + '\n' +
                                  $"         |     |" + '\n' +
                                  $"  1   {field1}  |  {field2}  |  {field3}" + '\n' +
                                  $"    _____|_____|_____" + '\n' +
                                  $"         |     |" + '\n' +
                                  $"  2   {field4}  |  {field5}  |  {field6}" + '\n' +
                                  $"    _____|_____|_____" + '\n' +
                                  $"         |     |" + '\n' +
                                  $"  3   {field7}  |  {field8}  |  {field9}" + '\n' +
                                  $"         |     |" + '\n' +
                                  $"" + '\n' +
                                  $"  | " + '\n' +
                                  $"  V" + '\n' +
                                  $"  coluna");
            }
        }
    }