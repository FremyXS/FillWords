using System;
using System.Collections.Generic;
using System.Text;

namespace FillWordsNewVersion
{
    public class AllData
    {
        public static string Name; //имя
        public static List<string> Words = new List<string>(); //словарь слов
        public static int Koor = 5;//размер клетки
        public static List<string> AccWords = new List<string>();//слова для уровня
        public static string[,] ArrayTabl;//массив филлворда
        public static List<string> WordsList = new List<string>();
        public static List<string> Peremen = new List<string>();
        public static List<string> AllKoor = new List<string>();
        public static List<string> YandX = new List<string>();
        public static List<string> Zak = new List<string>();
        public static int lvl = 1;//уровень
        public static int Points = 0;//очки
        public static int x = 0;
        public static int y = 0;

    }
}
