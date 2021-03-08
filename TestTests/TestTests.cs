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
        public void MainTest()
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

            // assert  

            Assert.AreEqual("5y^4", monomial.ToString());
            Assert.AreEqual("8x^2y^3", monomial2.ToString());
            Assert.AreEqual("-12a^5b^5", monomial3.ToString());
            Assert.AreEqual("2a^4c^3", monomial4.ToString());
            Assert.AreEqual("8a^2b^2", monomial5.ToString());
            Assert.AreEqual("-0,5x^3y^2", monomial6.ToString());
            Assert.AreEqual("-28x^9y^3", monomial7.ToString());
            Assert.AreEqual("25a^8b^5", monomial8.ToString());
        }
    }
}