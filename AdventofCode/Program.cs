﻿using AdventofCode.BusinessLogic.Day1;
using System;
using System.IO;

namespace AdventofCode
{
    class Program
    {
        /// <summary>
        /// Prefixes filepath string to navigate to the assets folder
        /// </summary>
        /// <returns></returns>
        public static string ASSET_PATH = "..//..//..//Assets//";

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Filename you would like to read from: ");
            string filename = Console.ReadLine();
            Console.WriteLine("Enter the desired sum you would like to calculate from: ");
            string desiredSum = Console.ReadLine();
            string path = ASSET_PATH + filename;


            var resortRepair = new ResortRepair(path, int.Parse(desiredSum));

            var res = resortRepair.GetSolution1();

            Console.WriteLine("The sum for problem 1 is : " + res);

            res = resortRepair.GetSolution2();

            Console.WriteLine("The sum for problem 2 is : " + res);



        }

    }
}
