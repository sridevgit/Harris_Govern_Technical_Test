using System;
using System.Collections.Generic;
using System.Linq;

namespace Harris_Govern_Technical_Test
{
    class Program
    {
        static void Main(string[] partNumbers)
        {
            int numberOfArguments = partNumbers.Length;

            if (numberOfArguments > 0)
            {
                List<string> result = new List<string>();
                foreach (var partNumber in partNumbers)
                {
                    result.AddRange(GetParts(partNumber, result));
                }
                

                foreach (var partNumber in result)
                {
                    Console.WriteLine(partNumber);
                    // Not implemented method
                    CreateIndividualPartNumber(partNumber);
                }
            }
            else
            {
                Console.WriteLine("No arguments were passed.");
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        public static List<string> GetParts(string partNumber, List<string> result)
        {
            List<string> partNumbersResult = new List<string>();
            var partNumberSplit = partNumber.Split('-').Where(x => !string.IsNullOrEmpty(x)).ToList();

            if (partNumberSplit.Count > 1)
            {
                var parent = partNumberSplit.First();
                if (!result.Contains(parent) && !partNumbersResult.Contains(parent))
                {
                    partNumbersResult.Add(parent);
                }
                string lastParent = string.Empty;
                for (int i = 0; i < partNumberSplit.Except(new List<string> { parent }).ToList().Count; i++)
                {
                    lastParent = BuildParent(partNumberSplit.Except(new List<string> { parent }).ToList(), i, string.IsNullOrEmpty(lastParent) ? parent : lastParent);
                    if (!result.Contains(lastParent) && !partNumbersResult.Contains(lastParent))
                    {
                        partNumbersResult.Add(lastParent);
                    }
                }

            }
            else if (partNumberSplit.Count > 0)
            {
                // just check if value exists in the list if not add
                if (!result.Contains(partNumberSplit.First().Trim()))
                {
                    partNumbersResult.Add(partNumberSplit.First().Trim());
                }
            }

            return partNumbersResult;

        }

        public static string BuildParent(List<string> children, int childIndexToConcat, string parent)
        {
            return parent + "-" + children[childIndexToConcat];
        }

        static void CreateIndividualPartNumber(string partNumber)
        {

        }


    }
}
