namespace yourscope_api.entities
{
    public class ApiResponse
    {
        public int StatusCode;
        public object? Data;
        public object[] Errors = Array.Empty<object>();
    }
}
