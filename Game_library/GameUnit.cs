
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Game_library;

public class GameUnit
{
    public static string SubstituctionString(string name)
    {

        if (name is null) throw new ArgumentNullException(nameof(name));

        name = name.ToUpper().Trim();
        name = RemuveAccent(name);

        static string RemuveAccent(string input)
        {
            string result = new string(input.Normalize(NormalizationForm.FormD)
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
             .ToArray());

            return result;
        }

        name = name.Replace(' ', '-').Replace('_', '-').Replace("&", "AND");

        string gameID = string.Empty;

        foreach (char c in name)
        {
            if (char.IsLetterOrDigit(c))
            {
                gameID += c; //va ad aggiungere il carattere passato nel gameID
            }
            if ( c == '-' )
            {
                gameID += c;
            }
        }
        return name;
    }
    


}

