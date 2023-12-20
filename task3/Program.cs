namespace assignment3
{
    internal class Program
    {

            static void Main(string[] args)
            {
                Console.WriteLine("Enter a list of integers (separated by commas):");
                string input = Console.ReadLine();

                List<int> numbers = new List<int>();

                try
                {
                    string[] numberStrings = input.Split(',');
                    foreach (string numberString in numberStrings)
                    {
                        int number = int.Parse(numberString.Trim());

                        if (numbers.Contains(number))
                        {
                            throw new ArgumentException("Duplicate numbers are not allowed.");
                        }

                        numbers.Add(number);
                    }

                    Console.WriteLine("No duplicates found.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter only integers separated by commas.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

