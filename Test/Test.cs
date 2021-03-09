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

            Console.WriteLine();

            OperatorsTest();
        }

        public static void BringingToStandardViewTest()
        {
            Monomial monomial = new Monomial("5yy^2y"); // => 5y^4

            Monomial monomial2 = new Monomial("2xy4xy^2"); // => 8x^2y^3

            Monomial monomial3 = new Monomial("10a^2b^2(-1,2a^3b^3)"); // => -12a^5b^5

            Monomial monomial4 = new Monomial("4c^2a*0,5a^3c"); // => 2a^4c^3

            Monomial monomial5 = new Monomial($"{2.0 / 3.0}a12ab^2"); // => 8a^2b^2

            Monomial monomial6 = new Monomial("0,5x^2y(-xy)"); // => -0,5x^3y^2

            Monomial monomial7 = new Monomial("(2x)^2(-7x^7y^3)"); // => -28x^9y^3

            Monomial monomial8 = new Monomial("(a^2b)^3(5ab)^2"); // => 25a^8b^5

            Monomial monomial9 = new Monomial("2b^3(-3)cb"); // => -6b^4c

            Monomial monomial10 = new Monomial("x^26"); // => x^26

            Monomial monomial11 = new Monomial(17); // => 17

            Console.WriteLine(monomial);

            Console.WriteLine(monomial2);

            Console.WriteLine(monomial3);

            Console.WriteLine(monomial4);

            Console.WriteLine(monomial5);

            Console.WriteLine(monomial6);

            Console.WriteLine(monomial7);

            Console.WriteLine(monomial8);

            Console.WriteLine(monomial9);

            Console.WriteLine(monomial10);

            Console.WriteLine(monomial11); 
        }

        public static void OperatorsTest()
        {
            Monomial monomial1 = new Monomial("2ab");
            Monomial monomial2 = new Monomial("-3ab");

            Monomial monomial3 = new Monomial("8xy");
            Monomial monomial4 = new Monomial("10xy");
            Monomial monomial5 = new Monomial("2xy");

            Monomial monomial6 = new Monomial("-73x^2z");
            Monomial monomial7 = new Monomial("73x^2z");

            Monomial monomial8 = new Monomial("7x2y");
            Monomial monomial9 = new Monomial("2x2y");

            Monomial monomial10 = new Monomial("2a^3");
            Monomial monomial11 = new Monomial("3a^3");
            Monomial monomial12 = new Monomial("a^3");

            Monomial monomial13 = new Monomial("5t");
            Monomial monomial14 = new Monomial("6t");

            Monomial monomial15 = new Monomial("2t^2");
            Monomial monomial16 = new Monomial("7t^3");

            Monomial monomial17 = new Monomial("-5t");
            Monomial monomial18 = new Monomial("5t^3x");

            Monomial monomial19 = new Monomial($"{1.0/3.0}ab^2");
            Monomial monomial20 = new Monomial("3a^3b");

            Monomial monomial21 = new Monomial($"{1.0 / 3.0}ab^2");
            Monomial monomial22 = new Monomial("3a^30b");

            Monomial monomial23 = new Monomial("14a^5");
            Monomial monomial24 = new Monomial("7a^2");

            Monomial monomial25 = new Monomial("-12pq");
            Monomial monomial26 = new Monomial("4q");

            Monomial monomial27 = new Monomial("-42m^6");
            Monomial monomial28 = new Monomial("-6m");

            Monomial monomial29 = new Monomial("b^5");
            Monomial monomial30 = new Monomial("b^2");

            Monomial monomial31 = new Monomial($"{1.0 / 3.0}m^3n^2p^2");
            Monomial monomial32 = new Monomial($"-{2.0 / 3.0}m^2n^2p^2");


            Console.WriteLine(monomial1 + monomial2); // => -ab

            Console.WriteLine(monomial1 - monomial2); // => 5ab

            Console.WriteLine(monomial3 - monomial4 + monomial5); // => 0

            Console.WriteLine(monomial6 + monomial7); // => 0

            Console.WriteLine(monomial8 - monomial9); // => 10xy

            Console.WriteLine(monomial10 + monomial11 - monomial12); // => 4a^3

            Console.WriteLine(monomial13 - monomial14); // => -t

            Console.WriteLine(monomial15 * monomial16); // => 14t^5

            Console.WriteLine(monomial17 * monomial18); // => -25t^4x

            Console.WriteLine(monomial19 * monomial20); // => a^4b^3

            Console.WriteLine(monomial21 * monomial22); // => a^31b^3

            Console.WriteLine(monomial23 / monomial24); // => 2a^3

            Console.WriteLine(monomial25 / monomial26); // => -3p

            Console.WriteLine(monomial27 / monomial28); // => 7m^5

            Console.WriteLine(monomial29 / monomial30); // => b^3

            Console.WriteLine(monomial31 / monomial32); // => -0,5m

        }

    }
}
