using Game_library;
using System.IO;
using System;

namespace GameLibrary.Import.Txt
{
    public class TextFileStoreImporter
    {
        private readonly string _fileName;// non è possibile modificare l'oggetto a cui punta in memoria

        public TextFileStoreImporter(string fileName)
        {
            _fileName = fileName;
        }

       // #warning To be fixed <= serve a mettere un warnig che mi verrà letto per capire che devo fare qualcosa

        public Store[] GetStores()
        {
            string[] lines = File.ReadAllLines(_fileName);

            List<Store> result = new List<Store>();

            for (int i = 1; i<lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrEmpty(line)) //serve a non prendere le righe vuote
                { 
                    continue; 
                }
                //string[] parts = line.Split('|', StringSplitOptions.TrimEntries);  // diviso in basa al |
                //Uri? uri = string.IsNullOrEmpty(parts[2]) ? null : new Uri (parts[2]);  //trasformo la striga array part 2 in Uri
                //var store = new Store(parts[0], parts[1], uri);  //poteva essere così: (name: parts[0], description: parts[1], webSite: uri)
                result.Add(BuildStoreFromLine(line));
            }

            return result.ToArray();  // trasformare la lista in array
        }

        public Store[] GetStores2()
        {
            string[] lines = File.ReadAllLines(_fileName);

            // List<Store> result = new List<Store>();
            Store[] result = new Store[lines.Length-1];

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrEmpty(line)) //serve a non prendere le righe vuote
                {
                    continue;
                }
                string[] parts = line.Split('|', StringSplitOptions.TrimEntries);  // diviso in basa al |
                Uri? uri = string.IsNullOrEmpty(parts[2]) ? null : new Uri(parts[2]);  //trasformo la striga array part 2 in Uri
                var store = new Store(parts[0], parts[1], uri);  //poteva essere così: (name: parts[0], description: parts[1], webSite: uri)
                //result.Add(store);
                result[i - 1] = store;  //i-1 perchè abbiamo 1 elemento in meno visto che non prendiamo la testata
            }

            return result.Where(x => x is not null).ToArray();
        }

        public Store[] GetStores3() => //LinQ
            File
            .ReadAllLines(_fileName)
            .Skip(1) //quante righe si vuole saltare
            .Where(line => !string.IsNullOrEmpty(line)) //esclude tutte le righe vuote
            .Select //trasforma da una sequenza ad un altra
            (
                line =>
                {
                    string[] parts = line.Split('|', StringSplitOptions.TrimEntries);  // diviso in basa al |
                    Uri? uri = string.IsNullOrEmpty(parts[2]) ? null : new Uri(parts[2]);  //trasformo la striga array part 2 in Uri
                    return new Store(parts[0], parts[1], uri);  //poteva essere così: (name: parts[0], description: parts[1], webSite: uri)
                }
            )
            .ToArray();

        private static Store BuildStoreFromLine( string line )
        {
            string[] parts = line.Split('|', StringSplitOptions.TrimEntries);  // diviso in basa al |
            Uri? uri = string.IsNullOrEmpty(parts[2]) ? null : new Uri(parts[2]);  //trasformo la striga array part 2 in Uri
            return new Store(parts[0], parts[1], uri);  //poteva essere così: (name: parts[0], description: parts[1], webSite: uri)
        }
    }
}
