
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

        foreach (char c in name)
        {
            //if (c == '_' && c == 'c')
            //{
            //}
            if ((char.IsLetterOrDigit(c) || c == '&') || (c == '-' && c != c-1))
            {
                gameID += c;
            }
            
        }
        return gameID;
    }

}