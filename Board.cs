using System;
using System.Collections.Generic;

namespace ItsFillwords
{
    public class Board
    {
        public int Koor;

        public List<string> AccWords; //список слов
        private List<char> Peremen = new List<char>(); //список букв

        public char[,] ArrayTabl; //массив доски

        public int x;
        public int y;

        public List<string> YandX = new List<string>();

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

        }
        private ConsoleColor Colorss()
        {
            Random rnd = new Random();

            var consoleColors = Enum.GetValues(typeof(ConsoleColor));

            var cvet = rnd.Next(consoleColors.Length);

            
            return (ConsoleColor)consoleColors.GetValue(cvet);

        }
        public void BuildTabl() //строение таблицы
        {
            Colorss();

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(new string('\n', 3));

            IsPerebor('┌', '┬', '┐', '─');

            var cvet = Colorss();

            for (int i = 0; i < Koor; i++)
            {
                BigCvadr(i, cvet);

                Console.Write(new string(' ', (Console.WindowWidth - 8 * Koor) / 2));


                for (int j = 0; j < Koor; j++)
                {
                    Console.Write("│");

                    if (YandX.Contains(Convert.ToString(i) + Convert.ToString(j)))
                    {

                        Console.BackgroundColor = cvet;

                        Console.Write($"   {ArrayTabl[i, j]}   ");

                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        if (i == y && j == x)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"   {ArrayTabl[i, j]}   ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        else
                        {
                            Console.Write($"   {ArrayTabl[i, j]}   ");
                        }
                    }


                }
                Console.WriteLine("│");

                BigCvadr(i, cvet);

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
        private void BigCvadr(int i, ConsoleColor cvet) 
        {
            Console.Write(new string(' ', (Console.WindowWidth - 8 * Koor) / 2));

            for (int j = 0; j < Koor; j++)
            {
                Console.Write("│");

                if (YandX.Contains(Convert.ToString(i) + Convert.ToString(j)))
                {
                    Console.BackgroundColor = cvet;

                    Console.Write($"       ");

                    Console.BackgroundColor = ConsoleColor.Black;

                }
                else
                {
                    Console.Write("       ");
                }
            }

            Console.WriteLine("|");
        }

    }
}
