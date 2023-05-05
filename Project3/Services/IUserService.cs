using Project3.Entity.Dto;
using Project3.Entity.Response;

namespace Project3.Services
{
    public interface IUserService
    {
        BaseResponse RegisterUser(RegisterUser registerUser);
        BaseResponse RegisterAdmin(RegisterUser registerUser);
        BaseResponse LoginUser(LoginUser loginUser);
        BaseResponse LoginUAdmin(LoginUser loginUser);

    }

    public class UserService : IUserService
    {
        public BaseResponse LoginUAdmin(LoginUser loginUser)
        {
            throw new NotImplementedException();
        }

        public BaseResponse LoginUser(LoginUser loginUser)
        {
            throw new NotImplementedException();
        }

        public BaseResponse RegisterAdmin(RegisterUser registerUser)
        {
            throw new NotImplementedException();
        }

        public BaseResponse RegisterUser(RegisterUser registerUser)
        {
            throw new NotImplementedException();
        }
    }
}
