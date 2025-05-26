using System.Globalization;

namespace OOP_LibraryManagement.Ultis
{
    public class ObjectUltis
    {
        public static readonly string DateFormat = "dd/MM/yyyy";
        public static readonly string DVDRunTimeFormat = "HH:mm:ss";

        public static DateTime ValidPulicationYear(string prompt, string ErrorMsg)
        {
            DateTime result;
            do
            {
                Console.Write($"{prompt} ({DateFormat}): ");
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, DateFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out result))
                {
                    return result;
                }
                GlobalUltis.PrintError($"-> {ErrorMsg}, follow ({DateFormat})");
            }
            while (true);
        }

        public static TimeOnly ValidDVDRunTime(string prompt, string ErrorMsg)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string input = Console.ReadLine();

                if (TimeOnly.TryParseExact(input, DVDRunTimeFormat, null, System.Globalization.DateTimeStyles.None,
                    out TimeOnly runTime))
                {
                    return runTime;
                }
                else
                {
                    GlobalUltis.PrintError(ErrorMsg);
                }
            }
        }
    }
}
