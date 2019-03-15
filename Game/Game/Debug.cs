namespace Game
{
    public static class Debug
    {
        public static void Assert(bool condition) {
            if (!condition) {
                throw new System.Exception();
            }
        }
    }
}
