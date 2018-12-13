using System;
using System.IO;

namespace Console_Hero_Game
{
    // Here will be service class for different purposes
    public static class Utils
    {
        // Array for holding latin letters, which will be used in Monster Name generation
        public static readonly char[] latinLetters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                                                         'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        // Path to a \Documents\Hero save folder
        public static string pathDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string pathFolder = Path.Combine(pathDoc, "Hero save");
    }
}