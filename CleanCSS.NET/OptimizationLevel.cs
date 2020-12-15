namespace CleanCSS.NET
{
    public abstract class OptimizationLevel
    {
        public static OptimizationLevel Level0 => OptimizationLevel0.Instance;
        public static OptimizationLevel Level1 => OptimizationLevel1.Instance;
        public static OptimizationLevel Level2 => OptimizationLevel2.Instance;

        private sealed class OptimizationLevel0 : OptimizationLevel
        {
            public static readonly OptimizationLevel0 Instance = new OptimizationLevel0();
            public override string ToString() => 
                "{\"level\":{\"0\":{\"all\":true}}}";
        }

        private sealed class OptimizationLevel1 : OptimizationLevel
        {
            public static readonly OptimizationLevel1 Instance = new OptimizationLevel1();
            public override string ToString() => 
                "{\"level\":{\"0\":{\"all\":true},\"1\":{\"all\":true}}";
        }

        private sealed class OptimizationLevel2 : OptimizationLevel
        {
            public static readonly OptimizationLevel2 Instance = new OptimizationLevel2();
            public override string ToString() => 
                "{\"level\":{\"0\":{\"all\":true},\"1\":{\"all\":true},\"2\":{\"all\":true}}}";
        }
    }
}
