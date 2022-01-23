
namespace TitaniteProject.Toolchain;

internal static class ToolchainError
{
    public static readonly ToolchainError<CompilationInitiationException> TC0000 = new("TC0000", "An internal error occurred, causing compilation contexts to be nullified.");
    public static readonly ToolchainError<InsufficientArgumentsException> TC0001 = new("TC0001", "Insufficient arguments supplied. Please specify a source file.");
    public static readonly ToolchainError<CompilationInitiationException> TC0002 = new("TC0002", "The source language of this file could not be determined. Check your file extension.");

}

internal class ToolchainError<TException> where TException : ToolchainException, new()
{
    internal ToolchainError(string code, string message)
        => Message = $"{code}: {message}";

    public string Message { get; }


    public void Throw(string? file)
    {
        Console.WriteLine($"ERROR: (file: {file}) {Message} [{typeof(TException).Name}]");
        Environment.Exit(-1);
    }
}
