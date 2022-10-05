using SquareCalculator.Abstractions;

namespace SquareCalculator.Figures;

public class Circle : IFigure
{
    /// <summary>
    /// Circle radius
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Circle
    /// </summary>
    /// <param name="radius">Circle radius</param>
    /// <exception cref="ArgumentOutOfRangeException">If radius is less than 0</exception>
    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentOutOfRangeException(nameof(radius), "Radius can not be less than 0");

        Radius = radius;
    }

    /// <summary>
    /// Circle square
    /// </summary>
    public double Square => _square ??= CalculateSquare();
    private double? _square = null;

    private double CalculateSquare()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}