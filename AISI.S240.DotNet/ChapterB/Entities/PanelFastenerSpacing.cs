namespace AISI.S240.DotNet.ChapterB.Entity;

public record PanelFastenerSpacing(int Edge, int Field)
{
    /// <summary>
    /// Whether this <see cref="PanelFastenerSpacing"/> is comparable to another <see cref="PanelFastenerSpacing"/>.
    /// </summary>
    /// <param name="other">Other <see cref="PanelFastenerSpacing"/> to compare</param>
    /// <returns>True if the two <see cref="PanelFastenerSpacing"/> instances are comparable; otherwise, false.</returns>
    /// <remarks>
    /// Two <see cref="PanelFastenerSpacing"/> instances are comparable if:
    /// Both edge and field spacing are less than or equal to each other,
    /// Both edge and field spacing are greater than or equal to each other,
    /// </remarks>
    public bool IsComparable(PanelFastenerSpacing? other)
    {
        if (other == null) return true;

        if (other.Edge >= Edge && other.Field >= Field) return true;

        if (other.Edge <= Edge && other.Field <= Field) return true;

        return false;
    }

    /// <summary>
    /// Greater than operator for <see cref="PanelFastenerSpacing"/> assuming the two pass the <see cref="IsComparable"/>.
    /// </summary>
    public static bool operator >(PanelFastenerSpacing left, PanelFastenerSpacing right) => left.Edge > right.Edge || left.Field > right.Field;

    /// <summary>
    /// Less than operator for <see cref="PanelFastenerSpacing"/> assuming the two pass the <see cref="IsComparable"/>.
    /// </summary>
    public static bool operator <(PanelFastenerSpacing left, PanelFastenerSpacing right) => left.Edge < right.Edge || left.Field < right.Field;

    /// <summary>
    /// Greater than or equal operator for <see cref="PanelFastenerSpacing"/> assuming the two pass the <see cref="IsComparable"/>.
    /// </summary>
    public static bool operator >=(PanelFastenerSpacing left, PanelFastenerSpacing right) => left.Edge >= right.Edge || left.Field >= right.Field;

    /// <summary>
    /// Less than or equal operator for <see cref="PanelFastenerSpacing"/> assuming the two pass the <see cref="IsComparable"/>.
    /// </summary>
    public static bool operator <=(PanelFastenerSpacing left, PanelFastenerSpacing right) => left.Edge <= right.Edge || left.Field <= right.Field;
}