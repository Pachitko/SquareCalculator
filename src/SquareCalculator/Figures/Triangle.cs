using System.Collections;
using SquareCalculator.Abstractions;
using SquareCalculator.Extensions;

namespace SquareCalculator.Figures;

public class Triangle : IFigure
{
    /// <summary>
    /// Side A
    /// </summary>
    public double SideA { get; }

    /// <summary>
    /// Side B
    /// </summary>
    public double SideB { get; }

    /// <summary>
    /// Side C
    /// </summary>
    public double SideC { get; }

    /// <summary>
    /// Is a right triangle
    /// </summary>
    public bool IsRight => _isRight ??= CheckIsRight();
    private bool? _isRight = null;

    /// <summary>
    /// Triangle square
    /// </summary>
    public double Square => _square ??= CalculateSquare();
    private double? _square = null;

    /// <summary>
    /// Triangle
    /// </summary>
    /// <param name="sideA">Side A</param>
    /// <param name="sideB">Side B</param>
    /// <param name="sideC">Side C</param>
    /// <exception cref="ArgumentOutOfRangeException">If the side of the triangle has a negative value</exception>
    /// <exception cref="ArgumentException">If the triangle does not exist</exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        sideA.CheckTriangleSide();
        sideB.CheckTriangleSide();
        sideC.CheckTriangleSide();

        if (sideA >= sideB + sideC || sideB >= sideA + sideC || sideC >= sideA + sideB)
        {
            throw new ArgumentException("Triangle does not exist");
        }

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    /// <summary>
    /// Check, if the triangle is right
    /// </summary>
    private bool CheckIsRight()
    {
        var sideASquare = Math.Pow(SideA, 2);
        var sideBSquare = Math.Pow(SideB, 2);
        var sideCSquare = Math.Pow(SideC, 2);

        var maxSideSquare = Math.Max(sideASquare, Math.Max(sideBSquare, sideCSquare));
        return Math.Abs(2 * maxSideSquare - sideASquare - sideBSquare - sideCSquare) <= double.Epsilon;
    }

    private double CalculateSquare()
    {
        var semiPerimeter = (SideA + SideB + SideC) / 2.0;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
    }
}