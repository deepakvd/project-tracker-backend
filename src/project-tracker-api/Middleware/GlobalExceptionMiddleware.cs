using project_tracker_api.ResponseModels;
using project_tracker_application.Common.Exceptions;
using System.Text.Json;


namespace project_tracker_api.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private const int UnauthorizedStatusCode = 401;
        private const int ValidationErrorStatusCode = 400;
        private const int InternalServerErrorStatusCode = 500;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // call the next middleware
            }
            catch (Exception ex)
            {
                var (statusCode, message, errors) = ex switch
                {
                    NotFoundException e => (StatusCodes.Status404NotFound, e.Message, null),
                    UnauthorizedException e => (StatusCodes.Status401Unauthorized, e.Message, null),
                    ForbiddenException e => (StatusCodes.Status403Forbidden, e.Message, null),
                    ConflictException e => (StatusCodes.Status409Conflict, e.Message, null),
                    ValidationException e => (StatusCodes.Status400BadRequest, e.Message, e.Errors),
                    _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred", null)
                };

                ApiResponse<object> response = new ApiResponse<object>(null,false,message,errors);

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);

            }

        }
    }
}
