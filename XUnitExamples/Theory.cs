using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitExamples
{
    public class Theory
    {

        //[InlineData()] =  Here you provide data for each test, Can have as many as you like(?)
        // it will not run duplicates

        // tests multiple scenarios one might fail many can pass
        // it must have some data provided 
        [Theory]
        [InlineData(1, '+', 1, 2)]
        [InlineData(1, '+', 2, 3)]
        [InlineData(2, '+', 2, 4)]
        public void PerformOperation_Add_returnsNumber(double num1, char operation, double num2, double expectedResult)
        {
            double result = SomeApp.PerformOperation.RunOperation(num1, operation, num2);
            Assert.Equal(result, expectedResult);
        }

        // Instead of using InlineData we can use MemberData which will run all the 
        // it will not run duplicates
        [Theory]
        [MemberData(nameof(MemberTestData))]
        public void MemberDataTest(double num1, char operation, double num2, object expectedResult)
        {
            if (expectedResult is double)
            {
                double result = SomeApp.PerformOperation.RunOperation(num1, operation, num2);
                Assert.Equal(result, expectedResult);
            }
            else if (expectedResult is Exception)
            {
                Assert.Throws<DivideByZeroException>(() => SomeApp.PerformOperation.RunOperation(num1, operation, num2));
            }
        }
        // Same as member data but uses a class 
        // it WILL run duplicates
        [Theory]
        [ClassData(typeof(ClassTestDataForAdd))]
        public void ClassDataTest(double num1, char operation, double num2, object expectedResult)
        {
            if (expectedResult is double)
            {
                double result = SomeApp.PerformOperation.RunOperation(num1, operation, num2);
                Assert.Equal(result, expectedResult);
            }
            else if (expectedResult is Exception)
            {
                Assert.Throws<DivideByZeroException>(() => SomeApp.PerformOperation.RunOperation(num1, operation, num2));
            }
        }

        public static IEnumerable<object[]> MemberTestData()
        {
            yield return new object[] { 1, '/', 1, 1.0 };
            yield return new object[] { 1, '/', 2, 0.5 };
            yield return new object[] { 1, '/', 0, new DivideByZeroException() };
        }

    }

   
}
