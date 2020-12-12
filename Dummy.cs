using System;
using System.Collections.Generic;
using System.Text;

namespace FillWordsNewVersion
{
    class Dummy
    {
        public void DummyContinue()
        {
            ReadAllDataInFiles link = new ReadAllDataInFiles();

            ConsoleKeyInfo key;

            int y = 0;

            List<string> SavesList;

            do
            {
                Console.Clear();

                link.y = y;
                link.AllSaves();

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow) y--;
                if (key.Key == ConsoleKey.DownArrow) y++;

                SavesList = link.SavesList;

                if (y > SavesList.Count - 1) y = 0;
                if (y < 0) y = SavesList.Count - 1;

                if (key.Key == ConsoleKey.Enter) SelectProfile(y, SavesList);

            } while (key.Key != ConsoleKey.Escape);

        }
        private void SelectProfile(int y, List<string> SavesList)
        {
            Console.Clear();

            Console.WriteLine(" .__                    .___.__                \n"
                             + "|  |   _________     __| _/|__| ____    ____ \n"
                             + "|  |  /  _ \\__  \\   / __ | |  |/    \\  / ___\\ \n"
                             + "|  |_(  <_> ) __ \\_/ /_/ | |  |   |  \\/ /_/  > \n"
                             + "|____/\\____(____  /\\____ | |__|___|  /\\___  / \n"
                             + "                \\/      \\/         \\//_____/  ");

            ReadAllDataInFiles link = new ReadAllDataInFiles();

            List<string> Infa = link.OneSave(y);

            AllData.Name = Infa[1];
            AllData.lvl = int.Parse(Infa[3]);
            AllData.Points = int.Parse(Infa[5]);
            AllData.Koor = int.Parse(Infa[7]);
            AllData.AccWords = EnterOldData(Infa, "AccWords", "ArrayTabl");
            AllData.ArrayTabl = EnterOldData2(Infa, "ArrayTabl", "WordList");
            AllData.WordsList = EnterOldData(Infa, "WordList", "AllKoor");
            AllData.AllKoor = EnterOldData(Infa, "AllKoor", "Words");
            AllData.Words = EnterOldData(Infa, "Words", "end");

            SelectInBoard link2 = new SelectInBoard();
            NewGame link3 = new NewGame();

            link2.Cicle();

            link3.Cicle();

        }
        private List <string> EnterOldData(List<string> Y, string one, string two)
        {
            List<string> x = new List<string>();

            for (int i = Y.IndexOf($"{one}\r") + 1; i < Y.IndexOf($"{two}\r") - 1; i++)
            {
                x.Add(Y[i]);
                
            }
            
            return x;
        }
        private String[,] EnterOldData2(List<string> Y, string one, string two)
        {
            List<string> x = new List<string>();

            for (int i = Y.IndexOf($"{one}\r") + 1; i < Y.IndexOf($"{two}\r") - 1; i++)
            {
                x.Add(Y[i]);
                
            }

            string[,] ArrayTabl = new string[AllData.Koor, AllData.Koor];
            int kol = 0;

            for(int i = 0; i < AllData.Koor; i++)
            {
                for(int j = 0; j < AllData.Koor; j++)
                {
                    ArrayTabl[i, j] = x[kol];
                    kol++;
                }
            }

            return ArrayTabl;
        }
        public void DummyRating()
        {
            Console.Clear();

            ReadAllDataInFiles link = new ReadAllDataInFiles();

            link.AllSaves();

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey();

            } while (key.Key != ConsoleKey.Escape);

            Console.Clear();
            Console.WriteLine(new string('=', Console.WindowWidth));
        }
        public void DummyExit()
        {

            System.Environment.Exit(0);
        }
    }
}
