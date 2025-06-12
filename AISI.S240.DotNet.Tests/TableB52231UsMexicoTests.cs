using FluentAssertions;
using RunToSolve.AISI.S240.DotNet.ChapterB;

namespace RunToSolve.AISI.S240.DotNetTests;

public class TableB52231UsMexicoTests
{
    [Theory]
    [InlineData(0.018, 1.0, 6, 10, true, 43, 8, 485.0)]
    [InlineData(0.027, 96.0 / 56.0, 4, 12, false, 43, 8, 1000.0)]
    public void LookUpValue_WithValidConditions_ReturnCorrectValue(double t, double ar, int se, int sf, bool sb, int dt, int ss, double expected)
    {
        // Act
        var value = TableB5_2_2_3__1_US_Mexico.LookUp(steelSheathingThickness: t, aspectRatio: ar, fastenerEdgeSpacing: se, fastenerFieldSpacing: sf, useStudBlocking: sb, designationThickness: dt, screwSize: ss);

        // Assert
        value.Should().BeApproximately(expected, 1E-3);
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