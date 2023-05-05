using Project3.Entity.Response;
using System.Text.Json;

namespace Project3.Utils
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandler(RequestDelegate next, ILogger<ErrorHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var baseResponse = new BaseResponse();

                switch (error)
                {
                    case ValidateException e:
                        // custom application error
                        baseResponse.code = (int)MESSAGE.STATUS_RESPONSE.INVALID_REQUEST;
                        baseResponse.message = e.Message;
                        break;

                    case AuthenException e:
                        // custom application error
                        baseResponse.code = (int)MESSAGE.STATUS_RESPONSE.FORBIDDEN;
                        baseResponse.message = e.Message;
                        break;

                    case DataNotFoundException e:
                        baseResponse.code = (int)MESSAGE.STATUS_RESPONSE.RESOURCE_NOT_FOUND;
                        baseResponse.message = e.Message;
                        break;
                    default:
                        // system error
                        _logger.LogError(error, error.Message);
                        baseResponse.code = (int)MESSAGE.STATUS_RESPONSE.INTERNAL_SERVER;
                        baseResponse.message = error.Message;
                        break;
                }

                var result = JsonSerializer.Serialize(baseResponse);
                await response.WriteAsync(result); ;
            }
        }
    }
}
