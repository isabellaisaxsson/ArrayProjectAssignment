using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Statistics
{

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
                /*{ "Typvärde", String.Join(", ", Mode()) }, */
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }
                
            };

            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                /*$"Typvärde: {StatisticsList["Typvärde"]}\n" +*/
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
