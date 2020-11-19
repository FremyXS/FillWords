using System;
using System.Collections.Generic;
using ReadFile;
using ItsFillwords;

namespace MenuNewGame
{
    public class NewGame
    {
        private string Name;

        private List<string> Words;
        public void ReadNewGame()
        {
            SelectName();

            Console.Clear();

            Console.WriteLine($"\n{Name}");


            SearchWords();


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

            int Kol = 5;
            WordsRandom(Kol);

        }
        private void WordsRandom(int Kol)
        {
            Random rnd = new Random();

            int VsegoB = 0; int value;

            List<string> AccWords = new List<string>();

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

        }
    }
    
}
