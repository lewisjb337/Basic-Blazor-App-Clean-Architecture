namespace DEMO.Domain.Shared;

public class ApiResponse
{
    public ApiResponse(string errorMessage, object payload = null)
    {
        List<string> error = new();
        if (!string.IsNullOrEmpty(errorMessage))
        {
            error.Add(errorMessage);
            errors = error.ToArray();
        }
        else
        {
            errors = new string[0];
        }

        Payload = payload;

        success = true;
    }

    public ApiResponse(string errorMessage, int errorId, object payload = null)
    {
        List<string> error = new();
        if (!string.IsNullOrEmpty(errorMessage))
        {
            error.Add(errorMessage);
            errors = error.ToArray();
        }
        else
        {
            errors = new string[0];
        }

        Payload = payload;

        if (errorId != 0)
            success = false;
        else
            success = true;

        ErrorId = errorId;
    }

    public bool success { get; set; }
    public string[] errors { get; set; }
    public object Payload { get; set; }
    public int ErrorId { get; set; }
}