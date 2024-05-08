namespace libdb_dotnet.Core
{
    public readonly struct Result
    {
        public bool IsSuccess { get; }
        public int StatusCode { get; }
        public object? Value { get; }
        public string? Error { get; }

        private Result(bool isSuccess, int statusCode, object? value, string? error)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Value = value;
            Error = error;
        }

        public static Result Success(object? value, int statusCode = 200)
        {
            return new Result(true, statusCode, value, null);
        }

        public static Result Fail(string error, int statusCode = 404)
        {
            return new Result(false, statusCode, null, error);
        }
    }
}