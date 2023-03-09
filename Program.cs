namespace PermutationsAssignment
{
    internal class Program
    {
        static char[] characters;
        const int characterAmount = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 5 individual characters");
            GetCharacters();
            PrintCharacters();
            Console.WriteLine("==============================");
            for(int i = 1; i < characterAmount + 1; i++)
            {
                Console.WriteLine($"5P{i}   count: " + PermuteCount(5, i));
            }

            Console.WriteLine(PermuteCharacters());
            Console.ReadKey();
        }

        // I dont think this works correctly
        static string PermuteCharacters(int index = 0, int[]? current = null, string total = null)
        {
            if(index >= characterAmount)
            { return total; }

            if(current == null)
            {
                current = new int[characterAmount];
                for(int i = 0; i < current.Length; i++)
                { current[i] = 0; }
            }

            char[] permutation = new char[characterAmount];
            for(int i = 0; i < characterAmount - 1; i++)
            {
                for (int j = 0; j < characterAmount; j++) //go from int indeces -> chars
                {
                    permutation[j] = characters[current[j]];
                }
                total += " [" + new string(permutation) + "] ";
                current[index]++;
            }

            if(index == characterAmount - 1) //hack.  This algorithm skips the last one so i need to fill it in manually
            {
                permutation[characterAmount - 1] = characters[current[characterAmount - 1]];
                total += " [" + new string(permutation) + "] ";
            }

            return PermuteCharacters(index + 1, current, total);
        }

        static int PermuteCount(int n, int r)
        {
            return FactorialCount(n) / FactorialCount(n - r);
        }

        static int FactorialCount(int number) { return FactorialCount(number, number); }
        static int FactorialCount(int number, int total)
        {
            if(number <= 1)
            { return total == 0 ? 1 : total; }
            total *= number - 1;
            return FactorialCount(number - 1, total);
        }

        static void PrintCharacters()
        {
            Console.Write("\n Characters: ");
            foreach(char c in characters)
            {
                Console.Write(" [" + c + "] ");
            }
        }

        static void GetCharacters()
        {
            characters = new char[characterAmount];
            int index = 0;

            while(index < characters.Length)
            {
                string? input = Console.ReadLine();

                if(input == null || input.Length != 1)
                { Console.WriteLine("Error: Enter one character"); continue; }

                characters[index] = input[0];
                index++;
            }
        }
    }
}