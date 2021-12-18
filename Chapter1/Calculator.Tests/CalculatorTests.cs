using System;
using Shouldly;
using Xunit;

namespace Calculator.Tests;

public class CalculatorTests : IClassFixture<Calculator>
{
    private readonly Calculator _calculator;

    public CalculatorTests(Calculator calculator)
    {
        _calculator = calculator;
    }

    [Theory]
    [InlineData(10, 5, 15)]
    [InlineData(10, -5, 5)]
    public void CanAddTwoNumbers(int x, int y, int result)
    {
        _calculator.Add(x, y).ShouldBe(result);
    }

    [Theory]
    [InlineData(200, 30, 170)]
    [InlineData(200, -50, 250)]
    public void CanSubtractTwoNumbers(int x, int y, int result)
    {
        _calculator.Subtract(x, y).ShouldBe(result);
    }

    [Theory]
    [InlineData(5, 5, 25)]
    [InlineData(200, 0, 0)]
    public void CanMultiplyTwoNumbers(int x, int y, int result)
    {
        _calculator.Multiply(x, y).ShouldBe(result);
    }

    [Theory]
    [InlineData(20, 2, 10)]
    [InlineData(20, -2, -10)]
    public void CanDivideTwoNumbers(int x, int y, int result)
    {
        _calculator.Divide(x, y).ShouldBe(result);
    }

    [Fact]
    public void DivideByZeroThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(
            () => _calculator.Divide(10, 0));
    }
}