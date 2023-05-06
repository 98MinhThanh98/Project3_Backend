namespace Project3.Utils
{
    public static class MESSAGE
    {
        public class VALIDATE
        {
            public const string INPUT_INVALID = "Invalid input";

            public const string OBJECT_NOT_FOUND = "không tìm thấy dữ liệu object này";

            public const string OBJECT_NULL = "Object này không có data";

            public const string REGISTER_USERNAME = "Tên Đăng nhập bị trùng";

            public const string ROLE_ADMIN = "ROLE_ADMIN";

            public const string ROLE_USER = "ROLE_USER";

            public const string REGISTER_SUCCESS = "Đăng kí thành công";

            public const string REGISTER_FAIL = "Đăng kí thất bại! Vui lòng thử lại";

            public const string ROLE_NOT_FOUND = "không tìm thấy role này";
        }

        public class STATUS_RESPONSE
        {
            public const int SUCCESS = 200;
            public const string SUCCESS_NAME = "Success";

            public const int INVALID_REQUEST = 400;
            public const string INVALID_REQUEST_NAME = "Invalid request";

            public const int INVALID_PARAM = 400;
            public const string INVALID_PARAMT_NAME = "Invalid param";

            public const int UNAUTHORIZED = 401;
            public const string UNAUTHORIZED_NAME = "Unauthorized";

            public const int FORBIDDEN = 403;
            public const string FORBIDDEN_NAME = "Forbidden";

            public const int UNAVAILABLE = 503;
            public const string UNAVAILABLE_NAME = "Service unavailable";

            public const int INTERNAL_SERVER = 500;
            public const string INTERNAL_SERVER_NAME = "Internal Server Error";

            public const int UNKNOWN = 69;
            public const string UNKNOWN_NAME = "Error Unknown";

            public const int RESOURCE_NOT_FOUND = 404;
            public const string RESOURCE_NOT_FOUND_NAME = "Resource not found";
        }

        public class TOKEN_VALIDATE
        {
            public const string TOKEN_INVALID = "Thông tin Token không hợp lệ";
            public const string TOKEN_EXPIRE = "Token đã hết hạn";
        }

        public class TOKEN_INFO
        {
            public const string USER_ID = "UserId";
            public const string FULL_NAME = "UserName";
            public const string EMAIL = "Email";
            public const string ROLE = "RoleUserDeptId";
            public const string EXP = "exp";
        }

    }
}
