using FluentAssertions;

namespace RunToSolve.AISI.S240.DotNetTests;

using RunToSolve.AISI.S240.DotNet.ChapterB;

public class EqB5_2_5__1Tests
{
    [Fact]
    public void Calculate_ReturnCorrectValue()
    {
        // Arrange
        var Ac = 1.0;
        var b = 96.0;
        var Es = 29500.0E3;
        var G = 11300.0E3;
        var h = 96.0;
        var t_sheathing = 0.018;
        var v = 20.0;
        var beta = 29.12 * (t_sheathing / 0.018);
        var delta_v = 0.0;
        var rho = 0.075 * (t_sheathing / 0.018);
        var omega1 = 1.0;
        var omega2 = 1.0;
        var omega3 = 1.0;
        var omega4 = 1.0;
        
        
        // Act
        var delta = EqB5_2_5__1.Calculate(Ac, b, Es, G, h, t_sheathing, v, beta, delta_v, rho, omega1, omega2, omega3, omega4, out _);
        
        // Assert
        delta.Should().BeApproximately(0.60174, 1E-3);
    }

    [Fact]
    public void ToJson_ReturnCorrectJson()
    {
        // Arrange
        var Ac = 1.0;
        var b = 96.0;
        var Es = 29500.0E3;
        var G = 11300.0E3;
        var h = 96.0;
        var t_sheathing = 0.018;
        var v = 20.0;
        var beta = 29.12 * (t_sheathing / 0.018);
        var delta_v = 0.0;
        var rho = 0.075 * (t_sheathing / 0.018);
        var omega1 = 1.0;
        var omega2 = 1.0;
        var omega3 = 1.0;
        var omega4 = 1.0;
        EqB5_2_5__1.Calculate(Ac, b, Es, G, h, t_sheathing, v, beta, delta_v, rho, omega1, omega2, omega3, omega4, out var details);
        
        // Act
        var json = details.ToJson();
        
        // Assert
        json.Should().Contain("\"Name\":\"delta\"");
        json.Should().Contain("\"Value\":0.601738");
    }
}