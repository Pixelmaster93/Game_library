using Game_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Import.Txt
{
    public class TextFileGameImporter
    {
        private readonly string _fileName;

        public TextFileGameImporter(string fileName)
        {
            _fileName = fileName;
        }
        public Game[] GetGames() =>
            File
            .ReadAllLines(_fileName)
            .Skip(1)
            .Where(line => !string.IsNullOrEmpty(line))
            .Distinct()//importa le cose 1 volta sola, eliminando le cose ripetute
            .Select
            (
                line =>
                {
                    string[] parts = line.Split('|', StringSplitOptions.TrimEntries);
                    string[] tag = parts[2].Split(',', StringSplitOptions.TrimEntries);
                    return new Game(parts[0], parts[1], tag); 
                }
            )
            .ToArray();
    }
}
