namespace libdb_dotnet.Core
{
    public readonly struct QueryOutput<T>
    {
        public readonly int TotalCount;
        public readonly T[] Array;

        public QueryOutput(int TotalCount, T[] Array)
        {
            this.TotalCount = TotalCount;
            this.Array = Array;
        }
    }
}