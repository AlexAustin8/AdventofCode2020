using AdventofCode.Models;
using System;
using System.IO;
using System.Linq;

namespace AdventofCode.BusinessLogic.Day4
{
    public class PassportProcessing
    {
        public static char[] validChars = { 'a', 'b', 'c', 'd', 'e', 'f', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static string[] validEyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        /// <summary>
        /// Gets the number of valid passports in the file from the specified path
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="validateData">Value indicating whether or not to validate data</param>
        /// <returns></returns>
        public static int GetValidPassportCount(string filepath, bool validateData)
        {
            int validCount = 0;
            Passport passport = new Passport();
            using (TextReader reader = File.OpenText(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        if (passport.isValid())
                        {
                            validCount++;
                        }
                        passport = new Passport();
                    }
                    else
                    {
                        var lineItems = line.Split();

                        foreach (var item in lineItems)
                        {
                            if (validateData)
                            {
                                assignField2(passport, item);
                            }
                            else
                            {
                                assignField1(passport, item);
                            }
                        }
                    }
                }

                if (passport.isValid())
                {
                    validCount++;
                }
            }

            return validCount;
        }

        /// <summary>
        /// Parses the string to assign it to the proper field for Part 1
        /// </summary>
        /// <param name="p"></param>
        /// <param name="field"></param>
        public static void assignField1(Passport p, string field)
        {
            var split = field.Split(":");

            switch (split[0])
            {
                case "byr":
                    p.BirthYear = split[1];
                    break;

                case "iyr":
                    p.IssueYear = split[1];
                    break;

                case "eyr":
                    p.ExpirationYear = split[1];
                    break;

                case "hgt":
                    p.Height = split[1];
                    break;

                case "hcl":
                    p.HairColor = split[1];
                    break;

                case "ecl":
                    p.EyeColor = split[1];
                    break;

                case "pid":
                    p.PassportId = split[1];
                    break;

                case "cid":
                    p.CountryId = split[1];
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Parses the string to assign it to the proper field for Part 2
        /// </summary>
        /// <param name="p"></param>
        /// <param name="field"></param>
        public static void assignField2(Passport p, string field)
        {
            var split = field.Split(":");
            int parseVal = 0;
            switch (split[0])
            {
                case "byr":
                    parseVal = int.Parse(split[1]);
                    if (split[1].Length == 4 && parseVal >= 1920 && parseVal <= 2002)
                        p.BirthYear = split[1];
                    break;

                case "iyr":
                    parseVal = int.Parse(split[1]);
                    if (split[1].Length == 4 && parseVal >= 2010 && parseVal <= 2020)
                        p.IssueYear = split[1];
                    break;

                case "eyr":
                    parseVal = int.Parse(split[1]);
                    if (split[1].Length == 4 && parseVal >= 2020 && parseVal <= 2030)
                        p.ExpirationYear = split[1];
                    break;

                case "hgt":

                    bool isCm = true;
                    int numBreak = split[1].IndexOf("c", StringComparison.InvariantCultureIgnoreCase);
                    if (numBreak == -1)
                    {
                        numBreak = split[1].IndexOf("i", StringComparison.InvariantCultureIgnoreCase);
                        isCm = false;
                    }

                    //Data not valid, break
                    if (numBreak == -1)
                    {
                        break;
                    }
                    parseVal = int.Parse(split[1].Remove(numBreak));
                    int min = isCm ? 150 : 59;
                    int max = isCm ? 193 : 76;
                    if (parseVal >= min && parseVal <= max)
                        p.Height = split[1];
                    break;

                case "hcl":
                    var hexVal = split[1].Substring(1);
                    if (split[1][0] == '#' && validateColorChars(hexVal))
                        p.HairColor = split[1];
                    break;

                case "ecl":
                    if (validEyeColors.FirstOrDefault(eyec => eyec == split[1]) != null)
                        p.EyeColor = split[1];
                    break;

                case "pid":
                    if (split[1].Length == 9)
                        p.PassportId = split[1];
                    break;

                case "cid":
                    p.CountryId = split[1];
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Validates the color input
        /// </summary>
        /// <param name="colorVal"></param>
        /// <returns></returns>
        public static bool validateColorChars(string colorVal)
        {
            var charArr = colorVal.ToCharArray();
            if (colorVal.Length != 6)
            {
                return false;
            }
            foreach (char c in charArr)
            {
                var res = validChars.FirstOrDefault(index => index == c);
                if (res == '\0')
                {
                    return false;
                }
            }

            return true;
        }
    }
}