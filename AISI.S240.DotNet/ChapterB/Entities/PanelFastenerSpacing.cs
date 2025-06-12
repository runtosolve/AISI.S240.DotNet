namespace RunToSolve.AISI.S240.DotNet.ChapterB.Entities;

/// <summary>
/// Represents the spacing of fasteners along the edge and field of a panel.
/// </summary>
public record PanelFastenerSpacing
{
    /// <summary>
    /// Gets the spacing of fasteners at the panel edge (inches).
    /// </summary>
    public int Edge { get; init; }

    /// <summary>
    /// Gets the spacing of fasteners in the panel field (inches).
    /// </summary>
    public int Field { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PanelFastenerSpacing"/> record.
    /// </summary>
    /// <param name="edge">Spacing of fasteners at the panel edge (inches).</param>
    /// <param name="field">Spacing of fasteners in the panel field (inches).</param>
    public PanelFastenerSpacing(int edge, int field)
    {
        Edge = edge;
        Field = field;
    }

    public static bool operator >(PanelFastenerSpacing left, PanelFastenerSpacing right)
        => left.Edge > right.Edge || (left.Edge == right.Edge && left.Field > right.Field);

    public static bool operator <(PanelFastenerSpacing left, PanelFastenerSpacing right)
        => left.Edge < right.Edge || (left.Edge == right.Edge && left.Field < right.Field);

    public static bool operator >=(PanelFastenerSpacing left, PanelFastenerSpacing right)
        => left.Edge > right.Edge || (left.Edge == right.Edge && left.Field >= right.Field);

    public static bool operator <=(PanelFastenerSpacing left, PanelFastenerSpacing right)
        => left.Edge < right.Edge || (left.Edge == right.Edge && left.Field <= right.Field);
}