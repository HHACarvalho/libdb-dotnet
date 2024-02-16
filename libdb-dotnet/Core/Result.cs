namespace libdb_dotnet.Core
{
    public readonly struct Result
    {
        public bool IsSuccess { get; }
        public string? Error { get; }
        public object? Value { get; }

        private Result(bool isSuccess, string? error, object? value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result Success(object value)
        {
            return new Result(true, null, value);
        }

        public static Result Fail(string error)
        {
            return new Result(false, error, null);
        }
    }
}