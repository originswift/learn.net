using System.Numerics;

namespace Calculators.Features;

public class SimpleCalculator<T> : ISimpleCalculator<T>
    where T : struct, IComparable, IConvertible, IEquatable<T>, IFormattable, INumberBase<T>
{
    public T Add(T a, T b)
    {
        throw new NotImplementedException();
    }

    public T Subtract(T a, T b)
    {
        throw new NotImplementedException();
    }

    public T Multiply(T a, T b)
    {
        throw new NotImplementedException();
    }

    public T Divide(T a, T b)
    {
        throw new NotImplementedException();
    }
}
