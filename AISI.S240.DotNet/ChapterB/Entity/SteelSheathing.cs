namespace AISI.S240.DotNet.ChapterB.Entity;

/// <summary>
/// Represents the steel sheathing used in the design.
/// </summary>
/// <param name="Thickness">Thickness in inches</param>
public record SteelSheathing(double Thickness) : IComparable<SteelSheathing>
{
    /// <summary>
    /// Compares this instance to another <see cref="SteelSheathing"/> based on thickness.
    /// </summary>
    public int CompareTo(SteelSheathing? other)
    {
        if (other is null) return 1;
        return Thickness.CompareTo(other.Thickness);
    }

    /// <summary>
    /// Greater than operator for <see cref="SteelSheathing"/> based on thickness.
    /// </summary>
    public static bool operator >(SteelSheathing left, SteelSheathing right) => left.CompareTo(right) > 0;

    /// <summary>
    /// Less than operator for <see cref="SteelSheathing"/> based on thickness.
    /// </summary>
    public static bool operator <(SteelSheathing left, SteelSheathing right) => left.CompareTo(right) < 0;

    /// <summary>
    /// Greater than or equal operator for <see cref="SteelSheathing"/> based on thickness.
    /// </summary>
    public static bool operator >=(SteelSheathing left, SteelSheathing right) => left.CompareTo(right) >= 0;

    /// <summary>
    /// Less than or equal operator for <see cref="SteelSheathing"/> based on thickness.
    /// </summary>
    public static bool operator <=(SteelSheathing left, SteelSheathing right) => left.CompareTo(right) <= 0;
}