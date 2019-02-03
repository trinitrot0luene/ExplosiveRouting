namespace ExplosiveRouting.Parser
{
    public interface IParserOptions
    {
        char[] WhitespaceChars { get; set; }

        char[] GroupingChars { get; set; }

        char[] EscapeChars { get; set; }

        void Validate();
    }
}