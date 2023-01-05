using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace ClassroomStart
{
    public class Testing
    {
        bool testPhoneNumber(string phoneNumberTest)
        {
            return new Regex(@"\d\d\d-\d\d\d-\d\d\d\d").IsMatch(phoneNumberTest);
        }
        [Theory,
            InlineData("(555)555-5555", false),
            InlineData("5555555555", false),
            InlineData("555 555 5555", false),
            InlineData("(555)-555-5555", false),
            InlineData("555-555-5555", true),
        ]
        public void testingPhoneNumber(string toTest, bool expectedResult)
        {
            Assert.Equal(expectedResult, testPhoneNumber(toTest));
        }
    }
}
