# WinDbg Extension Seed
This project is seed project for creating extensions for WinDbg in C#.

# Debugging your Project
Set your project start action to be an external program, and point it to your windbg.exe. Ensure that your processor architectures match between windbg, your extension target archtecture, and that of the dump. E.g. if your dump is x64, make sure everything else is as well.

Use the following command line arguments (note the lack of space after -a):

    -a"C:\path\to\where\you\clone\stuff\WinDbgExtension\WinDbgExtension\bin\x64\Debug\WinDbgExtension" -z "C:\path\to\dumpfiles\test.dmp"