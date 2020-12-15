using System.Collections.Generic;

namespace CleanCSS.NET
{
    public class Arguments
    {
        public string? Options { get; protected set; }
    }

    public class FilesArguments : Arguments
    {
        public IList<string> Files { get; }
        public List<string> Results { get; }

        public FilesArguments(IList<string> files, OptimizationLevel options)
        {
            Files = files;
            Options = options.ToString()!;
            Results = new List<string>();
        }

        public FilesArguments(IList<string> files, string options)
        {
            Files = files;
            Options = options;
            Results = new List<string>();
        }
    }

    public class StringArguments : Arguments
    {
        public string Css { get; }

        public StringArguments(string css, OptimizationLevel options)
        {
            Css = css;
            Options = options.ToString()!;
        }

        public StringArguments(string css, string options)
        {
            Css = css;
            Options = options;
        }
    }
}
