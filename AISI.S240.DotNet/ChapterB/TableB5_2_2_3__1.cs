using AISI.S240.DotNet.ChapterB.Entity;
using AISI.S240.DotNet.Core;

namespace AISI.S240.DotNet.ChapterB;

/// <summary>
/// Table B5.2.2.3-1, Unit nominal shear strength vn for shear walls with steel sheet sheathing on one side of the wall
/// </summary>
public static class TableB5_2_2_3__1
{
    /// <summary>
    /// Inner class to represent the rows of the table.
    /// </summary>
    /// <remarks>
    /// Must be record so that the GenericTable.Match function can return null if nothing is found.
    /// </remarks>
    private record Row(
        double SteelSheathingThickness,
        double MaxAspectRatio,
        PanelFastenerSpacing FastenerSpacing,
        bool StudBlockingRequired,
        int DesignationThickness,
        int ScrewSize,
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
    /// Table name as used in the AISI-S240 standard.
    /// </summary>
    public static string Name => "Unit nominal shear strength vn for shear walls with steel sheet sheathing on one side of the wall";

    static TableB5_2_2_3__1()
    {
        _table = Initialize();
    }

    /// <summary>
    /// Looks up the nominal shear strength value from the table based on the provided filter criteria.
    /// Returns the maximum matching value unless otherwise specified.
    /// </summary>
    /// <param name="steelSheathingThickness">Steel sheathing thickness (inches)</param>
    /// <param name="aspectRatio">Aspect ratio.</param>
    /// <param name="fastenerEdgeSpacing">Fastener spacing at panel edges</param>
    /// <param name="fastenerFieldSpacing">Fastener spacing at panel field</param>
    /// <param name="useStudBlocking">Whether stud blocking is used</param>
    /// <param name="designationThickness">Designation thickness of stud, track and blocking (mills)</param>
    /// <param name="screwSize">Sheathing screw size (e.g., 8, 10)</param>
    /// <returns>
    /// The nominal shear strength value if a matching row is found; otherwise, null.
    /// </returns>
    public static double? LookUp(double steelSheathingThickness, double aspectRatio, int fastenerEdgeSpacing, int fastenerFieldSpacing, bool useStudBlocking,
        int designationThickness, int? screwSize)
    {
        var fastenerSpacing = new PanelFastenerSpacing(fastenerEdgeSpacing, fastenerFieldSpacing);

        var predicate = new Func<Row, bool>(row =>
            (steelSheathingThickness >= row.SteelSheathingThickness) &&
            (aspectRatio <= row.MaxAspectRatio) &&
            (fastenerSpacing.IsComparable(row.FastenerSpacing) && fastenerSpacing <= row.FastenerSpacing) &&
            (useStudBlocking || !row.StudBlockingRequired) &&
            (designationThickness >= row.DesignationThickness) &&
            (screwSize >= row.ScrewSize));
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
        table.AddRow(new Row(0.018, 2.0, new PanelFastenerSpacing(6, 12), false, 33, 8, 485.0));

        table.AddRow(new Row(0.027, 4.0, new PanelFastenerSpacing(4, 12), false, 43, 8, 1000.0));
        table.AddRow(new Row(0.027, 4.0, new PanelFastenerSpacing(3, 12), false, 43, 8, 1085.0));
        table.AddRow(new Row(0.027, 4.0, new PanelFastenerSpacing(2, 12), false, 43, 8, 1170.0));

        table.AddRow(new Row(0.027, 4.0, new PanelFastenerSpacing(6, 12), false, 33, 8, 645.0));
        table.AddRow(new Row(0.027, 4.0, new PanelFastenerSpacing(4, 12), false, 33, 8, 710.0));
        table.AddRow(new Row(0.027, 4.0, new PanelFastenerSpacing(3, 12), false, 33, 8, 780.0));
        table.AddRow(new Row(0.027, 4.0, new PanelFastenerSpacing(2, 12), false, 33, 8, 845.0));

        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(6, 12), false, 33, 8, 795.0));
        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(4, 12), false, 33, 8, 960.0));
        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(3, 12), false, 33, 8, 1005.0));
        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(2, 12), false, 33, 8, 1055.0));

        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(6, 12), false, 43, 8, 910.0));
        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(4, 12), false, 43, 8, 1015.0));
        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(3, 12), false, 43, 8, 1040.0));
        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(2, 12), false, 43, 8, 1070.0));

        table.AddRow(new Row(0.030, 4.0, new PanelFastenerSpacing(2, 12), true, 43, 10, 1355.0));

        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(6, 12), false, 33, 8, 1035.0));
        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(4, 12), false, 33, 8, 1145.0));
        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(3, 12), false, 33, 8, 1225.0));
        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(2, 12), false, 33, 8, 1300.0));

        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(6, 12), false, 43, 8, 1055.0));
        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(4, 12), false, 43, 8, 1170.0));
        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(3, 12), false, 43, 8, 1235.0));
        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(2, 12), false, 43, 8, 1305.0));

        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(2, 12), true, 43, 10, 1505.0));

        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(2, 12), false, 54, 8, 1870.0));

        table.AddRow(new Row(0.033, 4.0, new PanelFastenerSpacing(2, 12), true, 54, 10, 2085.0));
        return table;
    }

    /// <summary>
    /// Internal function to convert the table class name to a table name.
    /// </summary>
    /// <returns>Table name</returns>
    private static string GetTableLabel()
    {
        var className = nameof(TableB5_2_2_3__1);
        var tableNumber = className
            .Replace("Table", "")
            .Replace("__", "-")
            .Replace("_", ".");

        return $"Table {tableNumber}";
    }
}