using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            bool testResult = Utilities.IsValidPostCode("");

            //  assert
            Assert.AreEqual(expected, testResult);
        }

        [TestMethod]
        public void IsValidPostCode_Valid_True()
        {

            //  arrange
            bool expected = true;

            //  TODO:  create array of postcodes
            //  TODO:  loop through each postcode and assert

            //  act
            bool testResult = Utilities.IsValidPostCode("LS29 6QH");

            //  assert
            Assert.AreEqual(expected, testResult);
        }


    }
}
