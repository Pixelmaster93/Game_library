
using Game_library;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace Game_library;

public static class GameUnitRefact
{
    //public static string CreateGameID(this Game game) =>
    //   CreateGameID(game?.Name!);

    public static string CreateGameID(this Game game)
    {
        ArgumentNullException.ThrowIfNull(game);

        return CreateGameID(game.Name);
    }

    public static string CreateGameID(string name)
    {
        //if (name is null) throw new ArgumentNullException(nameof(name));
        ArgumentNullException.ThrowIfNull(name); //uguale a sopra
        
        //faccio ritornare name senza spazi e senza trattinoi ad inizio e fine, rimpiazzo gli spazi e i trattini bassi con il trattino, metto tutto maiuscolo e utilizzo il metodo per rimuovere gli accenti e per rimpiazzare i caratteri
        return 
            name
            .Trim(['-','_', ' ', '\t'])
            .Replace(' ', '-')
            .Replace('_', '-')
            .ToUpper()
            .RemoveAccent()
            .ReplaceChar();
    }

    //rimuovegli accenti dalla stringa
    private static string RemoveAccent(this string input)
    {
        string result = new string(input.Normalize(NormalizationForm.FormD)
        .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
         .ToArray());

        return result;
    }
    
    //elimina i caratteri non ammessi
    private static string ReplaceChar(this string name)
    {
        string gameID = string.Empty;
        char temp  = '-'; // creo un char temporaneo, il - è come viene inizializato temp
        foreach (char c in name)
        {
            if ((char.IsLetterOrDigit(c) || c == '&') || (c == '-' && c != temp))//se c è nei caratteri consentiti, o è = a & passa, poi se è = a - e temp è diverso da c passa
            {
                gameID += c;
                temp = c;//ogni volta che il ciclo passa i controlli riscrive temp cosi da avere sempre il carattere passato prima
            }
            
        }
        return gameID;
    }

}