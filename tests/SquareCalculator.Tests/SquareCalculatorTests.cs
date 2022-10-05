using System;
using FluentAssertions;
using SquareCalculator.Figures;
using Xunit;

namespace SquareCalculator.Tests;

public class SquareCalculatorTests
{
    #region Circle tests

    [Fact]
    public void CreateCircleWithNegativeRadius_ShouldThrowArgumentOutOfRangeException()
    {
        Action act = () => _ = new Circle(-1);

        act.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void CreateValidCircle_ShoudOk()
    {
        var circle = new Circle(1);
        circle.Square.Should().BeApproximately(Math.PI, double.Epsilon);
    }

    #endregion

    #region Triangle tests

    [Fact]
    public void CreateTrianglesWithInvalidSides_ShouldThrowArgumentOutOfRangeException()
    {
        Action act1 = () => _ = new Triangle(-1, 3, 1);
        Action act2 = () => _ = new Triangle(1, -1, 3);
        Action act3 = () => _ = new Triangle(3, 1, -1);
        Action act4 = () => _ = new Triangle(-1, -1, -1);
        Action act5 = () => _ = new Triangle(3, 6, 3);

        act1.Should().ThrowExactly<ArgumentOutOfRangeException>();
        act2.Should().ThrowExactly<ArgumentOutOfRangeException>();
        act3.Should().ThrowExactly<ArgumentOutOfRangeException>();
        act4.Should().ThrowExactly<ArgumentOutOfRangeException>();
        act5.Should().ThrowExactly<ArgumentException>().WithMessage("Triangle does not exist");
    }

    [Fact]
    public void CreateValidTriangle_ShoudOk()
    {
        var triangle = new Triangle(3, 4, 5);
        triangle.Square
            .Should().BeApproximately(6.0, double.Epsilon);
    }

    [Fact]
    public void CreateRightTriangle_ShoudBeTrue()
    {
        var triangle = new Triangle(3, 4, 5);
        triangle.IsRight
            .Should().Be(true);
    }

    [Fact]
    public void CreateNotRightTriangle_ShoudBeFalse()
    {
        var triangle = new Triangle(1, 2, 2);
        triangle.IsRight
            .Should().Be(false);
    }

    #endregion
}