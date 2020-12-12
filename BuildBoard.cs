using System;
using System.Collections.Generic;
using System.Text;

namespace FillWordsNewVersion
{
    class BuildBoard
    {
        public void RazborSlov() // разбиение слов по буквам в массив
        {
            AllData.ArrayTabl = new string[AllData.Koor, AllData.Koor];
            
            for (int i = 0; i < AllData.AccWords.Count; i++) //разбиение по буквам
            {
                for (int j = 0; j < AllData.AccWords[i].Length - 1; j++)
                {
                    AllData.Peremen.Add(AllData.AccWords[i][j].ToString());
                }
            }

            int jol = 0;
            for (int i = 0; i < AllData.Koor; i++) //добавление в массив
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < AllData.Koor; j++)
                    {
                        AllData.ArrayTabl[i, j] = AllData.Peremen[jol];
                        jol++;
                    }
                }
                else
                {
                    for (int j = AllData.Koor - 1; j >= 0; j--)
                    {
                        AllData.ArrayTabl[i, j] = AllData.Peremen[jol];
                        jol++;
                    }
                }
            }
            
        }
        public void Board()
        {
            AllData.YandX = AllData.Peremen;

            IsPerebor('┌', '┬', '┐', '─');
            for(int i = 0; i < AllData.Koor; i++)
            {
                BigCv(i);

                Console.Write(new string(' ', (Console.WindowWidth - 8 * AllData.Koor) / 2));

                for (int j = 0; j < AllData.Koor; j++)
                {
                    Console.Write('│');

                    if (AllData.Zak.Contains(Convert.ToString(i) + Convert.ToString(j)))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write($"   {AllData.ArrayTabl[i, j]}   ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {

                        if (i == AllData.y && j == AllData.x)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"   {AllData.ArrayTabl[i, j]}   ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        else
                        {
                            Console.Write($"   {AllData.ArrayTabl[i, j]}   ");
                        }
                    }
                

                }
                Console.WriteLine('│');

                BigCv(i);

                if (i < AllData.Koor - 1) { IsPerebor('├', '┼', '┤', '─'); }

            }

            IsPerebor('└', '┴', '┘', '─');


        }
        private void IsPerebor(char x1, char x2, char x3, char x4)//построение каждоый стройки
        {
            
            Console.Write(new string(' ', (Console.WindowWidth - 8 * AllData.Koor) / 2));
            Console.Write(x1);
            for (int j = 0; j < AllData.Koor - 1; j++)
            {
                
                Console.Write(new string(x4, 7));
                Console.Write(x2);
                
            }
            Console.Write(new string(x4, 7));
            Console.WriteLine(x3);
        }
        private void BigCv(int i)
        {
            Console.Write(new string(' ', (Console.WindowWidth - 8 * AllData.Koor) / 2));

            for (int j = 0; j < AllData.Koor; j++)
            {
                Console.Write('│');

                if (AllData.Zak.Contains(Convert.ToString(i) + Convert.ToString(j)))
                {
                    Console.BackgroundColor = ConsoleColor.White;

                    Console.Write($"       ");

                    Console.BackgroundColor = ConsoleColor.Black;

                }
                else
                {
                    Console.Write("       ");
                }


            }
            Console.WriteLine('│');
        }
    }
}
