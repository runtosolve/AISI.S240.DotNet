using AISI.S240.DotNet.ChapterB.Entity;
using AISI.S240.DotNet.Core;

namespace AISI.S240.DotNet.ChapterB;

/// <summary>
/// Table B5.2.2.3-1
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
        SteelSheathing Sheathing,
        double MaxAspectRatio,
        PanelFastenerSpacing FastenerSpacing,
        bool StudBlockingRequired,
        int DesignationThickness,
        int ScrewSize,
        double NominalShearStrength);

    /// <summary>
    /// Internal data structure to hold the rows of the table.
    /// </summary>
    private static GenericTable<Row> _table;

    static TableB5_2_2_3__1()
    {
        _table = Initialize();
    }

    /// <summary>
    /// Looks up the nominal shear strength value from the table based on the provided filter criteria.
    /// Returns the maximum matching value unless otherwise specified.
    /// </summary>
    /// <param name="sheathing">Optional filter for steel sheathing thickness.</param>
    /// <param name="aspectRatio">Optional filter for maximum aspect ratio.</param>
    /// <param name="fastenerSpacing">Optional filter for panel fastener spacing.</param>
    /// <param name="studBlocking">Optional filter for stud blocking requirement.</param>
    /// <param name="designationThickness">Optional filter for designation thickness.</param>
    /// <param name="screwSize">Optional filter for screw size.</param>
    /// <returns>
    /// The nominal shear strength value if a matching row is found; otherwise, null.
    /// </returns>
    public static double? LookUpValue(SteelSheathing? sheathing = null, double? aspectRatio = null, PanelFastenerSpacing? fastenerSpacing = null, bool? studBlocking = null,
        int? designationThickness = null, int? screwSize = null)
    {
        var predicate = new Func<Row, bool>(row =>
            (sheathing == null || row.Sheathing <= sheathing) &&
            (aspectRatio == null || row.MaxAspectRatio >= aspectRatio) &&
            (fastenerSpacing == null || row.FastenerSpacing == fastenerSpacing) &&
            (studBlocking == null || row.StudBlockingRequired || row.StudBlockingRequired == studBlocking) &&
            (designationThickness == null || row.DesignationThickness <= designationThickness) &&
            (screwSize == null || row.ScrewSize <= screwSize));
        var valueSelector = new Func<Row, double>(row => row.NominalShearStrength);
        var findMaximum = true; // Find the maximum shear strength
        
        var result = _table.Match(predicate, valueSelector, findMaximum);

        return result != null ? result.NominalShearStrength : null;
    }

    /// <summary>
    /// Initialize the table with the data
    /// </summary>
    /// <returns>Table with data initialized</returns>
    private static GenericTable<Row> Initialize()
    {
        var table = new GenericTable<Row>();
        table.AddRow(new Row(new SteelSheathing(0.018), 2.0, new PanelFastenerSpacing(6, 12), false, 33, 8, 485.0));
        
        table.AddRow(new Row(new SteelSheathing(0.027), 4.0, new PanelFastenerSpacing(4, 12), false, 43, 8, 1000.0));
        table.AddRow(new Row(new SteelSheathing(0.027), 4.0, new PanelFastenerSpacing(3, 12), false, 43, 8, 1085.0));
        table.AddRow(new Row(new SteelSheathing(0.027), 4.0, new PanelFastenerSpacing(2, 12), false, 43, 8, 1170.0));
        
        table.AddRow(new Row(new SteelSheathing(0.027), 4.0, new PanelFastenerSpacing(6, 12), false, 33, 8, 645.0));
        table.AddRow(new Row(new SteelSheathing(0.027), 4.0, new PanelFastenerSpacing(4, 12), false, 33, 8, 710.0));
        table.AddRow(new Row(new SteelSheathing(0.027), 4.0, new PanelFastenerSpacing(3, 12), false, 33, 8, 780.0));
        table.AddRow(new Row(new SteelSheathing(0.027), 4.0, new PanelFastenerSpacing(2, 12), false, 33, 8, 845.0));
        
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(6, 12), false, 33, 8, 795.0));
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(4, 12), false, 33, 8, 960.0));
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(3, 12), false, 33, 8, 1005.0));
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(2, 12), false, 33, 8, 1055.0));
        
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(6, 12), false, 43, 8, 910.0));
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(4, 12), false, 43, 8, 1015.0));
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(3, 12), false, 43, 8, 1040.0));
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(2, 12), false, 43, 8, 1070.0));
        
        table.AddRow(new Row(new SteelSheathing(0.030), 4.0, new PanelFastenerSpacing(2, 12), true, 43, 10, 1355.0));
        
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(6, 12), false, 33, 8, 1035.0));
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(4, 12), false, 33, 8, 1145.0));
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(3, 12), false, 33, 8, 1225.0));
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(2, 12), false, 33, 8, 1300.0));
        
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(6, 12), false, 43, 8, 1055.0));
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(4, 12), false, 43, 8, 1170.0));
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(3, 12), false, 43, 8, 1235.0));
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(2, 12), false, 43, 8, 1305.0));
        
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(2, 12), true, 43, 10, 1505.0));
        
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(2, 12), false, 54, 8, 1870.0));
        
        table.AddRow(new Row(new SteelSheathing(0.033), 4.0, new PanelFastenerSpacing(2, 12), true, 54, 10, 2085.0));
        
        return table;
    }
}