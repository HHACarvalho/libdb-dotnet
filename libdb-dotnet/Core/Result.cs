namespace libdb_dotnet.Core
{
    public readonly struct Result
    {
        public bool IsSuccess { get; }
        public string? Error { get; }
        public object? Value { get; }
        public int StatusCode { get; }

        private Result(bool isSuccess, string? error, object? value, int statusCode)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
            StatusCode = statusCode;
        }

        public static Result Success(object value, int statusCode = 200)
        {
            return new Result(true, null, value, statusCode);
        }

        public static Result Fail(string error, int statusCode = 404)
        {
            return new Result(false, error, null, statusCode);
        }
    }
}