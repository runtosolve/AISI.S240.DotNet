using RunToSolve.AISI.S240.DotNet.ChapterB;
using FluentAssertions;

namespace RunToSolve.AISI.S240.DotNetTests;

public class TableB52231UsMexicoTests
{
    [Fact]
    public void LookUpValue_WithValidConditions_ReturnCorrectValue()
    {
        // Act
        var value = TableB5_2_2_3__1_US_Mexico.LookUp(steelSheathingThickness: 0.018, aspectRatio: 1.0, fastenerEdgeSpacing: 6, fastenerFieldSpacing: 10, useStudBlocking: true, 43, 8);

        // Assert
        value.Should().BeApproximately(485.0, 1E-3);
    }

    [Fact]
    public void LookUpValue_WithInValidConditions_ReturnCorrectValue()
    {
        // Act
        var value = TableB5_2_2_3__1_US_Mexico.LookUp(steelSheathingThickness: 0.016, aspectRatio: 1.0, fastenerEdgeSpacing: 6, fastenerFieldSpacing: 24, useStudBlocking: false, 43, 8);

        // Assert
        value.Should().BeNull();
    }

    [Fact]
    public void ExportToJson_ReturnsValidJson()
    {
        // Act
        var json = TableB5_2_2_3__1_US_Mexico.ExportToJson();

        // Assert
        json.Should().Contain("\"nominal_shear_strength\": 485");
    }
}