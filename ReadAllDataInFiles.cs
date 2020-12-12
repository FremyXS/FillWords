using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FillWordsNewVersion
{
    class ReadAllDataInFiles
    {
        public List<string> SavesList = new List<string>();
        public int y;

        private string text = File.ReadAllText("filesystem\\word_rus.txt");
        public List<string> Dictionary()
        {
            List<string> Words = new List<string>();
            Words.AddRange(text.Split('\n'));
            return Words;
        }
        public void SavePlayer()
        {
            string num = "1";

            DirectoryInfo dir = new DirectoryInfo("filesystem\\Saves");

            bool y;

            List<string> SavesList = new List<string>();

            foreach (var item in dir.GetFiles())
            {
                SavesList.Add(item.Name);
            }

            //функция для проверки имени файла и его изменения, если файл с таким именем уже существует
            do
            {
                if (SavesList.Contains($"save{num}.txt"))
                {
                    num = Convert.ToString(Convert.ToInt32(num) + 1);
                    y = false;
                }
                else
                    y = true;

            } while (y != true);

            File.WriteAllLines($"filesystem\\Saves\\save{num}.txt", new[] { "Name", AllData.Name, "LVL", AllData.lvl.ToString(), "Points", AllData.Points.ToString(), "koor", AllData.Koor.ToString(), 
                 "AccWords", PereborList(AllData.AccWords), "ArrayTabl", PereborList2(AllData.ArrayTabl), "WordList", PereborList(AllData.WordsList), "AllKoor", PereborList(AllData.AllKoor), "Words", PereborList(AllData.Words), "end" });

        }
        private string PereborList(List<string> i)
        {
            string text = "";
            foreach (string b in i)
            {
                text += b + "\n";
            }
            return text;
        }
        private string PereborList2(string[,] i)
        {
            string text = "";
            foreach (var b in i)
            {
                text += b + "\n";
            }
            return text;
        }
        public void AllSaves() //вывод всех сохранений
        {
            SavesList.Clear();

            string[] InfoArray = { "Name: ", "Level: ", "Points: ", "" };

            DirectoryInfo dir = new DirectoryInfo("filesystem\\Saves");


            foreach (var item in dir.GetFiles())
            {
                SavesList.Add(item.Name);
            }

            Console.WriteLine(new string('\n', 3));

            for (int i = 0; i < SavesList.Count; i++)
            {
                Console.WriteLine(new string('=', Console.WindowWidth));

                List<string> Infa = new List<string>();

                Infa.AddRange(File.ReadAllText("filesystem\\Saves\\" + SavesList[i]).Split('\n'));


                if (i == y)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    BlockSave(InfoArray, Infa);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    BlockSave(InfoArray, Infa);
                }

                Infa.Clear();
            }
            Console.WriteLine(new string('=', Console.WindowWidth));
        }
        private void BlockSave(string[] InfoArray, List<string> Infa)
        {
            string text = ""; int j = 1;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(new string(' ', 95) + InfoArray[i] + Infa[j]);
                j += 2;
            }
            Console.WriteLine(text);

        }
        public List<string> OneSave(int i)
        {

            DirectoryInfo dir = new DirectoryInfo("filesystem\\Saves");

            foreach (var item in dir.GetFiles())
            {
                SavesList.Add(item.Name);
            }

            List<string> Infa = new List<string>();
            Infa.AddRange(File.ReadAllText("filesystem\\Saves\\" + SavesList[i]).Split('\n'));

            return Infa;
        }
    }
}
