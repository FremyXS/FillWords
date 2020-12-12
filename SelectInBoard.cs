using System;
using System.Collections.Generic;
using System.Text;

namespace FillWordsNewVersion
{
    class SelectInBoard
    {
        public void Select()
        {
            BuildBoard link = new BuildBoard();
            link.RazborSlov();

            Cicle();
          
        }
        public void Cicle()
        {
            new AllData();

            ConsoleKeyInfo key;

            do
            {
                if (CheckEnd()) break;

                ChangeWords();

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter) Select2();
                if (key.Key == ConsoleKey.Escape) Exit();

                Moving(key);


            } while (key.Key != ConsoleKey.F12);
        }
        private void ChangeWords()
        {
            BuildBoard link = new BuildBoard();

            AllData.Zak = AllData.AllKoor;

            Console.Clear();

            BlockInfo();
            
            link.Board();
            FindWords();
        }
        private bool CheckEnd() // прверка, все ли найденные слова?
        {
            if (AllData.AccWords.Count == 0)
            {
                
                Console.Clear();
                Console.WriteLine("Уровень пройден!!!");
                
                AllData.Zak.Clear();
               
                AllData.WordsList.Clear();

                AllData.YandX.Clear();

                AllData.AllKoor.Clear();

                AllData.y = 0;

                AllData.x = 0;

                AllData.lvl++;

                Console.ReadKey();

                return true;

            }
            else
                return false;
        }

        private void Select2()
        {
            ConsoleKeyInfo key;

            string text = "";

            AllData.YandX.AddRange(AllData.AllKoor);

            do 
            {
                ChangeWords2();

                key = Console.ReadKey();


                text += AllData.ArrayTabl[AllData.y, AllData.x];

                Moving(key);


                if (key.Key == ConsoleKey.Enter) ChekWord(text);


            } while (key.Key != ConsoleKey.Enter);
        }
        private void Exit() //выбор да или нет для выхода
        {
            Console.Clear();

            int[] ArraySelect = { 0, 1 };

            int x = 1;

            BlockExit(x);

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) x--;
                if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) x++;
                if (x < 0) x = 1;
                if (x > 1) x = 0;

                BlockExit(x);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (x == 1) break;
                    else
                    {
                        Console.Clear();

                        Console.WriteLine(" .__                    .___.__                \n"
                                         + "|  |   _________     __| _/|__| ____    ____ \n"
                                         + "|  |  /  _ \\__  \\   / __ | |  |/    \\  / ___\\ \n"
                                         + "|  |_(  <_> ) __ \\_/ /_/ | |  |   |  \\/ /_/  > \n"
                                         + "|____/\\____(____  /\\____ | |__|___|  /\\___  / \n"
                                         + "                \\/      \\/         \\//_____/  ");

                        ReadAllDataInFiles link2 = new ReadAllDataInFiles();
                        link2.SavePlayer();

                        Console.Clear();

                        SelectInMenu.Start();

                    }
                }



            } while (key.Key != ConsoleKey.Escape);
        }
        private void BlockExit(int x) //блок изображениия выхода
        {
            Console.Clear();

            Console.WriteLine(new string('\n', 15));
            Console.WriteLine($"{new string(' ', 88)}Вы действительно хотите выйти?");
            Console.WriteLine(new string('\n', 1));

            if (x == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{new string(' ', 100)}ДА  ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("НЕТ  ");
            }
            else
            {
                Console.Write($"{new string(' ', 100)}ДА  ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("НЕТ  ");
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
        private void ChangeWords2()
        {
            BuildBoard link = new BuildBoard();

            AllData.YandX.Add(Convert.ToString(AllData.y) + Convert.ToString(AllData.x));

            AllData.Zak = AllData.YandX;

            Console.Clear();

            BlockInfo();
            link.Board();
            FindWords();

        }
        private void ChekWord(string text)
        {
            text += AllData.AccWords[0][AllData.AccWords[0].Length - 1];

            if (AllData.AccWords.Contains(text))
            {
                AllData.WordsList.Add(text);

                AllData.AccWords.Remove(text);

                
                AllData.AllKoor.AddRange(AllData.YandX);

                AllData.YandX.Clear();

                AllData.Points += 10;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nТут такого слова нет!");
                AllData.YandX.Clear();
                Console.ReadKey();
            }
        }

        private void Moving(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow) AllData.y--;
            if (key.Key == ConsoleKey.DownArrow) AllData.y++;
            if (key.Key == ConsoleKey.RightArrow) AllData.x++;
            if (key.Key == ConsoleKey.LeftArrow) AllData.x--;

            if (AllData.y < 0) AllData.y = AllData.Koor - 1;
            if (AllData.y > AllData.Koor - 1) AllData.y = 0;

            if (AllData.x < 0) AllData.x = AllData.Koor - 1;
            if (AllData.x > AllData.Koor - 1) AllData.x = 0;
        }
        private void BlockInfo()
        {
            Console.WriteLine("\n" + AllData.Name);
            Console.WriteLine("Уровеь: " + AllData.lvl);
            Console.WriteLine("Очки: " + AllData.Points);
        }
        private void FindWords()
        {
            foreach(var I in AllData.WordsList)
                Console.WriteLine(I);
        }

    }
}
