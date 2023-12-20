namespace assignment3part2
{
            class Programm
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter a string:");
                string input = Console.ReadLine();

                try
                {
                    CheckForVowels(input);
                    Console.WriteLine("The string contains vowels.");
                }
                catch (NoVowelsException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            static void CheckForVowels(string input)
            {
                if (!ContainsVowels(input))
                {
                    throw new NoVowelsException("The string does not contain any vowels.");
                }
            }

            static bool ContainsVowels(string input)
            {
                string vowels = "AEIOUaeiou";

                foreach (char c in input)
                {
                    if (vowels.Contains(c))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        class NoVowelsException : Exception
        {
            public NoVowelsException(string message) : base(message)
              {
              }
        }
    }
