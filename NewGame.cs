using System;
using System.Collections.Generic;
using ReadFile;
using ItsFillwords;
using SelectInBoard;

namespace MenuNewGame
{
    public class NewGame
    {
        private string Name;

        public char[,] ArrayTabl;
        public int Koor;
        private int Kol = 5;
        private int KolUrovn = 1;
        public int Points = 0;

        private List<string> Words;
        private List<string> AccWords = new List<string>();
        public void ReadNewGame()
        {
            SelectName();

            Console.Clear();

            Console.WriteLine($"\nПривет {Name}\nНажмите Enter чтобы продолжить!");

            ConsoleKeyInfo key;

            SearchWords();

            do 
            {
                if (KolUrovn % 5 == 0)
                    Kol++;


                key = Console.ReadKey();

                Console.Clear();

                WordsRandom();

                Selecting TheLink = new Selecting();

                TheLink.ArrayTabl = ArrayTabl; TheLink.koor = Koor; TheLink.Name = Name; TheLink.AccWords = AccWords; TheLink.KolUrov = Convert.ToString(KolUrovn);

                TheLink.Points = Points;

                TheLink.Select();

                KolUrovn++;

                Points = TheLink.Points;

            } while (key.Key != ConsoleKey.Escape);

            

        }
        private void SelectName()  //ввод имени
        {
            Console.Clear();

            Console.WriteLine(new string('\n', 5));
            Console.Write($"{new string(' ', 90)}Введите Имя:");

            int error;

            do  // проверка на тупика
            {
                error = 0;

                Name = Console.ReadLine();

                foreach (var i in Name)
                {
                    if (i < '0' || i > '9' && i < 'A' || i > 'Z' && i < 'a' || i > 'z' && i < 'А' || i > 'Я' && i < 'а' || i > 'я')
                        error++;
                }

                if (error > 0)
                    Console.WriteLine("Вы ввели не верно имя\nМожно использовать только символы латинского алфавита, кирилицу и цифры!");
                Console.Write(new string (' ', 90));

            } while (error > 0);
        }
        private void SearchWords() //добавляем список слов
        {
            ReadListWords TheLink = new ReadListWords();

            TheLink.Dictionary();
            Words = TheLink.Words;


        }
        private void WordsRandom()
        {
            Random rnd = new Random();

            int VsegoB = 0; int value;

            //Поиск подхлдящих слов
            do
            {
                if (VsegoB < Kol * Kol + AccWords.Count)
                {
                    value = rnd.Next(0, Words.Count - 1);

                    VsegoB += Words[value].Length;

                    AccWords.Add(Words[value].ToUpper());

                }
                else if (VsegoB > Kol * Kol + AccWords.Count || AccWords.Count < 3)
                {
                    AccWords.Clear();
                    VsegoB = 0;
                }
                else if (VsegoB == Kol * Kol + AccWords.Count)
                {
                    foreach(var i in AccWords)
                    {
                        Words.Remove(i);
                    }
                }
                
            } while (VsegoB != Kol * Kol + AccWords.Count);

            //переход в другой файл
            Board TheLink = new Board();
            TheLink.Koor = Kol;
            TheLink.AccWords = AccWords;
            TheLink.RazborSlov();
            ArrayTabl = TheLink.ArrayTabl; Koor = TheLink.Koor;

            Console.WriteLine("\n" + Name);
            Console.WriteLine("Уровеь: " + KolUrovn);
            Console.WriteLine("Очки: "+ Points);
            TheLink.BuildTabl();

        }
    }
    
}
