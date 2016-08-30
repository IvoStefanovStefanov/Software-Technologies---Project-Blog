using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biliana_Georgieva_Blog.Classes
{
    public class Utils
    {
        public static string CutText (string text, int MaxLength = 100 )
        {
            if (text == null || text.Length <= MaxLength)
                return text;
            var ShortText = text.Substring(0, MaxLength) + "....";
            return ShortText;
        }
    }
}
