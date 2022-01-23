
namespace TitaniteProject.Toolchain.Exceptions;

internal class ToolchainException : Exception
{
    public ToolchainException() : base("A toolchain error occurred.") { }

    public ToolchainException(string message) : base(message) { }

    public virtual void Throw(string message) { throw new ToolchainException(message); }
}
