using System.Text.RegularExpressions;

namespace ResumeCraft.Domain.Utilities
{
    public static class CustomRegex
    {
        public const string Email = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public const string PhoneNumber = @"^\+(?:[0-9] ?){6,14}[0-9]$";
        public const string TemplateName = @"[/:\s]";
        public const string PdfFileName = @"[/:\s]";

        public static string Replace(string ex, string oldContent, string replaceValue)
        {
            return new Regex(ex).Replace(oldContent, replaceValue);
        }
    }
}
