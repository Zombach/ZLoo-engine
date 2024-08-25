using System;

namespace CSharpGeneratedDemo;

public static class Program
{
    public static void Main(string[] args)
    {
        // Run the various scenarios
        Console.WriteLine("Running HelloWorld:\n");
        UseHelloWorldGenerator.Run();

        Console.WriteLine("\n\nRunning AutoNotify:\n");
        UseAutoNotifyGenerator.Run();
    }
}
