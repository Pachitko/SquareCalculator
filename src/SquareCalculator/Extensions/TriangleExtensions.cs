using System.Runtime.CompilerServices;

namespace SquareCalculator.Extensions;

public static class TriangleExtensions
{
    public static void CheckTriangleSide(this double side, [CallerArgumentExpression("side")] string? sideName = null)
    {
        if (side <= 0)
        {
            throw new ArgumentOutOfRangeException(sideName, $"\"{sideName}\" can not be less than or equal to 0");
        }
    }
}