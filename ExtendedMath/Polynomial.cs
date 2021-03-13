using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtendedMath
{
    /// <summary>
    /// Многочлен.
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Члены многочлена.
        /// </summary>
        public List<Monomial> MembersOfPolynomial { get; private set; }

        public Polynomial(string polynomial)
        {
            MembersOfPolynomial = new List<Monomial>();

            BringingToStandardView(polynomial);
        }

        /// <summary>
        /// Метод приводящий многочлен к стандартному виду.
        /// </summary>
        private void BringingToStandardView(string polynomial)
        {
            var monomial = "";

            polynomial = polynomial.Replace(" ", "");

            var newPolynomial = "";

            var valueBetweenBrackets = string.Join("", Regex.Match(polynomial, @"\)\d*\w*").Value.Skip(1));

            if (valueBetweenBrackets != "" &&!valueBetweenBrackets.Any(a => a == ')') && !valueBetweenBrackets.Any(a => a == '('))
            {
                var indexValueBetweenBrackets = polynomial.IndexOf(valueBetweenBrackets);

                var newValue = polynomial.Substring(indexValueBetweenBrackets, valueBetweenBrackets.Length);

                newValue += ')';

                newValue = '(' + newValue;

                polynomial = polynomial.Replace(valueBetweenBrackets, newValue);
            }

            var index = polynomial.LastIndexOf(")(");

            if (index != -1)
            {
                newPolynomial = polynomial.Substring(0, index + 1);

                index = polynomial.LastIndexOf(")(");

                if (!newPolynomial.Any(a => a == ')'))
                {
                    newPolynomial += ')';
                }
                if (!newPolynomial.Any(a => a == '('))
                {
                    newPolynomial = '(' + newPolynomial;
                }

                if (newPolynomial.LastIndexOf(")(") != -1)
                {
                    var newValue = RemovingBrackets(newPolynomial, true);

                    polynomial = polynomial.Replace(newPolynomial, newValue);

                    polynomial = polynomial.Insert(polynomial.IndexOf('('), ")");

                    polynomial = '(' + polynomial;
                }
                else
                {
                    var newValue = RemovingBrackets(newPolynomial);

                    polynomial = polynomial.Replace(newPolynomial, newValue);

                    polynomial = polynomial.Insert(polynomial.IndexOf('('), ")");

                    polynomial = '(' + polynomial;
                }
            }

            do
            {
                polynomial = RemovingBrackets(polynomial);
            }
            while (polynomial.Any(a => a == ')') || polynomial.Any(a => a == '('));

            for (int i = 0; i < polynomial.Length; i++)
            {
                if (polynomial[i] == '+')
                {
                    MembersOfPolynomial.Add(new Monomial(monomial));

                    monomial = "";
                }
                else if (polynomial[i] == '-')
                {
                    MembersOfPolynomial.Add(new Monomial(monomial));

                    monomial = "-";
                }
                else
                {
                    monomial += polynomial[i];
                }
            }

            if (monomial != "-")
            {
                MembersOfPolynomial.Add(new Monomial(monomial));
            }

            var newMembersOfPolynomial = new List<Monomial>();

            var newMonomial = new Monomial(1);

            MembersOfPolynomial.RemoveAll(r => r.Coefficient == 1 && r.LetterMultipliers == "");

            for (int i = 0; i < MembersOfPolynomial.Count; i++)
            {
                for (int j = 0; j < MembersOfPolynomial.Count; j++)
                {
                    if (i != j && MembersOfPolynomial[i].IsSimilar(MembersOfPolynomial[j]))
                    {
                        if (MembersOfPolynomial[j] != newMonomial && MembersOfPolynomial[i] != newMonomial)
                        {
                            MembersOfPolynomial[i] = MembersOfPolynomial[i] + MembersOfPolynomial[j];
                            MembersOfPolynomial[j] = newMonomial;
                        }
                    }
                }
            }

            MembersOfPolynomial.RemoveAll(r => r.Coefficient == 1 && r.LetterMultipliers == "");
        }

        /// <summary>
        /// Метод убирающий скобки.
        /// </summary>
        private string RemovingBrackets(string polynomial, bool isMultiplication = false)
        {
            for (int i = polynomial.Length - 1; i >= 0; i--)
            {
                if (i < polynomial.Length && polynomial[i] == '(')
                {
                    i--;

                    var value = GetValueInParentheses(polynomial, ref i, out List<Monomial> valueBeforeParentheses);

                    valueBeforeParentheses.RemoveAll(r => r.Coefficient == 1 && r.LetterMultipliers == "");

                    var newPolynomial = "";

                    if (valueBeforeParentheses.Count == 0)
                    {
                        valueBeforeParentheses.Add(new Monomial(1));
                    }

                    for (int k = 0; k < valueBeforeParentheses.Count; k++)
                    {
                        var j = 0;

                        var stringNum = "";

                        var multiplication = new Monomial(1);

                        Monomial newMonomial;

                        for (; j < value.Length; j++)
                        {
                            if (value[j] == ')') break;

                            if (value[j] == '+')
                            {
                                newMonomial = new Monomial(stringNum);

                                if ((valueBeforeParentheses[k] * newMonomial).Coefficient > 0)
                                {
                                    newPolynomial += "+";
                                }

                                multiplication = (valueBeforeParentheses[k] * newMonomial);

                                if (multiplication.Coefficient == 1 && multiplication.LetterMultipliers == "")
                                {
                                    newPolynomial += 1;
                                }
                                else
                                {
                                    newPolynomial += valueBeforeParentheses[k] * newMonomial;
                                }

                                stringNum = "";
                            }
                            else if (value[j] == '-' && stringNum != "")
                            {
                                newMonomial = new Monomial(stringNum);

                                if ((valueBeforeParentheses[k] * newMonomial).Coefficient > 0)
                                {
                                    newPolynomial += "+";
                                }

                                multiplication = (valueBeforeParentheses[k] * newMonomial);

                                if (multiplication.Coefficient == 1 && multiplication.LetterMultipliers == "")
                                {
                                    newPolynomial += 1;
                                }
                                else
                                {
                                    newPolynomial += valueBeforeParentheses[k] * newMonomial;
                                }

                                stringNum = "-";
                            }
                            else if (value[j] != '(')
                            {
                                stringNum += value[j];
                            }
                        }

                        newMonomial = new Monomial(stringNum);

                        if ((valueBeforeParentheses[k] * newMonomial).Coefficient > 0)
                        {
                            newPolynomial += "+";
                        }

                        multiplication = (valueBeforeParentheses[k] * newMonomial);

                        if (multiplication.Coefficient == 1 && multiplication.LetterMultipliers == "")
                        {
                            newPolynomial += 1;
                        }
                        else if (multiplication.Coefficient == -1 && multiplication.LetterMultipliers == "")
                        {
                            newPolynomial += "-1";
                        }
                        else
                        {
                            newPolynomial += valueBeforeParentheses[k] * newMonomial;
                        }
                    }

                    var _valueBeforeParentheses = "";

                    foreach (var item in valueBeforeParentheses)
                    {
                        if (item.Coefficient > 0 && valueBeforeParentheses.FirstOrDefault() != item)
                        {
                            _valueBeforeParentheses += '+';
                        }

                        _valueBeforeParentheses += item;
                    }

                    if (valueBeforeParentheses.Count > 1)
                    {
                        _valueBeforeParentheses = "(" + _valueBeforeParentheses;

                        _valueBeforeParentheses += ")";
                    }

                    if (newPolynomial[0] == '+')
                    {
                        var index = polynomial.IndexOf(_valueBeforeParentheses);

                        if (index > 0 && polynomial[index - 1] != ')')
                        {
                            newPolynomial = newPolynomial.Remove(0, 1);
                        }
                        else if (index == 0)
                        {
                            newPolynomial = newPolynomial.Remove(0, 1);
                        }
                    }

                    if (isMultiplication == true && polynomial.Replace(_valueBeforeParentheses + value, "").Any(a => a == ')'))
                    {
                        newPolynomial += ')';
                        newPolynomial = '(' + newPolynomial;
                    }

                    // Раскрываем скобки.
                    polynomial = polynomial.Replace(_valueBeforeParentheses + value, newPolynomial);

                    polynomial = polynomial.Replace(" ", "");
                }
            }

            return polynomial;
        }

        /// <summary>
        /// Метод получающий значение в скобках.
        /// </summary>
        private string GetValueInParentheses(string polynomial, ref int i, out List<Monomial> monomials)
        {
            var result = "";

            monomials = new List<Monomial>();

            if (i == -1)
            {
                monomials.Add(new Monomial(1));

                result += '(';

                i = 1;
            }
            else if (polynomial[i] == ')')
            {
                monomials = PolynomialHandler(polynomial, ref i);
            }
            else
            {
                monomials.Add(MonomialHandler(polynomial, ref i));
            }

            for (; i < polynomial.Length; i++)
            {
                result += polynomial[i];

                if (polynomial[i] == ')') break;
            }

            return result;
        }

        /// <summary>
        /// Метод обрабатывающий одночлен перед скобкой.
        /// </summary>
        private Monomial MonomialHandler(string line, ref int index)
        {
            var length = GetNumLength(line, index);

            if (length > 1)
            {
                var num = "";

                // Получает одночлен.
                for (int j = index; j > index - length; j--)
                {
                    num += line[j];
                }

                num = string.Join("", num.Reverse());

                index += 1;

                return new Monomial(num);
            }
            else if (line[index] == '-')
            {
                index += 1;
                return new Monomial(-1);
            }
            else
            {
                index += 1;
                return new Monomial(line[index - 1].ToString());
            }
        }

        /// <summary>
        /// Метод обрабатывающий многочлен перед скобкой.
        /// </summary>
        private List<Monomial> PolynomialHandler(string line, ref int index)
        {
            var length = GetNumLength(line, index);

            var polynomial = new List<Monomial>();

            var num = "";

            // Получает многочлен.
            for (int j = index; j > index - length; j--)
            {
                if (line[j] == '+')
                {
                    num += line[j];

                    polynomial.Add(new Monomial(string.Join("", num.Reverse())));

                    num = "";
                }
                else if (line[j] == '-')
                {
                    num += line[j];

                    polynomial.Add(new Monomial(string.Join("", num.Reverse())));

                    num = "";
                }
                else
                {
                    num += line[j];
                }
            }

            polynomial.Add(new Monomial(string.Join("", num.Reverse())));

            polynomial.Reverse();

            index += 1;

            return polynomial;
        }

        /// <summary>
        /// Метод получающий длину числа.
        /// </summary>
        /// <returns> Длина числа. </returns>
        private int GetNumLength(string line, int startIndex)
        {
            var length = 0;

            if (line[startIndex] == ')')
            {
                for (; startIndex >= 0; startIndex--)
                {
                    length += 1;

                    if (line[startIndex] == '(') break;
                }
            }
            else
            {
                for (; startIndex >= 0; startIndex--)
                {
                    if (line[startIndex] == '+' || line[startIndex] == '*' || line[startIndex] == '(' || line[startIndex] == ')') break;

                    if (line[startIndex] == '-')
                    {
                        length += 1;
                        break;
                    }

                    length += 1;
                }
            }

            return length;
        }

        public override string ToString()
        {
            var result = "";

            for (int i = 0; i < MembersOfPolynomial.Count; i++)
            {
                if (i == 0 || MembersOfPolynomial[i].Coefficient < 0)
                {
                    result += $"{MembersOfPolynomial[i]}";
                }
                else
                {
                    result += $"+{MembersOfPolynomial[i]}";
                }     
            }

            return result;
        }
    }
}
