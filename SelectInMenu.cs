using System;

namespace FillWordsNewVersion
{
    class SelectInMenu
    {
        static void Main(string[] args)
        {
            Start();
        }
        public static void Start()
        {

            MenuInfo TheLink = new MenuInfo();
            TheLink.MenuWrite();


            ConsoleKeyInfo key;
            int y = 0;
            do
            {
                Console.SetCursorPosition(0, y);

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W) y--;
                if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S) y++;

                if (y < 0) y = 3;
                if (y > 3) y = 0;

                if (y == 0) LightNemGame();
                else if (y == 1) LightContinue();
                else if (y == 2) LightRating();
                else if (y == 3) LightExit();

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    SelectPunct(y);

                }

            }
            while (key.Key != ConsoleKey.Escape);
        }
        private static void LightNemGame()
        {
            Console.Clear();

            MenuInfo TheLink = new MenuInfo();
            TheLink.Head();
            Console.ForegroundColor = ConsoleColor.Red;
            TheLink.NewGame();
            Console.ForegroundColor = ConsoleColor.Magenta;
            TheLink.Continue();
            TheLink.Rating();
            TheLink.Exit();

        }
        private static void LightContinue()
        {
            Console.Clear();

            MenuInfo TheLink = new MenuInfo();
            TheLink.Head();

            TheLink.NewGame();
            Console.ForegroundColor = ConsoleColor.Red;

            TheLink.Continue();
            Console.ForegroundColor = ConsoleColor.Magenta;

            TheLink.Rating();
            TheLink.Exit();

        }
        private static void LightRating()
        {
            Console.Clear();

            MenuInfo TheLink = new MenuInfo();
            TheLink.Head();

            TheLink.NewGame();

            TheLink.Continue();

            Console.ForegroundColor = ConsoleColor.Red;
            TheLink.Rating();
            Console.ForegroundColor = ConsoleColor.Magenta;

            TheLink.Exit();

        }
        private static void LightExit()
        {
            Console.Clear();

            MenuInfo TheLink = new MenuInfo();
            TheLink.Head();

            TheLink.NewGame();

            TheLink.Continue();

            TheLink.Rating();
            Console.ForegroundColor = ConsoleColor.Red;

            TheLink.Exit();
            Console.ForegroundColor = ConsoleColor.Magenta;

        }
        private static void SelectPunct(int y)
        {
            Dummy TheLink = new Dummy();
            MenuInfo TheLink2 = new MenuInfo();
            NewGame TheLink3 = new NewGame();

            if (y == 0) TheLink3.StartNewGame();
            else if (y == 1) { TheLink.DummyContinue();}
            else if (y == 2) { TheLink.DummyRating();}
            else if (y == 3) TheLink.DummyExit();
        }
    }
}
