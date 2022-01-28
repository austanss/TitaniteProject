# Titanite Project [WIP]
A work-in-progress project that aims to create a secured, managed, and strictly typed language, built on a virtual platform.

**Final name undecided.*

## Planned Design
The Titanite Project aims to have three distinct parts:

 - The **toolchain**, which will compile abstracted (Ti) and assembly code, to an encrypted assembly.
   - The frontends will parse Ti code or assembly code and generate parsed objects.
   - The backend will finalize parsed objects, and:
     - obfuscate it
     - encrypt it
     - generate an executable
     
 - The **platform**, which will decrypt the code and execute it.
 
 - The **front-end**, the program which will initiate the platform and provide facilities for it to execute (input, output, etc.).
   - The front-end component can be interchangeable per needs, which is why the platform and front-end are distinctly separate.

The Titanite Project is built on the .NET 6 platform (execution API targets .NET Standard 2.1). 

### Why .NET?
.NET is a managed runtime, binary-portable between platforms, and is incredibly trivial to program in.

The major downside with .NET is execution speed. Why make that trade-off?

The Titanite Project does not target low-power or embedded environments. 

Large execution overhead is an issue that may be addressed in the future.

## Work in progress
The Titanite Project is under active development.

These features have been implemented as of P3:
 
 - The **platform**
   - Interpreted bytecode
   - Simple execution with minimal instructions
     - text output
     - variables
     - contexts/call stacks
     - functions
     - comments
     - arithmetic
 - The **front-end**
   - Basic console app
   - Parses a basic configuration
   - Loads the program, reads manifest
 - The **toolchain** -*NEW!*
   - Parses assembly source code
   - Supports multiple source files
   - Generates a nonstandard binary
   - Integrates the manifest
   - Self-contained assembly

As of P3, thanks to .NET portability, the entire repository can be built and ran on any platform implementing the .NET 6 runtime.
