using AISI.S240.DotNet.ChapterB.Entities;
using AISI.S240.DotNet.Core;

namespace AISI.S240.DotNet.ChapterB;

/// <summary>
/// Table B5.2.2.3-2, Unit nominal shear strength vn for shear walls with wood structural panel sheathing on one side of the wall
/// </summary>
public static class TableB5_2_2_3__2_US_Mexico
{
    /// <summary>
    /// Inner class to represent the rows of the table.
    /// </summary>
    /// <remarks>
    /// Must be record so that the GenericTable.Match function can return null if nothing is found.
    /// </remarks>
    private record Row(
        double SheathingThickness,
        SheathingType SheathingType,    
        SheathingOrientation SheathingOrientation,  
        double MaxAspectRatio,  
        PanelFastenerSpacing FastenerSpacing,
        int DesignationThickness,
        double NominalShearStrength);

 

    /// <summary>
    /// Internal data structure to hold the rows of the table.
    /// </summary>
    private static readonly GenericTable<Row> _table;

    /// <summary>
    /// Table label formatted as used in the AISI-S240 standard.
    /// </summary>
    public static string Label => GetTableLabel();

    /// <summary>
    /// Table name as used in the AISI-S240 standard (2020).
    /// </summary>
    public static string Name => "Unit nominal shear strength vn for shear walls with wood structural panel sheathing on one side of the wall";

    static TableB5_2_2_3__2_US_Mexico()
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
            
            sheathingThickness >= row.SheathingThickness &&
            sheathingType == row.SheathingType &&
            sheathingOrientation == row.SheathingOrientation || (row.SheathingOrientation == SheathingOrientation.ParallelOrPerpendicularToFraming) &&
            aspectRatio <= row.MaxAspectRatio &&
            fastenerSpacing.IsComparable(row.FastenerSpacing) && fastenerSpacing <= row.FastenerSpacing &&
            designationThickness >= row.DesignationThickness);
        
        var valueSelector = new Func<Row, double>(row => row.NominalShearStrength);
        var findMaximum = true; // Find the maximum shear strength

        var result = _table.Match(predicate, valueSelector, findMaximum);

        return result?.NominalShearStrength;
    }

    /// <summary>
    /// Export the table to a JSON string.
    /// </summary>
    public static string ExportToJson()
    {
        return _table.ToJson();
    }

    /// <summary>
    /// Initialize the table with the data
    /// </summary>
    /// <returns>Table with data initialized</returns>
    private static GenericTable<Row> Initialize()
    {
        var table = new GenericTable<Row>();
        table.AddRow(new Row(15.0/32.0, SheathingType.Structural1Plywood4Ply, SheathingOrientation.ParallelOrPerpendicularToFraming, 2.0, new PanelFastenerSpacing(6, 12), 43, 1065.0));
        table.AddRow(new Row(15.0/32.0, SheathingType.Structural1Plywood4Ply, SheathingOrientation.ParallelOrPerpendicularToFraming, 2.0, new PanelFastenerSpacing(4, 12), 43, 1410.0));
        table.AddRow(new Row(15.0/32.0, SheathingType.Structural1Plywood4Ply, SheathingOrientation.ParallelOrPerpendicularToFraming, 2.0, new PanelFastenerSpacing(3, 12), 43, 1735.0));
        table.AddRow(new Row(15.0/32.0, SheathingType.Structural1Plywood4Ply, SheathingOrientation.ParallelOrPerpendicularToFraming, 2.0, new PanelFastenerSpacing(2, 12), 43, 1910.0));
        
        table.AddRow(new Row(7.0/16, SheathingType.RatedSheathingOSB, SheathingOrientation.ParallelToFraming, 2.0, new PanelFastenerSpacing(6, 12), 33, 910.0));
        table.AddRow(new Row(7.0/16, SheathingType.RatedSheathingOSB, SheathingOrientation.ParallelToFraming, 2.0, new PanelFastenerSpacing(4, 12), 33, 1410.0));
        table.AddRow(new Row(7.0/16, SheathingType.RatedSheathingOSB, SheathingOrientation.ParallelToFraming, 2.0, new PanelFastenerSpacing(3, 12), 33, 1735.0));
        table.AddRow(new Row(7.0/16, SheathingType.RatedSheathingOSB, SheathingOrientation.ParallelToFraming, 2.0, new PanelFastenerSpacing(2, 12), 33, 1910.0));
        
        table.AddRow(new Row(7.0/16, SheathingType.RatedSheathingOSB, SheathingOrientation.PerpendicularToFraming, 2.0, new PanelFastenerSpacing(6, 12), 33, 1020.0));
        
        table.AddRow(new Row(7.0/16, SheathingType.RatedSheathingOSB, SheathingOrientation.ParallelOrPerpendicularToFraming, 4.0, new PanelFastenerSpacing(4, 12), 33, 1025.0));
        table.AddRow(new Row(7.0/16, SheathingType.RatedSheathingOSB, SheathingOrientation.ParallelOrPerpendicularToFraming, 4.0, new PanelFastenerSpacing(3, 12), 33, 1425.0));
        table.AddRow(new Row(7.0/16, SheathingType.RatedSheathingOSB, SheathingOrientation.ParallelOrPerpendicularToFraming, 4.0, new PanelFastenerSpacing(2, 12), 33, 1825.0));
        
        return table;
    }

    /// <summary>
    /// Internal function to convert the table class name to a table name.
    /// </summary>
    /// <returns>Table name</returns>
    private static string GetTableLabel()
    {
        var className = nameof(TableB5_2_2_3__2_US_Mexico);
        var tableNumber = className
            .Replace("Table", "")
            .Replace("__", "-")
            .Replace("_", ".");

        return $"Table {tableNumber}";
    }
}