namespace FirstApp1.Model
{
    public class ApiResponse
    {
        public string Message { get; set; } 
        public string Code { get; set; } 
        public object? ResponseData { get; set; }
    }
    public enum ResponseType
    {
        Success,
        NotFound,
        Failure,
        Error
    }
}
