namespace AISI.S240.DotNet.ChapterB.Entity;

public record PanelFastenerSpacing(int Edge, int Field) : IComparable<PanelFastenerSpacing>
{
    /// <summary>
    /// Compares this instance to another <see cref="PanelFastenerSpacing"/> based on edge and field spacing.
    /// Returns 0 if both edge and field are equal, 1 if both are greater, -1 if both are less,
    /// otherwise compares edge and field individually for ordering.
    /// When both edge and field are different, break tie using edge first.
    /// </summary>
    /// <param name="other">The other <see cref="PanelFastenerSpacing"/> to compare to.</param>
    /// <returns>
    /// 0 if equal, 1 if this is less than other, -1 if this is greater than other, based on edge and field spacing.
    /// </returns>
    public int CompareTo(PanelFastenerSpacing? other)
    {
        if (other == null) return 1;

        if (other.Edge == Edge && other.Field == Field) return 0;

        if (other.Edge > Edge && other.Field > Field) return 1;

        if (other.Edge < Edge && other.Field < Field) return -1;

        if (other.Edge == Edge && other.Field > Field) return -1;

        if (other.Edge > Edge && other.Field == Field) return -1;

        return other.Edge > Edge ? 1 : -1;
    }

    /// <summary>
    /// Greater than operator for <see cref="PanelFastenerSpacing"/> based on <see cref="CompareTo"/>.
    /// </summary>
    public static bool operator >(PanelFastenerSpacing left, PanelFastenerSpacing right) => left.CompareTo(right) > 0;

    /// <summary>
    /// Less than operator for <see cref="PanelFastenerSpacing"/> based on <see cref="CompareTo"/>.
    /// </summary>
    public static bool operator <(PanelFastenerSpacing left, PanelFastenerSpacing right) => left.CompareTo(right) < 0;

    /// <summary>
    /// Greater than or equal operator for <see cref="PanelFastenerSpacing"/> based on <see cref="CompareTo"/>.
    /// </summary>
    public static bool operator >=(PanelFastenerSpacing left, PanelFastenerSpacing right) => left.CompareTo(right) >= 0;

    /// <summary>
    /// Less than or equal operator for <see cref="PanelFastenerSpacing"/> based on <see cref="CompareTo"/>.
    /// </summary>
    public static bool operator <=(PanelFastenerSpacing left, PanelFastenerSpacing right) => left.CompareTo(right) <= 0;
}