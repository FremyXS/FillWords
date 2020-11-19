using System;
using System.Collections.Generic;

namespace ItsFillwords
{
    public class Board
    {
        public int Koor;

        public List<string> AccWords; //список слов
        private List<char> Peremen = new List<char>(); //список букв

        private char[,] ArrayTabl; //массив доски

        public void RazborSlov() // разбиение слов по буквам в массив
        {
            ArrayTabl = new char[Koor, Koor];

            for (int i = 0; i < AccWords.Count; i++) //разбиение по буквам
            {
                for (int j = 0; j < AccWords[i].Length - 1; j++)
                {
                    Peremen.Add(AccWords[i][j]);
                }
            }

            int jol = 0;
            for (int i = 0; i < Koor; i++) //добавление в массив
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < Koor; j++)
                    {
                        ArrayTabl[i, j] = Peremen[jol];
                        jol++;
                    }
                }
                else
                {
                    for (int j = Koor - 1; j >= 0; j--)
                    {
                        ArrayTabl[i, j] = Peremen[jol];
                        jol++;
                    }
                }
            }

            BuildTabl();

        }
        private void BuildTabl() //строение таблицы
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(new string('\n', 3));

            IsPerebor('┌', '┬', '┐', '─');

            for (int i = 0; i < Koor; i++)
            {
                IsPerebor('│', '│', '│', ' ');

                Console.Write(new string(' ', (Console.WindowWidth - 8 * Koor) / 2));

                for (int j = 0; j < Koor; j++)
                {
                    Console.Write($"│   {ArrayTabl[i, j]}   ");
                }
                Console.WriteLine("│");

                IsPerebor('│', '│', '│', ' ');

                if (i < Koor - 1) { IsPerebor('├', '┼', '┤', '─'); }
            }

            IsPerebor('└', '┴', '┘', '─');

        }
        private void IsPerebor(char x1, char x2, char x3, char x4)//построение каждоый стройки
        {
            Console.Write(new string(' ', (Console.WindowWidth - 8 * Koor) / 2));
            Console.Write(x1);
            for (int i = 0; i < Koor - 1; i++)
            {
                Console.Write(new string(x4, 7));
                Console.Write(x2);
            }
            Console.Write(new string(x4, 7));
            Console.WriteLine(x3);
        }

    }
}
