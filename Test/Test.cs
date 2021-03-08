using ExtendedMath;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Test
    {
        public static void Main()
        {
            BringingToStandardViewTest();
        }

        public static void BringingToStandardViewTest()
        {
            Monomial monomial = new Monomial("5yy^2y"); // => 5y^4

            Monomial monomial2 = new Monomial("2xy4xy^2"); // => 8x^2y^3

            Monomial monomial3 = new Monomial("10a^2b^2(-1,2a^3b^3)"); // => -12a^5b^5

            Monomial monomial4 = new Monomial("4ac^2*0,5a^3c"); // => 2a^4c^3

            Monomial monomial5 = new Monomial($"{2.0 / 3.0}a12ab^2"); // => 8a^2b^2

            Monomial monomial6 = new Monomial("0,5x^2y(-xy)"); // => -0,5x^3y^2

            Monomial monomial7 = new Monomial("(2x)^2(-7x^7y^3)"); // => -28x^9y^3

            Monomial monomial8 = new Monomial("(a^2b)^3(5ab)^2"); // => 25a^8b^5

            Console.WriteLine(monomial);

            Console.WriteLine(monomial2);

            Console.WriteLine(monomial3);

            Console.WriteLine(monomial4);

            Console.WriteLine(monomial5);

            Console.WriteLine(monomial6);

            Console.WriteLine(monomial7);

            Console.WriteLine(monomial8);
        }

    }
}
