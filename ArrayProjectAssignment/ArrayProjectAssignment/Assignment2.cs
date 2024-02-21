//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ArrayProjectAssignment
//{
//    class Assignment2 { 
    
//        public static void Main(string[] args)
//        {
//            string[] inputArray = { "renault", "volkswagen", "audi", "volvo", "dacia", "ala Romeo" };

//            for(char letter='A'; letter <= 'Z'; letter++)
//            {
//                List<string> filterList = FilterListLetter(inputArray, letter);

//                string directoryPath = Path.Combine(Environment.CurrentDirectory, $"{letter}_Directory");
//                Directory.CreateDirectory(directoryPath );

//                string filePath = Path.Combine(directoryPath, $"{letter}_list.txt");
//                File.WriteAllLines( filePath, filterList );

//                Console.WriteLine($"Filen sparades i: {filePath}" );
//            }
//        }

//        static List<string> FilterListLetter(string[] inputArray, char letter) 
//        { 
//            List<string> result = new List<string>();

//            foreach (string i in inputArray) 
//            {
//                if (i.StartsWith(char.ToLower(letter)))
//                {
//                    result.Add(i);
//                }
//            }

//            return result;
//        }
//    }
//}
