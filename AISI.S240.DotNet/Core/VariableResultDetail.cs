namespace RunToSolve.AISI.S240.DotNet.Core;

/// <summary>
    /// Represents a detailed result value with associated metadata.
    /// </summary>
    public record VariableResultDetail
    {
        /// <summary>
        /// Name of the result.
        /// </summary>
        public string Name { get; init; }
        
        /// <summary>
        /// Value of the result.
        /// </summary>
        public double Value { get; init; }
        
        /// <summary>
        /// Description of the result.
        /// </summary>
        public string Description { get; init; }
        
        /// <summary>
        /// Reference or source for the result.
        /// </summary>
        public string Reference { get; init; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableResultDetail"/> record.
        /// </summary>
        /// <param name="name">The name of the result.</param>
        /// <param name="value">The value of the result.</param>
        /// <param name="description">The description of the result.</param>
        /// <param name="reference">The reference or source for the result.</param>
        public VariableResultDetail(string name, double value, string description, string reference)
        {
            Name = name;
            Value = value;
            Description = description;
            Reference = reference;
        }
    }