using System;
using ItsFillwords;
using System.Collections.Generic;
using MenuDummy;


namespace SelectInBoard
{
    public class Selecting
    {
        public char[,] ArrayTabl;
        public int koor;
        private List<string> WordsList = new List<string>();
        public string Name;
        public List<string> AccWords = new List<string>();
        public string KolUrov;

        private List<string> YandX = new List<string>();
        private List<string> Peremen = new List<string>();

        public int Points = 0;

        public void Select() //перемещение по доске
        {
            int x = 0, y = 0;
            ConsoleKeyInfo key;

            do 
            {
                if (CheckEnd()) break;

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape) Exit();

                if (key.Key == ConsoleKey.Enter) Selection(ref x, ref y);

                Moving(key, ref x, ref y);

                ChangeWords(x, y);

                FindWords();


            } while (key.Key != ConsoleKey.F12);


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
                        Dummy link = new Dummy();
                        link.DummyExit();
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
        private bool CheckEnd() // прверка, все ли найденные слова?
        {
            if (AccWords.Count == 0)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Уровень пройден!!!");

                return true;

            }
            else
                return false;
        }
        private void Selection(ref int x, ref int y)//режим выделения
        {
            ConsoleKeyInfo key;
            string text = "";

            foreach(var I in Peremen)
            {
                YandX.Add(I);
            }

            do
            {

                Highlighting(x, y);

                key = Console.ReadKey();
                text += ArrayTabl[y, x];

                Moving(key, ref x, ref y);


                FindWords();


                if (key.Key == ConsoleKey.Enter)
                {
                    ProverkaWord(text);                    
                }

            } while (key.Key != ConsoleKey.Enter);

        }
        private void Moving(ConsoleKeyInfo key, ref int x, ref int y) //область перемещения
        {
            if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W) y--;
            if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S) y++;
            if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) x--;
            if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) x++;

            if (y < 0) y = 0;
            if (y > koor - 1) y = koor - 1;
            if (x < 0) x = 0;
            if (x > koor - 1) x = koor - 1;

        }
        private void ChangeWords(int x, int y) //выделение клеток в обычном режиме
        {
            Board TheLink = new Board();

            TheLink.YandX = Peremen;

            TheLink.x = x; TheLink.y = y;

            Console.Clear();

            TheLink.ArrayTabl = ArrayTabl; TheLink.Koor = koor;

            BlockInfo();

            TheLink.BuildTabl();
        }
        private void Highlighting(int x, int y) //выделение клеток в режиме выделения
        {             
            Board TheLink = new Board();

            TheLink.x = x; TheLink.y = y; 

            YandX.Add(Convert.ToString(y) + Convert.ToString(x));

            TheLink.YandX = YandX;
            
            Console.Clear();

            TheLink.ArrayTabl = ArrayTabl; TheLink.Koor = koor;

            BlockInfo();

            TheLink.BuildTabl();

        }
        private void BlockInfo() //вывод блока информации 
        {

            Console.WriteLine("\n" + Name);
            Console.WriteLine("Уровеь: " + KolUrov);
            Console.WriteLine("Очки: " + Points);

        }
        private void FindWords() //вывод найденных слов
        {
            foreach(var i in WordsList)
                Console.WriteLine(i);
        }
        private void ProverkaWord(string text) //проверка выделенного слова
        {
            text += AccWords[0][AccWords[0].Length - 1];
            

            if (AccWords.Contains(text))
            {
                WordsList.Add(text);

                AccWords.Remove(text);

                foreach (var i in YandX)
                    Peremen.Add(i);

                YandX.Clear();

                Points += 10;
            }
            else
            {
                Console.WriteLine("\nТут такого слова нет!");
                YandX.Clear();
            }

        }
    }
}
