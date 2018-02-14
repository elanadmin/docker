using System;
using System.Collections.Generic;
using Xunit;

namespace intigrationtest
{
    public class DataTest
    {
        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        public void InlineDataTest(int input)
        {
            Assert.True(input > 10);
        }


        [Theory]
        [MemberData("SplitCountData")]
        public void MemberDataTest(string input, int expectedCount)
        {
            var actualCount = input.Split(' ').Length;
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [MemberData("TestData", MemberType=typeof(DemoPropertyDataSource))]
        public void ClassMemberDataTest(int input, bool expected)
        {
            Assert.Equal(expected, input==1);
        }

        public static IEnumerable<object[]> SplitCountData
        {
            get
            {
                // Or this could read from a file. :)
                return new[]
                {
                new object[] { "xUnit", 1 },
                new object[] { "is fun", 2 },
                new object[] { "to test with", 3 }
            };
            }
        }
    }


    public static class DemoPropertyDataSource
    {
        private static readonly List<object[]> _data 
            = new List<object[]>
                {
                    new object[] {1, true},
                    new object[] {2, false},
                    new object[] {-1, false},
                    new object[] {0, false}
                };
 
        public static IEnumerable<object[]> TestData
        {
            get { return _data; }
        }
    }

}

