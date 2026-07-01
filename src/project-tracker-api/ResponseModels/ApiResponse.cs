namespace project_tracker_api.ResponseModels
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        
        public string? Message { get; set; }

        public T? Data { get; set; }

        public Dictionary<string, string> errors { get; set; }

        public ApiResponse() { }

        public ApiResponse(T? data = default, bool success = true, 
                            string? message = null, Dictionary<string, string>? errors = null)
        {
            Success = success;
            Message = message;
            Data = data;
            this.errors = errors ?? new Dictionary<string, string>();
        }
    }
}
