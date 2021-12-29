using System.Linq;

namespace AdvancedCourse
{
    public static class StringExtension 
    {
        // Extension methods allow us to add methods to an exisiting class without changing it's source code or creating a
        // new class that inherits from it. Important thing regarding extension method is it comes to existence when the
        // class that created it is in scope.

        // First method of Extension method will always be "this type_of_argument variable_name". We want to add extension
        // method to "string" clas hence type_of_argument is string.
        public static string ShortenTheString(this string str, int numberOfWords)
        {
            if (str == null || numberOfWords == 0) return "";

            var words = str.Split(' ');

            if (words.Length <= numberOfWords) return str;
            
            // Take() is an inbuilt extension method of "string" class.
            return string.Join(" ", words.Take(numberOfWords)) + "...";
        }
    }
}
