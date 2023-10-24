using Xunit.Abstractions;
using SomeApp;


namespace XUnitExamples;

public class FactBasics
{
    // Facts can not have any parameters in their signarute.

    // this will run as a test 
    [Fact]
    public void PerformOperation_Add_returnsNumber()
    {
        double result = PerformOperation.RunOp(1, '+', 1);

        Assert.Equal(2, result);
    }
    // will change the displayed name in the test explorer
    [Fact(DisplayName = "Adding 1+1")]
    public void PerformOperation_Add_returnsNumber_CustomName()
    {
        double result = PerformOperation.RunOp(1, '+', 1);

        Assert.Equal(2, result);
    }

    // Skip will not perform the test and also not produce a failure
    // also flag it as skipped
    [Fact(Skip = "This is broken for now and should be skipped")]
    public void PerformOperation_Add_willSkip()
    {
        double result = PerformOperation.RunOp(1, '+', 3);

        Assert.Equal(2, result);
    }
}
