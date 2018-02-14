using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace intigrationtest
{

    public class ExcelDataTest
    {

        [Theory]
        [ExcelData("ExcelDataSource.xlsx", "Sheet3")]
        public void TestExcelData(string number, string expectedResult, string col)
        {
            // var sut = new CheckThisNumber(1);
            // var result = sut.CheckIfEqual(number);
            // Assert.Equal(result, expectedResult);

            Assert.NotNull(number);
        }


    }

    public class CheckThisNumber
    {
        public int IntialValue { get; set; }

        public CheckThisNumber(int intialValue)
        {
            IntialValue = intialValue;
        }

        public bool CheckIfEqual(int input)
        {
            return IntialValue == input;
        }
    }
}