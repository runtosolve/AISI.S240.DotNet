using AISI.S240.DotNet.ChapterB;
using AISI.S240.DotNet.ChapterB.Entity;

namespace AISI.S240.DotNetTests;

public class TableB5_2_2_3__1Tests
{
    [Fact]
    public void LookUpValue_WithValidConditions_ReturnCorrectValue()
    {
        // Arrange
        var steelSheathing = new SteelSheathing(0.018);
        var fastenerSpacing = new PanelFastenerSpacing(6, 12);
        
        // Act
        var value = TableB5_2_2_3__1.LookUpValue(sheathing: steelSheathing, fastenerSpacing: fastenerSpacing);
        
        // Assert
        Assert.NotNull(value);
        Assert.Equal(485.0, value);
    }
    
    [Fact]
    public void LookUpValue_WithInValidConditions_ReturnCorrectValue()
    {
        // Arrange
        var steelSheathing = new SteelSheathing(0.016);
        var fastenerSpacing = new PanelFastenerSpacing(6, 12);
        
        // Act
        var value = TableB5_2_2_3__1.LookUpValue(sheathing: steelSheathing, fastenerSpacing: fastenerSpacing);
        
        // Assert
        Assert.Null(value);
    }
    
    [Fact]
    public void ExportToJson_ReturnsValidJson()
    {
        // Act
        var json = TableB5_2_2_3__1.ExportToJson();
        
        // Assert
        Assert.NotNull(json);
        Assert.Contains("\"nominal_shear_strength\": 485", json);
    }
}