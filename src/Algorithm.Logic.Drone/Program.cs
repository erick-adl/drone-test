using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Algorithm.Logic.Drone
{
    public class Program
    {

        private const string FAIL = "(999, 999)";
        private const char CANCEL_CHAR = 'X';
        public static string Evaluate(string input)
        {
            try
            {
                var valid = BasicValidations(input);

                if (!valid)
                {
                    throw new Exception();
                }

                var inputNormalized = InputNormalizer(input);

                var dic = new Dictionary<char, int>()
                {
                    {'N',0 },
                    {'S',0 },
                    {'L',0 },
                    {'O',0 },
                };

                for (int i = 0; i < inputNormalized.Length; i++)
                {
                    if (char.IsDigit(inputNormalized[i]))
                    {
                        var index = i;
                        var number = string.Empty;

                        while ((index < inputNormalized.Length) && (char.IsDigit(inputNormalized[index])))
                        {
                            number += inputNormalized[index];
                            index++;
                        }

                        dic[inputNormalized[i - 1]] = (dic[inputNormalized[i - 1]] > 1)
                            ? (dic[inputNormalized[i - 1]] - 1) + int.Parse(number)
                            : int.Parse(number);

                        i = index - 1;
                    }
                    else
                    {
                        if (dic[inputNormalized[i]] == int.MaxValue)
                        {
                            throw new Exception();
                        }
                        dic[inputNormalized[i]] += 1;
                    }
                }

                var y = (dic['N'] - dic['S']);
                var x = (dic['L'] - dic['O']);
                return $"({x}, {y})";
            }
            catch
            {
                return FAIL;
            }
        }

        private static bool BasicValidations(string input)
        {
            return !(
                (String.IsNullOrEmpty(input))
                || (char.IsDigit(input[0]))
                || Regex.IsMatch(input, "^[A-Z]*[X][0-9]+[A-Z]*$")
                );
        }

        private static string InputNormalizer(string input)
        {
            var output = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Equals(CANCEL_CHAR))
                {
                    var index = output.Length - 1;
                    if (!char.IsDigit(output[index]))
                    {
                        output = output.Remove(index, 1);
                    }
                    else
                    {
                        index--;
                        while (char.IsDigit(output[index]))
                        {
                            index--;
                        }
                        output = output.Remove(index, output.Length - index);
                    }
                }
                else
                {
                    output += input[i];
                }
            }

            return output.ToUpper();
        }

    }
}
