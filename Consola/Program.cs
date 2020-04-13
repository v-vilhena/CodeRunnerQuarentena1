using System;
using Calculadora;
using JogoDaForca;
using JogoDoGalo;
using PPT;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculadora.Calculadora.Calculator();

            Galo.TicTacToe();

            Forca.Hangman();

            PedraPapelTesoura.Start();
        }
    }
}
