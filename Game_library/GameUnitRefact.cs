
using Game_library;
using System.Globalization;
using System.Text;

namespace Game_library;

public static class GameUnitRefact
{
    public static string CreateGameID(string name)
    {
        //if (name is null) throw new ArgumentNullException(nameof(name));
        ArgumentNullException.ThrowIfNull(name); //uguale a sopra
        
        return name.Trim().Trim(['-','_']).Replace(' ', '-').Replace('_', '-').ToUpper().RemoveAccent().ReplaceChar();
    }

    private static string RemoveAccent(this string input)
    {
        string result = new string(input.Normalize(NormalizationForm.FormD)
        .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
         .ToArray());

        return result;
    }
    
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