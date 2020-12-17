using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript;
using System.Collections.Generic;


namespace CleanCSS.NET
{
    public static class CleanCss
    {
        public static List<string> MinifyCss(FilesArguments args)
        {
            using var wrapper = new CleanCssWrapper();
            wrapper.Engine.AddHostObject("FilesArguments", args);
            wrapper.Engine.Evaluate(
                new DocumentInfo { Category = ModuleCategory.CommonJS },
                @"
                var CleanCSS = require('clean-css');
                const minifier = new CleanCSS(JSON.parse(FilesArguments.Options));
                for (const f of FilesArguments.Files)
                {
                    const fileText = File.ReadAllText(f);
                    FilesArguments.Results.Add(minifier.minify(fileText).styles);
                }
                "
            );
    
            return args.Results;
        }

        public static string MinifyCss(StringArguments args)
        {
            using var wrapper = new CleanCssWrapper();
            wrapper.Engine.AddHostObject("StringArguments", args);

            return (string) wrapper.Engine.Evaluate(
                new DocumentInfo { Category = ModuleCategory.CommonJS },
                @"
                var CleanCSS = require('clean-css');
                return new CleanCSS(JSON.parse(StringArguments.Options)).minify(StringArguments.Css).styles;
                "
            );
        }

        public static List<string> MinifyCss(IList<string> files, OptimizationLevel? level = null)
        {
            return MinifyCss(new FilesArguments(files, level ?? OptimizationLevel.Level2));
        }

        public static List<string> MinifyCss(IList<string> files, string optimizationOptionsJson)
        {
            return MinifyCss(new FilesArguments(files, optimizationOptionsJson));
        }

        public static string MinifyCss(string css, OptimizationLevel? level = null)
        {
            return MinifyCss(new StringArguments(css, level ?? OptimizationLevel.Level2));
        }

        public static string MinifyCss(string css, string optimizationOptionsJson)
        {
            return MinifyCss(new StringArguments(css, optimizationOptionsJson));
        }
    }
}
