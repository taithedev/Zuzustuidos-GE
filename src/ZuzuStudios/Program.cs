using ZuzuStudios.Core;
using ZuzuStudios.Editor;

namespace ZuzuStudios;

internal static class Program
{
    internal static int Main(string[] args)
    {
        if (args.Contains("--help") || args.Contains("-h"))
        {
            Console.WriteLine("ZuzuStudios --project <folder> [--game]");
            return 0;
        }

        try
        {
            string? path = null;
            int index = Array.IndexOf(args, "--project");
            if (index >= 0 && index + 1 < args.Length) path = args[index + 1];
            var project = ProjectWorkspace.Open(path);
            new EditorApplication(project, args.Contains("--game")).Run();
            return 0;
        }
        catch (Exception error)
        {
            Console.Error.WriteLine(error);
            return 1;
        }
    }
}
