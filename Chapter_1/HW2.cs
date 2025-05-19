// A utility to analyze text files and provide statistics
namespace FileAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Analyzer - .NET Core");
            Console.WriteLine("This tool analyzes text files and provides statistics.");

            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file path as a command-line argument.");
                Console.WriteLine("Example: dotnet run myfile.txt");
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
                return;
            }

            try
            {
                Console.WriteLine($"Analyzing file: {filePath}");

                // Read the file content
                string content = File.ReadAllText(filePath);

                // TODO: Implement analysis functionality
                // 1. Count words
                // 2. Count characters (with and without whitespace)
                // 3. Count sentences
                // 4. Identify most common words
                // 5. Average word length

                // Example implementation for counting lines:
                int lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine($"Number of lines: {lineCount}");

                // TODO: Additional analysis to be implemented
                // 1. Count Word
                countWord(content);

                // 2. Count Character
                countCharacter(content);

                // 3. Count sentences
                countSentences(content);

                // 4. Identify most common words
                identifyMostCommonWords(content);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during file analysis: {ex.Message}");
            }
        }

        public static void countWord(string content)
        {
            try
            {
                var word = content.Split(' ', '\n', '\t', '\r');
                Console.WriteLine($"Word in file: {word.Length}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while counting word: {e.ToString()}");
            }
        }

        public static void countCharacter(string content)
        {
            int cCount = 0;
            try
            {
                Console.WriteLine($"Number of character with white space: {content.Length}");

                cCount = content.Count(c => !char.IsWhiteSpace(c));
                Console.WriteLine($"Number of character without white space: {cCount}");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while counting: {e.ToString}");
            }
        }

        public static void countSentences(string content)
        {
            try
            {
                var sentences = content.Split(new char[] { '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine($"Sentences in file: {sentences.Length}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while counting sentences: {e.ToString()}");
            }
        }

        public static void identifyMostCommonWords(string content)
        {
            try
            {
                string[] words = content.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; i++)
                {
                    words[i] = words[i].Trim().ToLower();
                }

                Dictionary<string, int> wordCount = new Dictionary<string, int>();

                foreach (string word in words)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount[word] = 1;
                    }
                }

                var sortedWord = wordCount.OrderByDescending(w => w.Value);

                Console.WriteLine("How many word you want to see the occurences ?");
                int loop = int.Parse(Console.ReadLine());
                Console.WriteLine("Most common word");

                int count = 0;

                foreach (var pair in sortedWord)
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value} occurences");
                    count++;
                    if (count == loop) break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while identifying common words: {e.Message}");
            }
        }
    }
}