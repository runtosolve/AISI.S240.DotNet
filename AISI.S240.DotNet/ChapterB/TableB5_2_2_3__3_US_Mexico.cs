using RunToSolve.AISI.S240.DotNet.ChapterB.Entities;
using RunToSolve.AISI.S240.DotNet.Core;

namespace RunToSolve.AISI.S240.DotNet.ChapterB;

public static class TableB5_2_2_3__3_US_Mexico
{
    // <summary>
    /// Inner class to represent the rows of the table.
    /// </summary>
    /// <remarks>
    /// Must be record so that the GenericTable.Match function can return null if nothing is found.
    /// </remarks>
    private record Row(
        double SheathingThickness
        , SheathingType SheathingType
        , SheathingOrientation SheathingOrientation
        , double MaxAspectRatio
        , PanelFastenerSpacing FastenerSpacing
        , int DesignationThickness
        , double NominalShearStrength);

    /// <summary>
    /// Internal data structure to hold the rows of the table.
    /// </summary>
    private static readonly GenericTable<Row> _table;

    /// <summary>
    /// Table label formatted as used in the AISI-S240 standard.
    /// </summary>
    public static string Label => Labeler.GetEquationLabel(nameof(EqB5_2_5__1));

    /// <summary>
    /// Table name as used in the AISI-S240 standard (2020).
    /// </summary>
    public static string Name => "Unit nominal shear strength vn for shear walls with gypsum board panel sheathing on one side of the wall";

    static TableB5_2_2_3__3_US_Mexico()
    {
        _table = Initialize();
    }
    
    /// <summary>
    /// Looks up the nominal shear strength value from the table based on the provided filter criteria.
    /// Returns the maximum matching value unless otherwise specified.
    /// </summary>
    /// <param name="sheathingThickness">Wood structural panel sheathing thickness (inches)</param>
    /// <param name="sheathingType">Type of wood structural panel sheathing, either Structural 1 plywood or OSB</param>
    /// <param name="aspectRatio">Shear wall aspect ratio</param>
    /// <param name="fastenerEdgeSpacing">Fastener spacing at panel edges</param>
    /// <param name="fastenerFieldSpacing">Fastener spacing at panel field</param>
    /// <param name="designationThickness">Designation thickness of stud, track and blocking (mils)</param>
    /// <param name="sheathingOrientation">Orientation of sheathing, either parallel or perpendicular to framing</param>
    /// <returns>
    /// The nominal shear strength value if a matching row is found; otherwise, null.
    /// </returns>
    public static double? LookUp(double sheathingThickness, SheathingType sheathingType, double aspectRatio, int fastenerEdgeSpacing, int fastenerFieldSpacing,
        int designationThickness, SheathingOrientation sheathingOrientation=SheathingOrientation.ParallelToFraming)
    {
        var fastenerSpacing = new PanelFastenerSpacing(fastenerEdgeSpacing, fastenerFieldSpacing);
        
        var predicate = new Func<Row, bool>(row =>
            (sheathingThickness >= row.SheathingThickness) &&
            (sheathingType == row.SheathingType) &&
            (sheathingOrientation == row.SheathingOrientation || row.SheathingOrientation == SheathingOrientation.ParallelOrPerpendicularToFraming) &&
            (aspectRatio <= row.MaxAspectRatio) &&
            (fastenerSpacing <= row.FastenerSpacing) &&
            (designationThickness >= row.DesignationThickness));
        
        var valueSelector = new Func<Row, double>(row => row.NominalShearStrength);
        var findMaximum = true; // Find the maximum shear strength

        var result = _table.Match(predicate, valueSelector, findMaximum);

        return result?.NominalShearStrength;
    }
    
    /// <summary>
    /// Initialize the table with the data
    /// </summary>
    /// <returns>Table with data initialized</returns>
    private static GenericTable<Row> Initialize()
    {
        var table = new GenericTable<Row>();
        table.AddRow(new Row(0.5, SheathingType.GypsumBoard, SheathingOrientation.ParallelOrPerpendicularToFraming, 2.0, new PanelFastenerSpacing(8, 12), 33, 230.0));
        table.AddRow(new Row(0.5, SheathingType.GypsumBoard, SheathingOrientation.ParallelOrPerpendicularToFraming, 2.0, new PanelFastenerSpacing(4, 12), 33, 295.0));
        table.AddRow(new Row(0.5, SheathingType.GypsumBoard, SheathingOrientation.ParallelOrPerpendicularToFraming, 2.0, new PanelFastenerSpacing(7, 7), 33, 290.0));
        table.AddRow(new Row(0.5, SheathingType.GypsumBoard, SheathingOrientation.ParallelOrPerpendicularToFraming, 2.0, new PanelFastenerSpacing(4, 4), 33, 425.0));

        return table;
    }
}