# Titanite Project [WIP]
A work-in-progress project that aims to create a secured, managed, and strictly typed language, built on a virtual platform.

## Planned Design
The Titanite Project aims to have three distinct parts:

 - The **compiler**, which will compile a future abstracted language to an encrypted assembly.
   - The front-end will translate abstracted Titanite code to raw Titanite assembly code.
   - The back-end will assemble Titanite assembly into bytecode,
     - obfuscate it
     - encrypt it
     - package it into an executable
 - The **platform**, which will decrypt the code and execute it.
 - The **front-end**, the program which will initiate the platform and provide facilities for it to execute (input, output, etc.).
   - This part of the triad will be platform-locked, which is why the platform and front-end are distinctly separate, so as to increase portability.

The Titanite Project is coded in C#, on the .NET Standard 2.1 platform (with the front-end in .NET 6). 
This choice was deliberate, because not only does it make portability easier, but it also is a managed platform. 

None of the source code is written in an unsafe context.
This makes memory leaks nigh-impossible, and no unmanaged code is intended to be written in the future.

## Work in progress
The Titanite Project is under active development.

These features have been implemented as of P1:
 
 - The **platform**
   - Directly-interpreted assembly (instead of bytecode)
   - Basic execution with limited capabilities
     - text output
     - variables
     - local/global context (no call stack)
     - basic functions (can't return to caller, glorified `jmp`)
     - comments
 - The **front-end**
   - Basic console app
   - Parses a basic configuration
   - Parses a basic manifest
   - Loads the program

As of P1, due to the simple nature of the front-end, it can be ran on:
 - Windows (.NET 6)
 - macOS (.NET 6)
 - Linux (.NET 6)