using System.Globalization;
using System.Linq;
using System.Text;

namespace Aoc2020.Day4
{
    public static class PassportProcessing
    {
        public static int GetValidFieldsPassportCount(string input)
        {
            string[] lines = input.Split("\n\n").Select(x => x.Replace("\n", " ").Trim()).ToArray();

            int validPassports = 0;
            foreach (string line in lines)
            {
                if (line.Split(" ").Where(x => !x.Contains("cid")).Count() == 7)
                {
                    validPassports++;
                }
            }

            return validPassports;
        }

        public static int GetValidValuesPassportCount(string input)
        {
            string[] lines = input.Split("\n\n").Select(x => x.Replace("\n", " ").Trim()).ToArray();

            int validPassports = 0;
            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                string[] fields = line.Split(" ").Where(x => !x.Contains("cid")).ToArray();

                if (fields.Length == 7)
                {
                    validPassports = IsPassportValid(fields) ? validPassports + 1 : validPassports;
                }
            }

            return validPassports;
        }

        private static bool IsPassportValid(string[] fields)
        {
            foreach (string field in fields)
            {
                string fieldName = field.Split(":")[0];
                string fieldValue = field.Split(":")[1];

                if (fieldName == "byr")
                {
                    if (int.Parse(fieldValue) < 1920 || int.Parse(fieldValue) > 2002)
                    {
                        return false;
                    }
                }
                else if (fieldName == "iyr")
                {
                    if (int.Parse(fieldValue) < 2010 || int.Parse(fieldValue) > 2020)
                    {
                        return false;
                    }
                }
                else if (fieldName == "eyr")
                {
                    if (int.Parse(fieldValue) < 2020 || int.Parse(fieldValue) > 2030)
                    {
                        return false;
                    }
                }
                else if (fieldName == "hgt")
                {
                    string unit = fieldValue[^2..];
                    bool heightExists = int.TryParse(fieldValue[0..^2], out int height);

                    if (!heightExists)
                    {
                        return false;
                    }

                    if (unit == "cm")
                    {
                        if (height < 150 || height > 193)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (height < 59 || height > 76)
                        {
                            return false;
                        }
                    }
                }
                else if (fieldName == "hcl")
                {
                    if (fieldValue.Length != 7 || fieldValue[0] != '#' || !int.TryParse(fieldValue[1..], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int _))
                    {
                        return false;
                    }
                }
                else if (fieldName == "ecl")
                {
                    string[] colors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                    if (!colors.Contains(fieldValue))
                    {
                        return false;
                    }
                }
                else if (fieldName == "pid")
                {
                    if (fieldValue.Length != 9 || !int.TryParse(fieldValue, out int _))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}