using Game_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Import.Txt
{
    internal class TextFileGameImporter
    {
        private readonly string _fileName;

        public TextFileGameImporter(string fileName)
        {
            _fileName = fileName;
        }
        public Game[] GetGame() =>
            File
            .ReadAllLines(_fileName)
            .Skip(1)
            .Where(line => !string.IsNullOrEmpty(line))
            .Select
            (
                line =>
                {
                    string[] parts = line.Split('|', StringSplitOptions.TrimEntries);
                    string[] tag = parts[2].Split(',' )
                    return new Game(parts[0], parts[1], parts[2]); 
                }
            )
            .ToArray();
    }
}
