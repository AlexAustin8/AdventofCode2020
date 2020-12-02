using System.Collections.Generic;
using System.IO;

namespace AdventofCode.BusinessLogic.Day1
{
    /// <summary>
    /// 2020 Advent of Code Day 1 Problem 1
    /// </summary>
    public class ResortRepair
    {
        /// <summary>
        /// ExpenseReport Input
        /// </summary>
        private List<int> ExpenseReport { get; set; }

        /// <summary>
        /// The Sum to be be found from expense report items
        /// </summary>
        private int DesiredSum { get; set; }

        public ResortRepair(string filePath, int desiredSum)
        {
            ExpenseReport = ReadInputsFromFile(filePath);
            DesiredSum = desiredSum;
        }

        /// <summary>
        /// Returns The Product of the 2 expense report values that sum to 2020
        /// </summary>
        /// <returns></returns>
        public int GetSolution1()
        {
            int[] multiplicands = new int[2];
            bool sumFound = false;
            for (int i = 0; i < ExpenseReport.Count && !sumFound; i++)
            {
                for (int j = i; j < ExpenseReport.Count && !sumFound; ++j)
                {
                    if (ExpenseReport[i] + ExpenseReport[j] == DesiredSum)
                    {
                        multiplicands[0] = ExpenseReport[i];
                        multiplicands[1] = ExpenseReport[j];
                        sumFound = true;
                    }
                }
            }

            return multiplicands[0] * multiplicands[1];
        }


        /// <summary>
        /// Returns The Product of the 2 expense report values that sum to 2020
        /// </summary>
        /// <returns></returns>
        public int GetSolution2()
        {
            int[] multiplicands = new int[3];
            bool sumFound = false;
            for (int i = 0; i < ExpenseReport.Count && !sumFound; i++)
            {
                for (int j = i; j < ExpenseReport.Count && !sumFound; ++j)
                {
                    for(int k = j; k < ExpenseReport.Count && !sumFound; ++k)
                    if (ExpenseReport[i] + ExpenseReport[j] + ExpenseReport[k] == DesiredSum)
                    {
                        multiplicands[0] = ExpenseReport[i];
                        multiplicands[1] = ExpenseReport[j];
                        multiplicands[2] = ExpenseReport[k];
                        sumFound = true;
                    }
                }
            }

            return multiplicands[0] * multiplicands[1] * multiplicands[2];
        }

        /// <summary>
        /// Reads a list of ints from the file at the specified path
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private List<int> ReadInputsFromFile(string filepath)
        {
            List<int> expenseItems = new List<int>();

            using (TextReader reader = File.OpenText(filepath))
            {
                string item;
                while ((item = reader.ReadLine()) != null)
                {
                    expenseItems.Add(int.Parse(item.Trim()));
                }
            }

            return expenseItems;

        }
    }
}
