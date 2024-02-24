using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProjectAssignment
{
    class Program
    {

        public static void Main(string[] args)
        {
            string[] inputArray = { "renault", "volkswagen", "audi", "volvo", "dacia", "ala Romeo" }; //Skapar en array string med bilmärken inom sig.

            for (char letter = 'A'; letter <= 'Z'; letter++) //for loop som loopar mellan bokstäverna i alfabetet.
            {
                List<string> filterList = FilterListLetter(inputArray, letter); //Skapar en lista med filtrerade element som matchar den aktuella bokstaven.

                string directoryPath = Path.Combine(Environment.CurrentDirectory, $"{letter}_Directory");
                Directory.CreateDirectory(directoryPath); //Skapar en mapp i den aktuella arbetsmappen med den aktuella bokstaven och _Directory vid namn.

                string filePath = Path.Combine(directoryPath, $"{letter}_list.txt");
                File.WriteAllLines(filePath, filterList); //Skapar en txt fil inom den mappen som skapades med den aktuella bokstaven som namn och _list.

                Console.WriteLine($"Filen sparades i: {filePath}"); //Därefter skrivs det ut i konsollen att Filen sparades i och därefter pathen till filen.
            }
        }

        static List<string> FilterListLetter(string[] inputArray, char letter)
        {
            List<string> result = new List<string>(); //Skapar en ny lista vid namn result.

            foreach (string i in inputArray) //Foreach loop som går igenom varje sträng i arrayen inputArray. 
            {
                if (i.StartsWith(char.ToLower(letter))) //Kontrollerar om strängen börjar som samma bokstav som den aktuella strängen
                {
                    result.Add(i); //Om strängen börjar med den aktuella bokstaven läggs den till i listan
                }
            }

            return result;
        }
    }
}