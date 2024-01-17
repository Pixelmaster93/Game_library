using Game_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Import.Txt
{
    public class TextFilePlatformImporter
    {
        private readonly string _fileName;

        public TextFilePlatformImporter(string fileName)
        {
            _fileName = fileName;
        }
        public Platform[] GetPlatforms() =>
            File
            .ReadAllLines(_fileName)
            .Skip(1)
            .Where(line => !string.IsNullOrEmpty(line)) 
            .Select
            (
                line =>
                {
                    string[] parts = line.Split('|', StringSplitOptions.TrimEntries);
                    return new Platform(parts[0], parts[1]);
                }
            )
            .ToArray();
    }
}
