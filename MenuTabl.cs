using System;

namespace Menu
{
    public class MenuTabl
    {

        public void MenuInfo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WindowWidth = 200;

            Head();

            NewGame();

            Continue();

            Rating();

            Exit();



        }
        public void Head()
        {
            Console.WriteLine(new String('\n', 3));


            Console.WriteLine($"{new String(' ', 47)} ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄            ▄            ▄         ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄\n"

                           + $"{new String(' ', 47)}▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌          ▐░▌          ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌\n"
                           + $"{new String(' ', 47)}▐░█▀▀▀▀▀▀▀▀▀  ▀▀▀▀█░█▀▀▀▀ ▐░▌          ▐░▌          ▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ \n"
                           + $"{new String(' ', 47)}▐░▌               ▐░▌     ▐░▌          ▐░▌          ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌          \n"
                           + $"{new String(' ', 47)}▐░█▄▄▄▄▄▄▄▄▄      ▐░▌     ▐░▌          ▐░▌          ▐░▌   ▄   ▐░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ \n"
                           + $"{new String(' ', 47)}▐░░░░░░░░░░░▌     ▐░▌     ▐░▌          ▐░▌          ▐░▌  ▐░▌  ▐░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌\n"
                           + $"{new String(' ', 47)}▐░█▀▀▀▀▀▀▀▀▀      ▐░▌     ▐░▌          ▐░▌          ▐░▌ ▐░▌░▌ ▐░▌▐░▌       ▐░▌▐░█▀▀▀▀█░█▀▀ ▐░▌       ▐░▌ ▀▀▀▀▀▀▀▀▀█░▌\n"
                           + $"{new String(' ', 47)}▐░▌               ▐░▌     ▐░▌          ▐░▌          ▐░▌▐░▌ ▐░▌▐░▌▐░▌       ▐░▌▐░▌     ▐░▌  ▐░▌       ▐░▌          ▐░▌\n"
                           + $"{new String(' ', 47)}▐░▌           ▄▄▄▄█░█▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌░▌   ▐░▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌      ▐░▌ ▐░█▄▄▄▄▄▄▄█░▌ ▄▄▄▄▄▄▄▄▄█░▌\n"
                           + $"{new String(' ', 47)}▐░▌          ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌     ▐░░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌\n"
                           + $"{new String(' ', 47)} ▀            ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀       ▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀ ");


        }
        public void NewGame()
        {

            Console.WriteLine(new String('\n', 5));

            Console.WriteLine($"{new String(' ', 87)} _  _               ___                 ");
            Console.WriteLine($"{new String(' ', 87)}| \\| |_____ __ __  / __|__ _ _ __  ___");
            Console.WriteLine($"{new String(' ', 87)}| .` / -_) V  V / | (_ / _` | '  \\/ -_)");
            Console.WriteLine($"{new String(' ', 87)}|_|\\_\\___|\\_/\\_/   \\___\\__,_|_|_|_\\___|");
        }
        public void Continue()
        {

            Console.WriteLine(new String('\n', 1));

             Console.WriteLine($"{new String(' ', 90)}  ___         _   _\n"              
                             + $"{new String(' ', 90)} / __|___ _ _| |_(_)_ _ _  _ ___ \n"
                             + $"{new String(' ', 90)}| (__/ _ \\ ' \\  _| | ' \\ || / -_)\n"
                             + $"{new String(' ', 90)} \\___\\___/_||_\\__|_|_||_\\_,_\\___|");
        }
        public void Rating()
        {
            Console.WriteLine(new String('\n', 1));

            Console.WriteLine($"{new String(' ', 94)} ___      _   _     \n"
                            + $"{new String(' ', 94)}| _ \\__ _| |_(_)_ _  __ _ \n"
                            + $"{new String(' ', 94)}|   / _` |  _| | ' \\/ _` |\n"
                            + $"{new String(' ', 94)}|_|_\\__,_|\\__|_|_||_\\__, |\n"
                            + $"{new String(' ', 94)}                    | ___/ ");
        }
        public void Exit()
        {
            Console.WriteLine(new String('\n', 1));

            Console.WriteLine($"{new String(' ', 100)} ___     _ _ \n"
                            + $"{new String(' ', 100)}| __|_ _(_) | _ \n"
                            + $"{new String(' ', 100)}| _|\\ \\\\ / |  _|\n"
                            + $"{new String(' ', 100)}|___/_\\_\\_|\\__|");
        }

    }
}
