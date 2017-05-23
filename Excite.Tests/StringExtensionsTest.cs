using System;
using Excite.Utilities.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Excite.Tests
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void Valid_Text_With_Matching_Whole_Word_Subtext_Returns_Expected_Results()
        {
            var input =
                "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
            var match = "polly";

            var result = input.IndicesOf(match);

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == 1 && result[1] == 26 && result[2] == 51);
        }

        [TestMethod]
        public void Valid_Text_With_Matching_Partial_Word_Subtext_Returns_Expected_Results()
        {
            var input =
                "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
            var match = "ll";

            var result = input.IndicesOf(match);

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == 3 && result[1] == 28 && result[2] == 53 && result[3] == 78 && result[4] == 82);
        }

        [TestMethod]
        public void Valid_Text_With_Non_Matching_Subtext_Returns_Empty_Array()
        {
            var input =
                "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
            var match = "Polx";

            var result = input.IndicesOf(match);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void Valid_Text_With_Case_Sensitive_Subtext_Returns_Same_Results()
        {
            var input =
                "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";
            var match = "Polly";

            var result = input.IndicesOf(match);

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == 1 && result[1] == 26 && result[2] == 51);

            match = "polly";

            result = input.IndicesOf(match);

            Assert.IsNotNull(result);
            Assert.IsTrue(result[0] == 1 && result[1] == 26 && result[2] == 51);
        }

        [TestMethod]
        public void Null_Text_Throws_An_ArgumentNullException()
        {
            string input = null;
            var match = "polly";
            var responseException = new Exception();

            try
            {
                input.IndicesOf(match);
            }
            catch (Exception ex)
            {
                responseException = ex;
            }

            Assert.IsNotNull(responseException);
            Assert.IsTrue(responseException is ArgumentNullException);
        }

        [TestMethod]
        public void Null_SubText_Throws_An_ArgumentNullException()
        {
            string input = "some test string";
            string match = null;
            var responseException = new Exception();

            try
            {
                input.IndicesOf(match);
            }
            catch (Exception ex)
            {
                responseException = ex;
            }

            Assert.IsNotNull(responseException);
            Assert.IsTrue(responseException is ArgumentNullException);
        }

        [TestMethod]
        public void Empty_SubText_Returns_Zero_As_Result()
        {
            string input = "some test string";
            string match = "";
            var responseException = new Exception();

            var result = input.IndicesOf(match);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue(result[0] == 0);
        }
    }
}
