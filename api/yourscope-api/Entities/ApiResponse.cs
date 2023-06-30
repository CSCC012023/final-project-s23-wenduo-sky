namespace yourscope_api.entities
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public object? Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public string? Message { get; set; }
        public bool? Successful { get; set; }

        #region constructors
        public ApiResponse(int statusCode, string? message = null, object ? data = null, bool? success = null, IEnumerable<object>? errors = null)
        {
            this.StatusCode = statusCode;
            this.Data = data;  
            this.Message = message;
            this.Errors = errors;
            this.Successful = success;
        }
        #endregion
    }
}
