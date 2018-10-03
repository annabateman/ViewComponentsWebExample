using System.Text.RegularExpressions;

namespace ViewComponentsWebExample {
    public static class StringExtensionMethods {
        public static string CamelCaseToWords(this string input) => Regex.Replace(input, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ");
    }
}
