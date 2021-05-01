using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogPlatformApp.Helpers
{
    public static class StringFormatter
    {
        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        } 

        public static string Format(string text)
        {
            string s;
            s = text.ToLower().Normalize(NormalizationForm.FormD);
            s = Regex.Replace(s, @"\s+", "-");
            s = Regex.Replace(s, "[^0-9A-Za-z -]", "");
            s = RemoveDiacritics(s);
            return s;
        }
    }
}
