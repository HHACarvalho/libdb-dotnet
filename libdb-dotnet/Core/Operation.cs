namespace libdb_dotnet.Core
{
    public readonly struct Operation<T> where T : class
    {
        public bool IsSuccess { get; }
        public string? Error { get; }
        public T? Value { get; }

        private Operation(bool isSuccess, string? error, T? value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Operation<T> Success(T value)
        {
            return new Operation<T>(true, null, value);
        }

        public static Operation<T> Fail(string error)
        {
            return new Operation<T>(false, error, null);
        }
    }
}