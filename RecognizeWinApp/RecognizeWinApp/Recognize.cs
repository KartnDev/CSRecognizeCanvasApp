﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecognizeWinApp
{
    public static class KNNClassifier //KNearestNeighbor
    {
        //converts string representation of number to a double
        public static IEnumerable<double> ConvertToDouble<T>(this IEnumerable<T> array)
        {
            dynamic ds;
            foreach (object st in array)
            {
                ds = st;
                yield return Convert.ToDouble(ds);
            }
        }

        //returns a row in a 2D array
        public static T[] Row<T>(this T[,] array, int r)
        {
            T[] output = new T[array.GetLength(1)];
            if (r < array.GetLength(0))
            {
                for (int i = 0; i < array.GetLength(1); i++)
                    output[i] = array[r, i];
            }
            return output;
        }

        //converts a List of Lists to a 2D matrix
        public static T[,] ToMatrix<T>(this IEnumerable<List<T>> collection, int depth, int length)
        {
            T[,] output = new T[depth, length];
            int i = 0, j = 0;
            foreach (var list in collection)
            {
                foreach (var val in list)
                {
                    output[i, j] = val;
                    j++;
                }
                i++; j = 0;
            }

            return output;
        }

        //returns the classification that appears most frequently in the array of classifications
        public static string Majority<T>(this T[] array)
        {
            if (array.Length > 0)
            {
                int unique = array.Distinct().Count();
                if (unique == 1)
                    return array[0].ToString();

                return (from item in array
                        group item by item into g
                        orderby g.Count() descending
                        select g.Key).First().ToString();
            }
            else
                return "";
        }
    }

    /// <summary>
    /// kNN class implements the K Nearest Neighbor instance based classifier
    /// </summary>
    public sealed class kNN
    {
        //private constructor allows to ensure k is odd
        private kNN(int K, string FileName, bool Normalise)
        {
            k = K;
            PopulateDataSetFromFile(FileName, Normalise);
        }

        /// <summary>
        /// Initialises the kNN class, the observations data set and the number of neighbors to use in voting when classifying
        /// </summary>
        /// <param name="K">integer representiong the number of neighbors to use in the classifying instances</param>
        /// <param name="FileName">string file name containing knows numeric observations with string classes</param>
        /// <param name="Normalise">boolean flag for normalising the data set</param>
        public static kNN initialiseKNN(int K, string FileName, bool Normalise)
        {
            if (K % 2 > 0)
                return new kNN(K, FileName, Normalise);
            else
            {
                Console.WriteLine("K must be odd.");
                return null;
            }
        }

        //read-only properties
        internal int K { get { return k; } }
        internal Dictionary<List<double>, string> DataSet { get { return dataSet; } }

        /// <summary>
        /// Classifies the instance according to a kNN algorithm
        /// calculates Eucledian distance between the instance and the know data
        /// </summary>
        /// <param name="instance">List of doubles representing the instance values</param>
        /// <returns>returns string - classification</returns>
        internal string Classify(List<double> instance)
        {
            int i = 0;
            double[] normalisedInstance = new double[length];

            if (instance.Count != length)
            {
                return "Wrong number of instance parameters.";
            }

            if (normalised)
            {
                foreach (var one in instance)
                {
                    normalisedInstance[i] = (one - originalStatsMin.ElementAt(i)) / (originalStatsMax.ElementAt(i) - originalStatsMin.ElementAt(i));
                    i++;
                }
            }
            else
            {
                normalisedInstance = instance.ToArray();
            }

            double[,] keyValue = dataSet.Keys.ToMatrix(depth, length);
            double[] distances = new double[depth];

            Dictionary<double, string> distDictionary = new Dictionary<double, string>();
            for (i = 0; i < depth; i++)
            {
                distances[i] = Math.Sqrt(keyValue.Row(i).Zip(normalisedInstance, (one, two) => (one - two) * (one - two)).ToArray().Sum());
                distDictionary.Add(distances[i], dataSet.Values.ToArray()[i]);

            }

            //select top votes
            var topK = (from d in distDictionary.Keys
                        orderby d ascending
                        select d).Take(k).ToArray();

            //obtain the corresponding classifications for the top votes
            var result = (from d in distDictionary
                          from t in topK
                          where d.Key == t
                          select d.Value).ToArray();

            return result.Majority();
        }
        /// <summary>
        /// Processess the file with the comma separated training data and populates the dictionary
        /// all values except for the class must be numeric
        /// the class is the last element in the dataset for each record
        /// </summary>
        /// <param name="fileName">string fileName - the name of the file with the training data</param>
        /// <param name="normalise">bool normalise - true if the data needs to be normalised, false otherwiese</param>
        private void PopulateDataSetFromFile(string fileName, bool normalise)
        {
            using (StreamReader sr = new StreamReader(fileName, true))
            {
                List<string> allItems = sr.ReadToEnd().TrimEnd().Split('\n').ToList();

                if (allItems.Count > 1)
                {
                    string[] array = allItems.ElementAt(0).Split(',');
                    length = array.Length - 1;
                    foreach (string item in allItems)
                    {
                        array = item.Split(',');
                        dataSet.Add(array.Where(p => p != array.Last()).ConvertToDouble().ToList(), array.Last().ToString().TrimEnd());
                    }
                    array = null;
                }
                else
                    Console.WriteLine("No items in the data set");
            }
            if (normalise)
            {
                NormaliseDataSet();
                normalised = true;
            }
        }

        private void NormaliseDataSet()
        {
            var keyCollection = from n in dataSet.Keys
                                select n;
            var valuesCollection = from n in dataSet.Values
                                   select n;

            depth = dataSet.Keys.Count;
            double[,] transpose = new double[length, depth];
            double[,] original = new double[depth, length];
            int i = 0, j = 0;

            //transpose
            foreach (var keyList in keyCollection)
            {
                foreach (var key in keyList)
                {
                    transpose[i, j] = key;
                    i++;
                }
                j++; i = 0;
            }

            //normalise
            double max, min;

            for (i = 0; i < length; i++)
            {
                originalStatsMax.Add(max = transpose.Row(i).Max());
                originalStatsMin.Add(min = transpose.Row(i).Min());

                for (j = 0; j < depth; j++)
                {
                    transpose[i, j] = (transpose[i, j] - min) / (max - min);
                }

            }
            for (i = 0; i < depth; i++)
            {
                for (j = 0; j < length; j++)
                    original[i, j] = transpose[j, i];
            }

            //overwrite the current values with the normalised ones
            dataSet = new Dictionary<List<double>, string>();
            for (i = 0; i < depth; i++)
            {
                dataSet.Add(original.Row(i).ToList(), valuesCollection.ElementAt(i));
            }
        }

        //private members
        private Dictionary<List<double>, string> dataSet = new Dictionary<List<double>, string>();
        private List<double> originalStatsMin = new List<double>();
        private List<double> originalStatsMax = new List<double>();
        private int k = 0;
        private int length = 0;
        private int depth = 0;
        private bool normalised = false;
    }

}
