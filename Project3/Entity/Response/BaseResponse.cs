using Project3.Utils;

namespace Project3.Entity.Response
{
    public class BaseResponse
    {
        public int code { get; set; }
        public string? message { get; set; }
        public object? data { get; set; }

        public BaseResponse()
        {
            code = MESSAGE.STATUS_RESPONSE.SUCCESS;
            message = MESSAGE.STATUS_RESPONSE.SUCCESS_NAME;
            data = null;
        }

        public BaseResponse(object obj)
        {
            code = MESSAGE.STATUS_RESPONSE.SUCCESS;
            message = MESSAGE.STATUS_RESPONSE.SUCCESS_NAME;
            data = obj;
        }

        public BaseResponse(int code, string? message)
        {
            this.code = code;
            this.message = message;
            this.data = null;
        }

        public BaseResponse(int code, string? message, object? obj)
        {
            this.code = code;
            this.message = message;
            this.data = obj;
        }
    }
}
