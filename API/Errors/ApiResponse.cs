namespace API.Errors;

public class ApiResponse
{
    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }
    
    public int StatusCode { get; set; }
    public string Message { get; set; }
    
    private string? GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad request, check request parameters",
            401 => "Unauthorized access, authentication required",
            403 => "Forbidden, you do not have permission to perform this action",
            404 => "Resource not found",
            405 => "Method not allowed",
            500 => "Internal server error, contact administrator",
            503 => "Service unavailable, contact administrator",
            _ => null
        };
    }
}