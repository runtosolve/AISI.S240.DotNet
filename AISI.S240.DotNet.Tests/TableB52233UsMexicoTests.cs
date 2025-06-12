using RunToSolve.AISI.S240.DotNet.ChapterB;
using RunToSolve.AISI.S240.DotNet.ChapterB.Entities;

namespace RunToSolve.AISI.S240.DotNetTests;

public class TableB52233UsMexicoTests
{
    [Fact]
    public void TableB52233UsMexico_LookUp_ValidInputs_ReturnsExpectedValue()
    {
        // Arrange
        var sheathingThickness = 0.5; // Example thickness in inches
        var sheathingType = SheathingType.GypsumBoard; // Example type
        double aspectRatio = 2.0; // Example aspect ratio
        var fastenerEdgeSpacing = 6; // Example edge spacing in inches
        var fastenerFieldSpacing = 12; // Example field spacing in inches
        var designationThickness = 43; // Example designation thickness in mils

        // Act
        var result = TableB5_2_2_3__3_US_Mexico.LookUp(
            sheathingThickness, 
            sheathingType, 
            aspectRatio, 
            fastenerEdgeSpacing, 
            fastenerFieldSpacing, 
            designationThickness);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void TableB52233UsMexico_LookUp_InvalidInputs_ReturnsNull()
    {
        // Arrange
        var sheathingThickness = 0.1; // Invalid thickness
        var sheathingType = SheathingType.GypsumBoard; // Example type
        double aspectRatio = 10.0; // Example aspect ratio
        var fastenerEdgeSpacing = 6; // Example edge spacing in inches
        var fastenerFieldSpacing = 12; // Example field spacing in inches
        var designationThickness = 43; // Example designation thickness in mils

        // Act
        var result = TableB5_2_2_3__3_US_Mexico.LookUp(
            sheathingThickness, 
            sheathingType, 
            aspectRatio, 
            fastenerEdgeSpacing, 
            fastenerFieldSpacing, 
            designationThickness);

        // Assert
        Assert.Null(result);
    }
}