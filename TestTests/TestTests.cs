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
        public void BringingToStandardViewTest()
        {
            // arrange 

            // act

            Monomial monomial = new Monomial("5yy^2y"); // => 5y^4

            Monomial monomial2 = new Monomial("2xy4xy^2"); // => 8x^2y^3

            Monomial monomial3 = new Monomial("10a^2b^2(-1,2a^3b^3)"); // => -12a^5b^5

            Monomial monomial4 = new Monomial("4ac^2*0,5a^3c"); // => 2a^4c^3

            Monomial monomial5 = new Monomial($"{2.0 / 3.0}a12ab^2"); // => 8a^2b^2

            Monomial monomial6 = new Monomial("0,5x^2y(-xy)"); // => -0,5x^3y^2

            Monomial monomial7 = new Monomial("(2x)^2(-7x^7y^3)"); // => -28x^9y^3

            Monomial monomial8 = new Monomial("(a^2b)^3(5ab)^2"); // => 25a^8b^5

            Monomial monomial9 = new Monomial("2b^3(-3)cb"); // => -6b^4c

            Monomial monomial10 = new Monomial("x^26"); // => x^26

            Monomial monomial11 = new Monomial(17); // => 17

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
        }

        [TestMethod()]
        public void OperatorsTestTest()
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
        }
    }
}