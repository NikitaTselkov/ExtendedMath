using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedMath
{
    /// <summary>
    /// Одночлен.
    /// </summary>
    public class Monomial
    {
        /// <summary>
        /// Коэффициент одночлена. 
        /// </summary>
        public double Coefficient { get; private set; } = 1;

        /// <summary>
        /// Буквенные множители.
        /// </summary>
        public string LetterMultipliers { get; private set; } = "";

        /// <summary>
        /// Степень округления.
        /// </summary>
        private int DegreeOfRounding { get; set; } = 5;

        public Monomial(string monomial)
        {
            BringingToStandardView(monomial);
        }

        public Monomial(double monomial)
        {
            Coefficient = monomial;
        }

        private Monomial(double coefficient, string letterMultipliers)
        {
            Coefficient = coefficient;
            LetterMultipliers = letterMultipliers;
        }

        /// <summary>
        /// Метод приводящий одночлен к стандартному виду.
        /// </summary>
        private void BringingToStandardView(string monomial)
        {
            for (int i = 0; i < monomial.Length; i++)
            {
                // Является ли символ возведением в степень.
                if (monomial[i] == '^')
                {
                    DegreeHandler(monomial, ref i);
                }
                // Является ли символ цифрой.
                else if (char.IsDigit(monomial[i]) || monomial[i] == '-')
                {
                    Coefficient *= Math.Round(NumHandler(monomial, ref i), DegreeOfRounding);
                }
                // Является ли символ буквой.
                else if (char.IsLetter(monomial[i]))
                {
                    LetterMultipliers += monomial[i];
                }
            }

            DegreeFormat();
        }

        /// <summary>
        /// Метод обрабатывающий степень.
        /// </summary>
        private void DegreeHandler(string monomial, ref int index)
        {
            var degree = 0;

            var sDegree = "";

            var j = index + 1;

            //Получаем степень.
            for (; j < monomial.Length; j++)
            {
                if (!char.IsDigit(monomial[j])) break; // Если цифры закончились выходим.

                sDegree += monomial[j].ToString();
            }

            degree = Convert.ToInt32(sDegree) - 1;

            // Если предыдущий символ буква.
            if (char.IsLetter(monomial[index - 1]))
            {
                // Записываем предыдущий символ degree раз.
                LetterMultipliers += new String(monomial[index - 1], degree);
            }
            else if (monomial[index - 1] == ')')
            {
                // Получаем значение в скобках.
                var value = GetValueInParentheses(monomial, index - 1);

                for (int i = 0; i < degree; i++)
                {
                    for (int k = 0; k < value.Length; k++)
                    {
                        // Является ли символ цифрой.
                        if (char.IsDigit(value[k]) || value[k] == '-')
                        {
                            Coefficient *= Math.Round(NumHandler(value, ref k), DegreeOfRounding);
                        }
                        // Является ли символ возведением в степень.
                        else if (value[k] == '^')
                        {
                            DegreeHandler(value, ref k);
                        }
                        // Является ли символ буквой.
                        else if (char.IsLetter(value[k]))
                        {
                            LetterMultipliers += value[k];
                        }
                    }
                }
            }
            else
            {
                // Возводим предыдущий символ в степень degree.
                Coefficient *= Math.Round(Math.Pow(Convert.ToDouble(monomial[index - 1].ToString()), degree), DegreeOfRounding);
            }

            index = j - 1;
        }

        /// <summary>
        /// Метод получающий степень.
        /// </summary>
        private static int GetDegree(string monomial, int index)
        {
            var sDegree = "";

            var j = index + 1;

            //Получаем степень.
            for (; j < monomial.Length; j++)
            {
                if (!char.IsDigit(monomial[j])) break; // Если цифры закончились выходим.

                sDegree += monomial[j].ToString();
            }

            index = j;

            return Convert.ToInt32(sDegree) - 1;
        }

        /// <summary>
        /// Метод обрабатывающий число.
        /// </summary>
        /// <returns> Часть коэффициента. </returns>
        private double NumHandler(string monomial, ref int index)
        {
            var length = GetNumLength(monomial, index);

            if (length > 1)
            {
                var num = "";

                // Получает число.
                for (int j = index; j < index + length; j++)
                {
                    num += monomial[j];
                }

                index += length - 1;

                return Convert.ToDouble(num);
            }
            else if (monomial[index] == '-')
            {
                return -1;
            }
            else
            {
                return Convert.ToDouble(monomial[index].ToString());
            }
        }

        /// <summary>
        /// Метод получающий выражение из скобок.
        /// </summary>
        /// <returns> Выражение из скобок. </returns>
        private string GetValueInParentheses(string line, int endIndex)
        {
            var result = "";

            for (int i = endIndex - 1; i > 0; i--)
            {
                if (line[i] =='(') break;

                result += line[i];
            }

            // Разворачивает строку.
            result = new string(result.Reverse().ToArray());

            return result;
        }

        /// <summary>
        /// Метод получающий длину числа.
        /// </summary>
        /// <returns> Длина числа. </returns>
        private int GetNumLength(string line, int startIndex)
        {
            var length = 0;

            for (; startIndex < line.Length; startIndex++)
            {
                if (!char.IsDigit(line[startIndex]) && line[startIndex] != ',' && line[startIndex] != '-') break; // Если цифры закончились выходим.

                length += 1;
            }

            return length;
        }

        /// <summary>
        /// Перевод из формата d^4 в dddd.
        /// </summary>
        private static string ReverseDegreeFormat(string monomial)
        {
            var result = "";

            var degree = 0;

            for (int i = 0; i < monomial.Length; i++)
            {
                // Является ли символ возведением в степень.
                if (monomial[i] == '^')
                {
                    degree = GetDegree(monomial, i);

                    result += new String(monomial[i - 1], degree);
                }
                // Является ли символ буквой.
                else if (char.IsLetter(monomial[i]))
                {
                    result += monomial[i];
                }
            }

            return result;
        }

        /// <summary>
        /// Перевод из формата dddd в d^4.
        /// </summary>
        private void DegreeFormat()
        {
            var newLetterMultipliers = "";
            
            foreach (var letter in LetterMultipliers.Distinct().ToArray())
            {
                var count = LetterMultipliers.Count(chr => chr == letter);

                if (count > 1)
                {
                    newLetterMultipliers += string.Format("{0}^{1}", letter, count);
                }
                else
                {
                    newLetterMultipliers += letter;
                }
            }

            LetterMultipliers = newLetterMultipliers;
        }

        /// <summary>
        /// Перевод из формата dddd в d^4.
        /// </summary>
        private static string DegreeFormat(string monomial)
        {
            var newLetterMultipliers = "";

            foreach (var letter in monomial.Distinct().ToArray())
            {
                var count = monomial.Count(chr => chr == letter);

                if (count > 1)
                {
                    newLetterMultipliers += string.Format("{0}^{1}", letter, count);
                }
                else
                {
                    newLetterMultipliers += letter;
                }
            }

           return newLetterMultipliers;
        }

        #region Операторы.

        /// <summary>
        /// Метод проверяющий подобные одночлены млм нет.
        /// </summary>
        private static bool IsSimilar(Monomial monomial1, Monomial monomial2)
        {
            if (monomial1.LetterMultipliers == monomial2.LetterMultipliers)
            {
                return true;
            }

            return false;
        }

        public static Monomial operator *(Monomial m1, Monomial m2)
        {
            var result = new Monomial(Math.Round(m1.Coefficient * m2.Coefficient, 4), "");

            result.LetterMultipliers += ReverseDegreeFormat(m1.LetterMultipliers);
            result.LetterMultipliers += ReverseDegreeFormat(m2.LetterMultipliers);

            result.LetterMultipliers = DegreeFormat(result.LetterMultipliers);

            return result;
        }

        public static Monomial operator -(Monomial m1, Monomial m2)
        {
            if (!IsSimilar(m1, m2))
            {
                throw new Exception("Можно вычитать только подобные одночлены.");
            }

            var result = new Monomial(Math.Round(m1.Coefficient - m2.Coefficient, 4), m1.LetterMultipliers);

            if (result.Coefficient == 0)
            {
                result.LetterMultipliers = "";
            }

            return result;
        }

        public static Monomial operator +(Monomial m1, Monomial m2)
        {
            if (!IsSimilar(m1, m2))
            {
                throw new Exception("Можно складывать только подобные одночлены.");
            }

            var result = new Monomial(Math.Round(m1.Coefficient + m2.Coefficient, 4), m1.LetterMultipliers);

            if (result.Coefficient == 0)
            {
                result.LetterMultipliers = "";
            }

            return result;
        }

        #endregion

        public override string ToString()
        {
            var result = "";

            if (Coefficient == 1)
            {
                result = string.Format("{0}", LetterMultipliers);
            }
            else if (Coefficient == -1)
            {
                result = string.Format("-{0}", LetterMultipliers);
            }
            else if (LetterMultipliers == string.Empty)
            {
                result = string.Format("{0}", Math.Round(Coefficient, 3));
            }
            else
            {
                result = string.Format("{0}{1}", Math.Round(Coefficient, 3), LetterMultipliers);
            }

            return result;
        }
    }
}
