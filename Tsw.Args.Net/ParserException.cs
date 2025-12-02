namespace Tsw.Args.Net
{
    /// <summary>
    /// This exception is thrown when inconsistencies or errors in argument definition classes are discovered during parsing.
    /// It is not related to incorrect syntax provided by a user.
    /// </summary>
    public class ParserException : Exception
    {
        public ParserException(string message)
            : base (message)
        { }

        public ParserException(string syntaxVariantName, string message)
            : base ($"[{syntaxVariantName}] {message}")
        { }

        public ParserException(string syntaxVariantName, string propertyName, string message)
            : base ($"[{syntaxVariantName}.{propertyName}] {message}")
        { }
    }
}
