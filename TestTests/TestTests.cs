using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test;
using System;
using System.Collections.Generic;
using System.Text;
using ExtendedMath;

namespace Test.Tests
{
    [TestClass()]
    public class TestTests
    {
        [TestMethod()]
        public void BringingMonomialToStandardViewTest()
        {
            // arrange 

            // act

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

            Monomial monomial12 = new Monomial("((3x)^3)^2"); // => 729x^6

            Monomial monomial13 = new Monomial("(0,5x^2m^4)^3"); // => 0,125m^12x^6

            // assert  

            Assert.AreEqual("5y^4", monomial.ToString());
            Assert.AreEqual("8x^2y^3", monomial2.ToString());
            Assert.AreEqual("-12a^5b^5", monomial3.ToString());
            Assert.AreEqual("2a^4c^3", monomial4.ToString());
            Assert.AreEqual("8a^2b^2", monomial5.ToString());
            Assert.AreEqual("-0,5x^3y^2", monomial6.ToString());
            Assert.AreEqual("-28x^9y^3", monomial7.ToString());
            Assert.AreEqual("25a^8b^5", monomial8.ToString());
            Assert.AreEqual("-6b^4c", monomial9.ToString());
            Assert.AreEqual("x^26", monomial10.LetterMultipliers);
            Assert.AreEqual(17, monomial11.Coefficient);
            Assert.AreEqual("729x^6", monomial12.ToString());
            Assert.AreEqual("0,125m^12x^6", monomial13.ToString());
        }

        [TestMethod()]
        public void MonomialOperatorsTestTest()
        {
            // arrange 

            // act

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

            Monomial monomial19 = new Monomial($"{1.0 / 3.0}ab^2");
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


            // assert 

            Assert.AreEqual("-ab", (monomial1 + monomial2).ToString()); // => -ab

            Assert.AreEqual("5ab", (monomial1 - monomial2).ToString()); // => 5ab

            Assert.AreEqual("0", (monomial3 - monomial4 + monomial5).ToString()); // => 0

            Assert.AreEqual("0", (monomial6 + monomial7).ToString()); // => 0

            Assert.AreEqual("10xy", (monomial8 - monomial9).ToString()); // => 10xy

            Assert.AreEqual("4a^3", (monomial10 + monomial11 - monomial12).ToString()); // => 4a^3

            Assert.AreEqual("-t", (monomial13 - monomial14).ToString()); // => -t

            Assert.AreEqual("14t^5", (monomial15 * monomial16).ToString()); // => 14t^5

            Assert.AreEqual("-25t^4x", (monomial17 * monomial18).ToString()); // => -25t^4x

            Assert.AreEqual("a^4b^3", (monomial19 * monomial20).ToString()); // => a^4b^3

            Assert.AreEqual("a^31b^3", (monomial21 * monomial22).ToString()); // => a^31b^3

            Assert.AreEqual("2a^3", (monomial23 / monomial24).ToString()); // => 2a^3

            Assert.AreEqual("-3p", (monomial25 / monomial26).ToString()); // => -3p

            Assert.AreEqual("7m^5", (monomial27 / monomial28).ToString()); // => 7m^5

            Assert.AreEqual("b^3", (monomial29 / monomial30).ToString()); // => b^3

            Assert.AreEqual("-0,5m", (monomial31 / monomial32).ToString()); // => -0,5m
        }

