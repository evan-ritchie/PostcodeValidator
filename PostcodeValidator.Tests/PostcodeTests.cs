using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PostcodeValidator.Tests
{
    [TestClass]
    public class PoscodeTests
    {
        [TestMethod]
        public void IsValidPostCode_Junk_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("$%± ()()");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_Invalid_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("XX XXX");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_IncorrectInwardCodeLength_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("A1 9A");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_NoSpace_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("LS44PL");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_QInFirstPosition_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("Q1A 9AA");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_VInFirstPosition_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("V1A 9AA");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_XInFirstPosition_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("X1A 9BB");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_IInSecondPosition_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("LI10 3QP");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_JInSecondPosition_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("LJ10 3QP");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_ZInSecondPosition_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("LZ10 3QP");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_QInThirdPositionWithA9AStructure_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("A9Q 9AA");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_CInFourthPositionWithAA9AStructure_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("AA9C 9AA");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_AreaWithOnlySingleDigitDistrict_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("FY10 4PL");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_AreaWithOnlyDoubleDigitDistrict_False()
        {

            //  arrange
            bool expected = false;

            //  act
            bool testResult = Utilities.IsValidPostCode("SO1 4QQ");

            //  assert
            Assert.AreEqual(expected, testResult);
        }



        [TestMethod]
        public void IsValidPostCode_Valid_True()
        {

            //  arrange
            bool expected = true;

            //  Create list of valid postcodes
            List<string> ValidPostcodes = new List<string>();

            //  add codes from valid test cases
            ValidPostcodes.Add("EC1A 1BB");
            ValidPostcodes.Add("W1A 0AX");
            ValidPostcodes.Add("M1 1AE");
            ValidPostcodes.Add("B33 8TH");
            ValidPostcodes.Add("CR2 6XH");
            ValidPostcodes.Add("DN55 1PT");
            ValidPostcodes.Add("GIR 0AA");
            ValidPostcodes.Add("SO10 9AA");
            ValidPostcodes.Add("FY9 9AA");
            ValidPostcodes.Add("WC1A 9AA");


            foreach (string Postcode in ValidPostcodes)
            {
                //  act
                bool testResult = Utilities.IsValidPostCode(Postcode);

                //  assert
                Assert.AreEqual(expected, testResult);
            }


        }


    }
}
