using Game_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Import.Txt
{
    public class TextFileTransactionImporter
    {
        private readonly string _fileName;
        private readonly Game[] _games;
        private readonly Store[] _stores;
        private readonly Platform[] _platforms;

        public TextFileTransactionImporter(string fileName, Game[] games, Store[] stores, Platform[] platforms)
        {
            _fileName = fileName;
            _games = games;
            _stores = stores;
            _platforms = platforms;
        }

        public Transaction[] GetTransaction() =>
            File
            .ReadAllLines(_fileName)
            .Skip(1)
            .Where(line => !string.IsNullOrEmpty(line))
            .Distinct()
            .Select(BuildTransactionFromLine)
            .ToArray;

        private Transaction BuildTransactionFromLine(string line)
        {
            string[] parts = line.Split('|', StringSplitOptions.TrimEntries);
            DateTime PurchaseDate = ParseData(parts[0]);
            bool isVirtual = ParseBool(parts[1]);

            Store? store = GetStoreFromName(parts[2]);
            if (store is null)
            {
                throw
                    new Exception($"The store {parts[2]} does not exist");
            }

            Game? game = GetGameeFromName(parts[3]);
            if (store is null)
            {
                throw
                    new Exception($"The game {parts[3]} does not exist");
            }

            Platform? platform = GetPlatformFromName(parts[4]);
            if (store is null)
            {
                throw
                    new Exception($"The store {parts[4]} does not exist");
            }

            return new Transaction(PurchaseDate, isVirtual, store, game, platform, price, currency);
        }

        private static DateTime ParseData(string line) =>
            DateTime.ParseExact(line, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

        private static bool ParseBool(string line) =>
            bool.Parse(line);

        /*
         * CLASSICO
         * 
        private Store? GetStoreFromName_classic(string name)
        {
            
             foreach (var store in _stores)
             {
                if (string.Equals(store.Name, name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return store; 
                }
             }
             return null;
        }
        */

        private Store? GetStoreFromName(string name) =>
            _stores
            .FirstOrDefault(s => string.Equals( s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        private Game? GetGameeFromName(string name) =>
            _games
            .FirstOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        private Platform? GetPlatformFromName(string name) =>
            _platforms
            .FirstOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

    }
}
