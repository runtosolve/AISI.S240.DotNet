using Newtonsoft.Json;

namespace RunToSolve.AISI.S240.DotNet.Core;

/// <summary>
/// Stores detailed results for variables used in an equation calculation.
/// </summary>
public class EquationResultDetails
{
    /// <summary>
    /// The list of variable result details.
    /// </summary>
    private readonly IList<VariableResultDetail> _details;

    /// <summary>
    /// Gets the list of variable result details as a read-only list.
    /// </summary>
    public IReadOnlyList<VariableResultDetail> Details => (IReadOnlyList<VariableResultDetail>)_details;

    /// <summary>
    /// Initializes a new instance of the <see cref="EquationResultDetails"/> class.
    /// </summary>
    public EquationResultDetails()
    {
        _details = new List<VariableResultDetail>();
    }

    /// <summary>
    /// Adds a variable result detail to the collection.
    /// </summary>
    /// <param name="name">The variable name.</param>
    /// <param name="value">The variable value.</param>
    /// <param name="description">A description of the variable.</param>
    /// <param name="reference">A reference for the variable (e.g., code or standard).</param>
    public void AddDetail(string name, double value, string description, string reference)
    {
        var detail = new VariableResultDetail(name, value, description, reference);
        _details.Add(detail);
    }

    /// <summary>
    /// Serializes the details to a JSON string.
    /// </summary>
    public string ToJson()
    {
        return JsonConvert.SerializeObject(_details);
    }
}