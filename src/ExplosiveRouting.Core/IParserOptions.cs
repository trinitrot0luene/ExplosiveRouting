namespace ExplosiveRouting
{
    /// <summary>
    /// Configuration options for an <see cref="IParser"/>.
    /// </summary>
    public interface IParserOptions
    {
        /// <summary>
        /// Gets or sets which characters will be considered whitespace and delimit tokens.
        /// </summary>
        char[] WhitespaceChars { get; set; }

        /// <summary>
        /// Gets or sets which characters will be considered grouping control characters.
        /// </summary>
        char[] GroupingChars { get; set; }

        /// <summary>
        /// Gets or sets which characters will be considered escape control characters.
        /// </summary>
        char[] EscapeChars { get; set; }

        /// <summary>
        /// Validates that the configuration is suitable for use in the instantiation of an <see cref="IParser"/>.
        /// </summary>
        void Validate();
    }
}