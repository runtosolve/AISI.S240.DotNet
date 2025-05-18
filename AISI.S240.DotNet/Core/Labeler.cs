namespace AISI.S240.DotNet.Core;

/// <summary>
/// Provides utility methods for generating standardized labels for tables and equations
/// </summary>
internal static class Labeler
{
    /// <summary>
    /// Generates a table label from a class name
    /// following the AISI-S240 standard format.
    /// </summary>
    /// <param name="className">The class name to convert to a table label.</param>
    /// <returns>A formatted table label string.</returns>
    internal static string GetTableLabel(string className)
    {
        var tableNumber = className
            .Replace("Table", "")
            .Replace("__", "-")
            .Replace("_", ".");

        return $"Table {tableNumber}";
    }
    
    /// <summary>
    /// Generates an equation label from a class name
    /// following the AISI-S240 standard format.
    /// </summary>
    /// <param name="className">The class name to convert to an equation label.</param>
    /// <returns>A formatted equation label string.</returns>
    internal static string GetEquationLabel(string className)
    {
        var tableNumber = className
            .Replace("Eq", "")
            .Replace("__", "-")
            .Replace("_", ".");

        return $"Eq. {tableNumber}";
    }
}