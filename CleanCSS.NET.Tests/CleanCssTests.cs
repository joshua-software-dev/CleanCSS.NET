using System.Collections.Generic;
using System.IO;
using Xunit;


namespace CleanCSS.NET.Tests
{
    public static class CleanCssTests
    {
        [Theory]
        [InlineData(" div \n{\n    height: 0em\n}\n ")]
        private static void FileTestListOptimizationLevelClass0(string cssTextForFile)
        {
            using var stream1 = new FileStream(
                Path.GetTempFileName(),
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                4096,
                FileOptions.DeleteOnClose | FileOptions.WriteThrough
            );
            
            using var stream2 = new FileStream(
                Path.GetTempFileName(),
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                4096,
                FileOptions.DeleteOnClose | FileOptions.WriteThrough
            );

            using var writer1 = new StreamWriter(stream1) {AutoFlush = true};
            using var writer2 = new StreamWriter(stream2) {AutoFlush = true};
            writer1.Write(cssTextForFile);
            writer2.Write(cssTextForFile);

            var results = CleanCss.MinifyCss(
                new List<string> { stream1.Name, stream2.Name },
                OptimizationLevel.Level0
            );
            
            foreach (var r in results)
                Assert.True(r == "div{height:0em}");
        }
        
        [Theory]
        [InlineData(" div \n{\n    height: 0em\n}\n ")]
        private static void FileTestArrayOptimizationLevelClass2(string cssTextForFile)
        {
            using var stream1 = new FileStream(
                Path.GetTempFileName(),
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                4096,
                FileOptions.DeleteOnClose | FileOptions.WriteThrough
            );
            
            using var stream2 = new FileStream(
                Path.GetTempFileName(),
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                4096,
                FileOptions.DeleteOnClose | FileOptions.WriteThrough
            );

            using var writer1 = new StreamWriter(stream1) {AutoFlush = true};
            using var writer2 = new StreamWriter(stream2) {AutoFlush = true};
            writer1.Write(cssTextForFile);
            writer2.Write(cssTextForFile);

            var results = CleanCss.MinifyCss(
                new [] { stream1.Name, stream2.Name },
                OptimizationLevel.Level2
            );
            
            foreach(var r in results)
                Assert.True(r == "div{height:0}");
        }
        
        [Theory]
        [InlineData(" div \n{\n    height: 0em\n}\n ")]
        private static void FileTestListOptionStringLevel0(string cssTextForFile)
        {
            using var stream1 = new FileStream(
                Path.GetTempFileName(),
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                4096,
                FileOptions.DeleteOnClose | FileOptions.WriteThrough
            );
            
            using var stream2 = new FileStream(
                Path.GetTempFileName(),
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                4096,
                FileOptions.DeleteOnClose | FileOptions.WriteThrough
            );

            using var writer1 = new StreamWriter(stream1) {AutoFlush = true};
            using var writer2 = new StreamWriter(stream2) {AutoFlush = true};
            writer1.Write(cssTextForFile);
            writer2.Write(cssTextForFile);

            var results = CleanCss.MinifyCss(
                new List<string> { stream1.Name, stream2.Name },
                "{\"level\":{\"0\":{\"all\":true}}}"
            );
            
            foreach(var r in results)
                Assert.True(r == "div{height:0em}");
        }
        
        [Theory]
        [InlineData(" div \n{\n    height: 0em\n}\n ")]
        private static void FileTestArrayOptionStringLevel2(string cssTextForFile)
        {
            using var stream1 = new FileStream(
                Path.GetTempFileName(),
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                4096,
                FileOptions.DeleteOnClose | FileOptions.WriteThrough
            );
            
            using var stream2 = new FileStream(
                Path.GetTempFileName(),
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                4096,
                FileOptions.DeleteOnClose | FileOptions.WriteThrough
            );

            using var writer1 = new StreamWriter(stream1) {AutoFlush = true};
            using var writer2 = new StreamWriter(stream2) {AutoFlush = true};
            writer1.Write(cssTextForFile);
            writer2.Write(cssTextForFile);

            var results = CleanCss.MinifyCss(
                new [] { stream1.Name, stream2.Name },
                "{\"level\":{\"0\":{\"all\":true},\"1\":{\"all\":true},\"2\":{\"all\":true}}}"
            );
            
            foreach(var r in results)
                Assert.True(r == "div{height:0}");
        }
        
        [Theory]
        [InlineData(" div \n{\n    height: 0em\n}\n ")]
        private static void StringTestOptimizationLevelClass0(string cssText)
        {
            var value = CleanCss.MinifyCss(cssText, OptimizationLevel.Level0);
            Assert.True(value == "div{height:0em}");
        }
        
        [Theory]
        [InlineData(" div \n{\n    height: 0em\n}\n ")]
        private static void StringTestOptionStringLevel2(string cssText)
        {
            var value = CleanCss.MinifyCss(
                cssText, 
                "{\"level\":{\"0\":{\"all\":true},\"1\":{\"all\":true},\"2\":{\"all\":true}}}"
            );
            Assert.True(value == "div{height:0}");
        }
    }
}