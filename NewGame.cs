using System;

namespace MenuNewGame
{
    public class NewGame
    {
        private string Name;
        public void SelectName()
        {
            Console.Clear();

            Console.WriteLine("Введите Имя");

            int error;

            do
            {
                error = 0;

                Name = Console.ReadLine();

                foreach(var i in Name)
                {
                    if (i < 'A' || i > 'Z' && i < 'a' || i > 'z' && i < 'А' || i > 'Я' && i < 'а' || i > 'я')
                        error++;
                }

                if (error > 0)
                    Console.WriteLine("Вы ввели не верно имя\nМожно использовать только символы латинского алфавита и кирилицу!");



            } while (error > 0);
        }
    }
}
