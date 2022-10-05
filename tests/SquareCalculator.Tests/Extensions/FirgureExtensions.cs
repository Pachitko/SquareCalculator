using SquareCalculator.Figures;

namespace SquareCalculator.Tests.Extensions;

public static class FirgureExtensions
{
    public static Circle CreateCircle(double radius) => new(radius);
    public static Triangle CreateTriangle(double sideA, double sideB, double sideC) => new(sideA, sideB, sideC);
}