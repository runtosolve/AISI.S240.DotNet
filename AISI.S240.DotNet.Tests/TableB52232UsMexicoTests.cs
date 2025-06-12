using RunToSolve.AISI.S240.DotNet.ChapterB;
using RunToSolve.AISI.S240.DotNet.ChapterB.Entities;
using FluentAssertions;

namespace RunToSolve.AISI.S240.DotNetTests;

public class TableB52232UsMexicoTests
{
    [Fact]
    public void LookUpValue_WithValidConditions_ReturnCorrectValue()
    {
        // Act
        var value = TableB5_2_2_3__2_US_Mexico.LookUp(sheathingThickness: 15.0/32.0, sheathingType: SheathingType.Structural1Plywood4Ply, aspectRatio: 1.0, fastenerEdgeSpacing: 6, fastenerFieldSpacing: 10, designationThickness: 43);
        
        // Assert
        value.Should().BeApproximately(1065.0, 1E-3);
    }

    [Fact]
    public void LookUpValue_WithOutValidConditions_ReturnCorrectValue()
    {
        // Act
        var value = TableB5_2_2_3__2_US_Mexico.LookUp(sheathingThickness: 7.0/16.0, sheathingType: SheathingType.RatedSheathingOSB, aspectRatio: 1.0, fastenerEdgeSpacing: 6, fastenerFieldSpacing: 24, designationThickness: 43);
        
        // Assert
        value.Should().BeNull();
    }
    
    [Fact]
    public void LookUpValue_WithSheathingChoiceConditions_ReturnCorrectValue()
    {
        // Act
        var value = TableB5_2_2_3__2_US_Mexico.LookUp(sheathingThickness: 7.0/16.0, sheathingType: SheathingType.RatedSheathingOSB, aspectRatio: 1.0, fastenerEdgeSpacing: 6, fastenerFieldSpacing: 12, designationThickness: 43, SheathingOrientation.PerpendicularToFraming);
        
        // Assert
        value.Should().BeApproximately(1020.0, 1E-3);
    }
    

    [Fact]
    public void ExportToJson_ReturnsValidJson()
    {
        // Act
        var json = TableB5_2_2_3__2_US_Mexico.ExportToJson();

        // Assert
        json.Should().Contain("\"nominal_shear_strength\": 1065");
    }
}