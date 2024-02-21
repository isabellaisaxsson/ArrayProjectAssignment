//using System;
//using System.Collections.Generic;

//class Program
//{
//    public static void Main()
//    {
//        string[] inputArray = { "renault", "volkswagen", "audi", "volvo", "dacia", "alfa Romeo" };

//        List<string> filteredList = FilterString(inputArray);

//        Console.WriteLine("Element som börjar på A:");
//        foreach (string item in filteredList)
//        {
//            Console.WriteLine(item);
//        }

//        string directoryPath = Path.Combine(Environment.CurrentDirectory, "A_Directory");
//        Directory.CreateDirectory(directoryPath);

//        string filePath = Path.Combine(directoryPath, "a_list.txt");
//        File.WriteAllLines(filePath, filteredList);

//        Console.WriteLine($"Filen har sparats i {filePath}");
//    }

//    static List<string> FilterString(string[] inputArray)
//    {
//        List<string> resultList = new List<string>();

//        foreach (string item in inputArray)
//        {
//            if (item.StartsWith("a", StringComparison.OrdinalIgnoreCase)) // Ignorera skillnader mellan små och stora bokstäver
//            {
//                resultList.Add(item);
//            }
//        }

//        return resultList;
//    }

//    }