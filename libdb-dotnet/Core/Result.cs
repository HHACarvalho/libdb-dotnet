namespace libdb_dotnet.Core
{
    public readonly struct Result<T> where T : class
    {
        public bool IsSuccess { get; }
        public string? Error { get; }
        public T? Value { get; }

        private Result(bool isSuccess, string? error, T? value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, null, value);
        }

        public static Result<T> Fail(string error)
        {
            return new Result<T>(false, error, null);
        }
    }
}