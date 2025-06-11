using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RunToSolve.AISI.S240.DotNet.Core;

internal class GenericTable<TRow>
{
    /// <summary>
    /// Internal data structure to hold the rows of the table.
    /// </summary>
    private readonly IList<TRow> _rows = new List<TRow>();

    /// <summary>
    /// Read-only property to access the rows of the table.
    /// </summary>
    internal IReadOnlyList<TRow> Rows => (IReadOnlyList<TRow>)_rows;

    /// <summary>
    /// Add a row to the table.
    /// </summary>
    /// <param name="row">Row to add</param>
    internal void AddRow(TRow row)
    {
        _rows.Add(row);
    }

    /// <summary>
    /// Match a row in the table based on a predicate and return the first matching row.
    /// </summary>
    /// <param name="predicate">Function for the matching criteria</param>
    /// <param name="valueSelector">Function to select which value in the row to select for comparison</param>
    /// <param name="findMaximum">Whether to find the row with the maximum value or minimum value</param>
    /// <returns>The row matched</returns>
    internal TRow? Match(Func<TRow, bool> predicate, Func<TRow, double> valueSelector, bool findMaximum = true)
    {
        var matches = _rows.Where(predicate).ToList();

        if (matches.Count == 0) return default;

        return findMaximum
            ? matches.OrderByDescending(valueSelector).FirstOrDefault()
            : matches.OrderBy(valueSelector).FirstOrDefault();
    }

    /// <summary>
    /// Serializes the table rows to a JSON string using snake_case property naming.
    /// </summary>
    /// <remarks>
    /// Lower snake_case is used for the JSON property names.
    /// It is easier to represent engineering data in snake_case format (e.g., k_t vs. kT).
    /// </remarks>
    internal string ToJson()
    {
        return JsonConvert.SerializeObject(
            _rows,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            }
        );
    }
}