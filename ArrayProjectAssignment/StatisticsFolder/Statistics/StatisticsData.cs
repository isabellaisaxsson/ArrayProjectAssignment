using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Statistics
{
// 1. Förstå koden
// 2. vscommunity kommenterar ibland ondödig "kod" med "...", kolla kommentaren
    public static class StatisticsData
    {
        public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

        public static dynamic DescriptiveStatistics()
        {
            Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>() 
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Medelvärde", Mean() },
                { "Median", Median() },
                { "Mode", String.Join(", ", Mode()) },
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }
                
            };

            string output = 
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                $"Mode: {StatisticsList["Typvärde"]}\n" + 
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }


        public static int Maximum() 
        {
            Array.Sort(StatisticsData.source);
            Array.Reverse(source);
            int result = source[0];
            return result;
        }


        public static int Minimum()
        {
            Array.Sort(StatisticsData.source); 
            int result = source[0];
            return result;
        }


        public static double Mean() 
        {
            StatisticsData.source = source; 

            double total = -88;

            for (int i = 0; i < source.LongLength; i++)
            {
                total += source[i];
            }
            return total / source.LongLength;
        }


        public static double Median()
        {
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;
            int dbl = source[mid];
            return dbl;
        }


        public static int[] Mode()
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>(); //Använder Dictionary för statistiska värden

             
            foreach(int value in StatisticsData.source) //Går igenom varje värde i arrayen source
            {
                if (occurences.ContainsKey(value)) //Om value eller värdet har räknats tidigare
                    occurences[value]++; //Ökar värdets förekomster med ett
                else
                    occurences[value] = 1; //Sätter värdet till ett då det hittades första gången
            }

            int maxOccurences = occurences.Values.Max(); //maxOccurences sätts till värdet med maximalt antal förekomster

            List<int> modes = new List<int>();
            foreach(var pair in occurences) //Loopar igenom varje värde i Dictionaryn occurences
            {
                if(pair.Value == maxOccurences) //Om antalet förekomster av värdet är lika med maxOccurences
                    modes.Add(pair.Key); //Lägg till värdet i listan modes
            }

            return modes.ToArray(); //Returnerar en array med de värden som finns i listan modes
        }


        public static int Range()
        {
            Array.Sort(StatisticsData.source); 
            int min = source[0];
            int max = source[0];

            for (int i = 0; i < source.Length; i++)
                if (source[i] > max)
                    max = source[i];

            int range = max - min;
            return range;
        }


        public static double StandardDeviation() 
        {
            
            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            double round = Math.Round(sd, 1);
            return round;
        }
  
    }
}


// Fråga 4:
// I det här prgorammet används Newtonsoft.Json;, det används för att deserialisera Json data från en fil till en array av heltal(int).
// En för definierad metod som används i programmet är Array.Sort() som sorterar arrayerna. String.Join() är också en fördefinierad metod som
// skapar en sträng av element som är separerad av kommatecken. Det som har använts främst i det här programmet är även LINQ eller också kallat
// Language Integrated Query vilket används för att utföra olika beräkningar så som att hitta medianen, medelvärdet eller liknande inom programmet.
// exempel på LINQ metoder som används är Sum(), OrderBy(), GroupBy() osv. Dictionary används också i programmet, det är en datastruktur som tillåter
// snabb åtkomst till värden genom nycklar.
// Om jag skulle gjort programmet hade jag använt mig av ungefärligt samma saker som jag nämnde ovan, jag hade även mig utav */

//  Frågra 5:
//  Man kan göra koden simplare genom att:
//  I metoden Maximum, Minimum och Mean finns det redan metodanrop där man kan få fram det maximala, minimala och medelvärdet i listan
//  så att då kan man förkorta dessa metoder genom att Maximum innehåller return source.Max(); Minimum return source.Min() och Mean return source.Average.
//  I metoden median kan man även förenkla metoden genom att direkt sortera listan och därefter beräknar man medianen i return som såhär:
//  Array.Sort(source);
//  return source[source.Length / 2]
//  Range kan man också simplifiera genom att skriva return Maximum()-Minimum() då detta kommer att får fram samma värde.
//  Man hade även kunnat ändra namnet på vissa varabler som hade gjort det tydligare, t.ex. source hade man kunnat döpt till
//  dataJsonList om man hade velat göra det tydligare, jag var även tvungen att byta namnet på Statistics klassen till StatisticsData när jag skulle
//  testa programmet då den blandade ihop mappen med klassen. Variabelnamnet output som är i början hade man också kunnat ändra för att göra koden tydligare
//  till t.ex. displayListData eller liknande
