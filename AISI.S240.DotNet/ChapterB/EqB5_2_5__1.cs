using AISI.S240.DotNet.Core;

namespace AISI.S240.DotNet.ChapterB;

/// <summary>
/// Eq. B5.2.5-1 in the AISI-S240 standard (2020).
/// </summary>
public static class EqB5_2_5__1
{
    public static string Label => Labeler.GetEquationLabel(nameof(EqB5_2_5__1));

    /// <summary>
    /// Calculates the total deflection (δ) of a shear wall system using 
    /// Equation B5.2.5-1 from the AISI S240-20 standard (2020 edition).
    /// </summary>
    /// <param name="Ac">Gross cross-sectional area of the chord member (in²).</param>
    /// <param name="b">Length of the shear wall (in).</param>
    /// <param name="Es">Modulus of elasticity of the steel (psi).</param>
    /// <param name="G">Shear modulus of the sheathing material (psi).</param>
    /// <param name="h">Height of the wall (in).</param>
    /// <param name="t_sheathing">Nominal panel thickness of sheathing (in).</param>
    /// <param name="v">Shear demand (lb/in), calculated as V/b.</param>
    /// <param name="beta">Material-specific slip coefficient (e.g., for OSB, plywood, or steel sheathing). 29.21(t_sheathing/0.018) for steel.</param>
    /// <param name="delta_v">Vertical deformation from anchorage/attachment details (in).</param>
    /// <param name="rho">Coefficient dependent on sheathing type (dimensionless). 0.075(t_sheathing/0.018) for steel.</param>
    /// <param name="omega1">Deflection calculation factor 1.</param>
    /// <param name="omega2">Deflection calculation factor 2.</param>
    /// <param name="omega3">Deflection calculation factor 3.</param>
    /// <param name="omega4">Deflection calculation factor 4.</param>
    /// <returns>Total deflection δ (inches) of the shear wall.</returns>
    public static double Calculate(
        double Ac,
        double b,
        double Es,
        double G,
        double h,
        double t_sheathing,
        double v,
        double beta,
        double delta_v,
        double rho,
        double omega1,
        double omega2,
        double omega3,
        double omega4,
        out EquationResultDetails details)
    {
        var delta1 = 2 * v * Math.Pow(h, 3.0) / (3 * Es * Ac * b);

        var delta2 = omega1 * omega2 * v * h / (rho * G * t_sheathing);

        var delta3 = Math.Pow(omega1, 5.0 / 4.0) * omega2 * omega3 * omega4 * Math.Pow(v / beta, 2.0);
        
        var delta4 =  + h / b * delta_v;

        var delta = delta1 + delta2 + delta3 + delta4;

        details = new EquationResultDetails();
        details.AddDetail(name: "delta",
            value: delta,
            description: "Total deflection (δ) of the shear wall, per Eq. B5.2.5-1 in AISI S240-20.",
            reference: Label
        );
        details.AddDetail("Ac", Ac, "Gross cross-sectional area of the chord member (in²).", "");
        details.AddDetail("b", b, "Length of the shear wall (in).", "");
        details.AddDetail("Es", Es, "Modulus of elasticity of the steel (psi).", "");
        details.AddDetail("G", G, "Shear modulus of the sheathing material (psi).", "");
        details.AddDetail("h", h, "Height of the wall (in).", "");
        details.AddDetail("t_sheathing", t_sheathing, "Nominal panel thickness of sheathing (in).", "");
        details.AddDetail("v", v, "Shear demand (lb/in), calculated as V/b.", "");
        details.AddDetail("beta", beta, "Material-specific slip coefficient (e.g., for OSB, plywood, or steel sheathing).", "");
        details.AddDetail("delta_v", delta_v, "Vertical deformation from anchorage/attachment details (in).", "");
        details.AddDetail("rho", rho, "Coefficient dependent on sheathing type (dimensionless).", "");
        details.AddDetail("omega1", omega1, "Deflection calculation factor 1.", "");
        details.AddDetail("omega2", omega2, "Deflection calculation factor 2.", "");
        details.AddDetail("omega3", omega3, "Deflection calculation factor 3.", "");
        details.AddDetail("omega4", omega4, "Deflection calculation factor 4.", "");
        
        return delta;
    }
}
