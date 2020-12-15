using System.IO;
using System.Reflection;
using System;


namespace CleanCSS.NET
{
    public static class ModuleResource
    {
        public static string GetCleanCssScript()
        {
            var stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream(typeof(ModuleResource).Namespace + ".Resources.cleancss-browser.js") 
                    ?? throw new NullReferenceException();

            return new StreamReader(stream).ReadToEnd().Trim();
        }
    }
}
