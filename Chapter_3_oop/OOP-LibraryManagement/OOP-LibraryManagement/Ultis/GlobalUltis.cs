using System.Globalization;
using System.Text.RegularExpressions;

namespace OOP_LibraryManagement.Ultis
{
    public class GlobalUltis
    {
        public static readonly string ERROR_EMPTY_LIST = "The list is empty";
        public static readonly string ERROR_ADDING_ITEM = "Error while adding {0} to list - {1}";
        public static readonly string ERROR_DISPLAY_LIST = "Error while display list of {0} - {1}";
        public static readonly string ERROR_SEARCH_TITLE = "Error while searching by title - {0}";
        public static readonly string ERROR_DISPLAY_ITEMS = "Error while displaying items - {0}";
        public static readonly string ERROR_INVALID_INPUT = "Invalid input, Try Again";
        public static int GetInt(string prompt, string ErrorMsg)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return -1;
            }

            while (!Regex.IsMatch(input, @"^\d+$"))
            {
                PrintError(ErrorMsg);

                Console.Write($"{prompt}: ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return -1;
                }
            }
            return int.Parse(input);
        }

        public static string GetString(string prompt, string ErrorMsg)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return "";
            }

            while (!Regex.IsMatch(input, @"^[\p{L} .'-]+$"))
            {
                PrintError(ErrorMsg);

                Console.Write($"{prompt}: ");
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return "";
                }
            }
            return input;
        }

        public static double GetDouble(string prompt, string ErrorMsg)
        {
            Console.Write($"{prompt}: ");
            string input = Console.ReadLine();

            while (!Regex.IsMatch(input, @"^\d+(\.\d+)?$"))
            {
                PrintError(ErrorMsg);
                Console.Write($"{prompt}: ");
                input = Console.ReadLine();
            }

            return double.Parse(input);
        }
        public static bool GetBoolean(string prompt, string ErrorMsg)
        {
            Console.Write($"{prompt} (true/false): ");
            string input = Console.ReadLine();

            while (!input.Equals("true", StringComparison.OrdinalIgnoreCase) &&
                   !input.Equals("false", StringComparison.OrdinalIgnoreCase))
            {
                PrintError(ErrorMsg);

                Console.Write($"{prompt} (true/false): ");
                input = Console.ReadLine();
            }

            return bool.Parse(input.ToLower());
        }

        public static string NormalizeName(string name)
        {
            string cleanedName = Regex.Replace(name.ToLower(), @"[^\p{L}\d\s]", "").Trim();

            cleanedName = Regex.Replace(cleanedName, @"[,\\s]+", " ");

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(cleanedName);
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"-> {message}");
            Console.ResetColor();
        }

        public static void PrintSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"-> {message}");
            Console.ResetColor();
        }
    }
}

