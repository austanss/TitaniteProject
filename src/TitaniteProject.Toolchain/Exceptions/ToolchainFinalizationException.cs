
namespace TitaniteProject.Toolchain.Exceptions;

internal class ToolchainFinalizationException : ToolchainException
{
    public ToolchainFinalizationException(string message) : base(message) { }

    public ToolchainFinalizationException() : base("An error occurred during finalization.") { }

    public override void Throw(string message) { throw new ToolchainFinalizationException(message); }
}
