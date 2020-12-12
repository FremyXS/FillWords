using System;
using System.Collections.Generic;
using System.Text;

namespace FillWordsNewVersion
{
    class NewGame
    {
        public void StartNewGame()
        {
            ReadAllDataInFiles link2 = new ReadAllDataInFiles();
            
            AllData.Name = SelectName();

            Console.Clear();

            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine($"\nПривет {AllData.Name}\nНажмите Enter чтобы продолжить!");
                key = Console.ReadKey();

            } while (key.Key != ConsoleKey.Enter);

            AllData.Words = link2.Dictionary();

            Cicle();

        }
        public void Cicle()
        {
            int lvl = AllData.lvl;

            SelectInBoard link = new SelectInBoard();
            do
            {
                Console.Clear();

                if (AllData.lvl % 5 == 0)
                    AllData.Koor += 1;

                WordsRandom();

                new AllData();

                link.Select();


            } while (5 > 1);
        }
        private string SelectName()  //ввод имени
        {
            string name;
            Console.Clear();

            Console.WriteLine(new string('\n', 5));
            Console.Write($"{new string(' ', 90)}Введите Имя:");

            int error;

            do  // проверка на тупика
            {
                error = 0;

                name = Console.ReadLine();

                foreach (var i in name)
                {
                    if (i < '0' || i > '9' && i < 'A' || i > 'Z' && i < 'a' || i > 'z' && i < 'А' || i > 'Я' && i < 'а' || i > 'я')
                        error++;
                    if (name.Length == 0)
                        error++;
                }

                if (error > 0)
                    Console.WriteLine("Вы ввели не верно имя\nМожно использовать только символы латинского алфавита, кирилицу и цифры!");
                Console.Write(new string(' ', 90));

            } while (error > 0);

            return name;
        }
        private void WordsRandom()
        {
            Random rnd = new Random();

            int VsegoB = 0; int value;

            //Поиск подходящих слов
            do
            {
                if (VsegoB < AllData.Koor * AllData.Koor + AllData.AccWords.Count)
                {
                    value = rnd.Next(0, AllData.Words.Count - 1);

                    VsegoB += AllData.Words[value].Length;

                    AllData.AccWords.Add(AllData.Words[value].ToUpper());

                }
                else if (VsegoB > AllData.Koor * AllData.Koor + AllData.AccWords.Count || AllData.AccWords.Count < 3)
                {
                    AllData.AccWords.Clear();
                    VsegoB = 0;
                }
                else if (VsegoB == AllData.Koor * AllData.Koor + AllData.AccWords.Count)
                {
                    foreach (var i in AllData.AccWords)
                    {
                        AllData.Words.Remove(i);
                    }
                }

            } while (VsegoB != AllData.Koor * AllData.Koor + AllData.AccWords.Count);

        }

    }
}
