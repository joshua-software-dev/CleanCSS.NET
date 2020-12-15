using System;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;
using System.IO;


namespace CleanCSS.NET
{
    public class CleanCssWrapper : IDisposable
    {
        private static V8ScriptEngine? _engine;
        public V8ScriptEngine Engine
        {
            get => _engine!; 
            set => _engine = value;
        }
        
        public CleanCssWrapper()
        {
            if (_engine != null) 
                return;

            _engine = new V8ScriptEngine();
            _engine.DocumentSettings.AddSystemDocument(
                "clean-css",
                ModuleCategory.CommonJS,
                ModuleResource.GetCleanCssScript()
            );
            _engine.AddHostType("File", typeof(File));
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                (_engine ?? throw new NullReferenceException()).Dispose();
                _engine = null;
            }
        }
    }
}
