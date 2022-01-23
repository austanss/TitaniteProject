
namespace TitaniteProject.Toolchain.Exceptions;

internal class SyntaxParserException : ToolchainException
{
    public SyntaxParserException(string message) : base(message) { }

    public SyntaxParserException() : base("An error occurred during syntax parsing.") { }

    public override void Throw(string message) { throw new SyntaxParserException(message); }
}
