using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PostcodeTests
{
    [TestClass]
    public class PostcodeTests
    {


        [TestMethod]
        public void ValidatePostcode_JunkCode_False()
        {
            //  arrange
            string postcode = "$%± ()()";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);

            Console.WriteLine("TEST PASSED");
        }


        [TestMethod]
        public void ValidatePostcode_InvalidCode_False()
        {
            //  arrange
            string postcode = "XX XXX";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_IncorrectInwardCodeLength_False()
        {
            //  arrange
            string postcode = "A1 9A";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_NoSpace_False()
        {
            //  arrange
            string postcode = "LS44PL";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_QInFirstPosition_False()
        {
            //  arrange
            string postcode = "Q1A 9AA";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_VInFirstPosition_False()
        {
            //  arrange
            string postcode = "V1A 9AA";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_XInFirstPosition_False()
        {
            //  arrange
            string postcode = "X1A 9AA";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_IInSecondPosition_False()
        {
            //  arrange
            string postcode = "LI10 3QP";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_JInSecondPosition_False()
        {
            //  arrange
            string postcode = "LJ10 3QP";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_ZInSecondPosition_False()
        {
            //  arrange
            string postcode = "LZ10 3QP";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_QInThirdPosition_False()
        {
            //  arrange
            string postcode = "A9Q 9AA";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_CInFourthPosition_False()
        {
            //  arrange
            string postcode = "AA9C 9AA";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidatePostcode_AreaWithOnlySingleDigitDistricts_False()
        {
            //  arrange
            string postcode = "FY10 4PL";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void ValidatePostcode_OnlyDoubleDigitsAllowedInDistrict_False()
        {
            //  NOTES:  Is failing because postcode does exist


            //  arrange
            string postcode = "SO1 4QQ";
            bool expected = false;

            //  act
            bool actual = ValidatePostcode(postcode);

            //  asssert
            Assert.AreEqual(expected, actual);

        }




        [TestMethod]
        public void ValidatePostcode_Valid_True()
        {

            //  arrange
            bool actual;
            bool expectedResult = true;


            //  Create list of postcodes which should validate
            List<String> postCodesToValidate = new List<String>();

            postCodesToValidate.Add("EC1A 1BB");
            postCodesToValidate.Add("W1A 0AX");
            postCodesToValidate.Add("M1 1AE");
            postCodesToValidate.Add("B33 8TH");
            postCodesToValidate.Add("CR2 6XH");
            postCodesToValidate.Add("DN55 1PT");
            postCodesToValidate.Add("GIR 0AA");
            postCodesToValidate.Add("SO10 9AA");
            postCodesToValidate.Add("FY9 9AA");
            postCodesToValidate.Add("WC1A 9AA");

            foreach (String postcode in postCodesToValidate)
            {
                //  act
                actual = ValidatePostcode(postcode);

                if (!actual)
                {
                    //  test failed, assert and exit
                    Assert.AreEqual(expectedResult, actual);
                    return;
                }


                Console.WriteLine("The postcode, " + postcode + " returned the result, " + actual);

                //  assert
                Assert.AreEqual(expectedResult, actual);
            }

        }

        bool ValidatePostcode(string postcodeToValidate)
        {
            return PostcodeValidator.Utilities.IsValidPostCode(postcodeToValidate);
        }


    }
}