        [TestMethod()]
        public void BringingPolynomialToStandardViewTestTest()
        {
            // arrange 

            // act

            Polynomial polynomial1 = new Polynomial("a + 2b^2 - c"); // => a + 2b^2 - c

            Polynomial polynomial2 = new Polynomial("3t^5 - 4b"); // => 3t^5 - 4b

            Polynomial polynomial3 = new Polynomial("4 - 6xy"); // => 4 - 6xy

            Polynomial polynomial4 = new Polynomial("3ab + 2 * 3c^2 + 2ab - 8cc + xy"); // => 5ab - 2c^2 + xy

            Polynomial polynomial5 = new Polynomial("5a - 7b - (7a - 5b)"); // => -2a - 2b

            Polynomial polynomial6 = new Polynomial("7x + 2,9(5 - (3x + y))"); // => - 1,7x + 14,5 -2,9y

            Polynomial polynomial7 = new Polynomial("-2,9f(5 - 7 + 1f)"); // => 5,8 f - 2,9 f^2

            Polynomial polynomial8 = new Polynomial("2,9(5 - 7 + 1f)"); // => - 5,8 + 2,9f 

            Polynomial polynomial9 = new Polynomial("x(5 - 7 + 1y)"); // => - 2x + xy 

            Polynomial polynomial10 = new Polynomial("-x(-5 - 7 + 1y)"); // => 12x - xy

            Polynomial polynomial11 = new Polynomial("5a - 7b + (7a - 5b)"); // => 12a - 12b

            Polynomial polynomial12 = new Polynomial("(9x^2 - x)(-5 - 7 + 1y)"); // => -108x^2 + 9x^2y + 12x - xy 

            Polynomial polynomial13 = new Polynomial("(-6x(9x^2 - x))(-5 - 7 + 1y)"); // => 648x^3 -54x^3y - 72x^2 + 6x^2y 

            Polynomial polynomial14 = new Polynomial("(-6x(-(9x^2 + 1) - x))(-5 - (7 + 1y))"); // => -648x^3 - 54x^3y - 72x - 6xy - 72x^2 - 6x^2y 


            Polynomial polynomial15 = new Polynomial("(-6x((9x^2 + 1) - x))(-5 - (7 + 1y))"); // => 648x^3 + 54x^3y + 72x + 6xy - 72x^2 - 6x^2y 

            Polynomial polynomial16 = new Polynomial("7(9x^2 - x)(-5 - 7 + 1y)"); // => -756x^2 + 63x^2y + 84x - 7xy  

            Polynomial polynomial17 = new Polynomial("(9x^2 - x)(7)(-5 - 7 + 1y)"); // => -756x^2 + 63x^2y + 84x - 7xy  

            Polynomial polynomial18 = new Polynomial("(9x^2 - x)-7(-5 - 7 + 1y)"); // => 9x^2 - x + 84 - 7y

            Polynomial polynomial19 = new Polynomial("(9x^2 - x)(9x^2 - x)(-5 - 7 + 1y)(-5 - 7 + 1y)"); // => 11664x^4 - 1944x^4y + 81x^4y^2 - 2592x^3 + 432x^3y - 18x^3y^2 + 144x^2 - 24x^2y + x^2y^2 

            Polynomial polynomial20 = new Polynomial("(9x^2 - x)7 + 1(-5 - 7 + 1y)"); // => 63x^2 - 7x - 12 + y


            // assert 

            Assert.AreEqual("a+2b^2-c", polynomial1.ToString());

            Assert.AreEqual("3t^5-4b", polynomial2.ToString());

            Assert.AreEqual("4-6xy", polynomial3.ToString());

            Assert.AreEqual("5ab-2c^2+xy", polynomial4.ToString());

            Assert.AreEqual("-2a-2b", polynomial5.ToString());

            Assert.AreEqual("-1,7x+14,5-2,9y", polynomial6.ToString());

            Assert.AreEqual("5,8f-2,9f^2", polynomial7.ToString());

            Assert.AreEqual("-5,8+2,9f", polynomial8.ToString());

            Assert.AreEqual("-2x+xy", polynomial9.ToString());

            Assert.AreEqual("12x-xy", polynomial10.ToString());

            Assert.AreEqual("12a-12b", polynomial11.ToString());

            Assert.AreEqual("-108x^2+9x^2y+12x-xy", polynomial12.ToString());

            Assert.AreEqual("648x^3-54x^3y-72x^2+6x^2y", polynomial13.ToString());

            Assert.AreEqual("-648x^3-54x^3y-72x-6xy-72x^2-6x^2y", polynomial14.ToString());

            Assert.AreEqual("648x^3+54x^3y+72x+6xy-72x^2-6x^2y", polynomial15.ToString());

            Assert.AreEqual("-756x^2+63x^2y+84x-7xy", polynomial16.ToString());

            Assert.AreEqual("-756x^2+63x^2y+84x-7xy", polynomial17.ToString());

            Assert.AreEqual("9x^2-x+84-7y", polynomial18.ToString());

            Assert.AreEqual("11664x^4-1944x^4y+81x^4y^2-2592x^3+432x^3y-18x^3y^2+144x^2-24x^2y+x^2y^2", polynomial19.ToString());

            Assert.AreEqual("63x^2-7x-12+y", polynomial20.ToString());
        }
    }
}