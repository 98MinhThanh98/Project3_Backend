using Project3.Entity.Dto;
using Project3.Entity.Response;
using Project3.Models;
using Project3.Repositories;
using Project3.Utils;

namespace Project3.Services
{
    public interface IUserService
    {
        BaseResponse register(RegisterReq registerUser);
        BaseResponse login(LoginUser loginUser);
    }
    public class UserService : IUserService
    {
        User user;
        Role role;
        IRoleRepo roleRepo;
        IUserRepo userRepo;
        ISecurityService _securityService;
        InformationStudent student;
        public UserService(IRoleRepo _roleRepo, IUserRepo _userRepo, ISecurityService securityService)
        {
            roleRepo = _roleRepo;
            userRepo = _userRepo;
            _securityService = securityService;
        }

        public BaseResponse login(LoginUser loginUser)
        {
            throw new NotImplementedException();
        }

        public BaseResponse register(RegisterReq registerUser)
        {
            if (userRepo.UserExistsByUsername(registerUser.Username))
            {
                throw new ValidateException(MESSAGE.VALIDATE.REGISTER_USERNAME);
            }
            this.user = new User();
            var pass = _securityService.CreatePasswordHash(registerUser.Password);
            this.user.UserName = registerUser.Username;
            this.user.PasswordHash = pass.PasswordHash;
            this.user.PasswordSalt = pass.PasswordSalt;
            this.user.CreatedAt = DateTime.Now;
            this.user.IsDelete = Constants.IsDelete.False;
            if (!string.IsNullOrEmpty(registerUser.role))
            {
                this.role = roleRepo.FindByName(registerUser.role);
                if (this.role == null)
                {
                    throw new ValidateException(MESSAGE.VALIDATE.ROLE_NOT_FOUND);
                }
            }
            else
            {
                this.role = roleRepo.FindByName(MESSAGE.VALIDATE.ROLE_USER);
                if (this.role == null)
                {
                    throw new ValidateException(MESSAGE.VALIDATE.ROLE_NOT_FOUND);
                }
                this.user.UserRoles = new List<UserRole>(){
                new UserRole()
                {
                    Role = this.role
                }};
                this.student = new InformationStudent();
            }

            userRepo.AddUser(this.user);
            return new BaseResponse(MESSAGE.STATUS_RESPONSE.SUCCESS, MESSAGE.VALIDATE.REGISTER_SUCCESS);
        }
    }
}
