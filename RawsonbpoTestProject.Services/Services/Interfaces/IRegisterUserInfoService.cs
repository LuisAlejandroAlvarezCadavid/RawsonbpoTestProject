using RawsonbpoTestProject.Shared.UserModel;

namespace RawsonbpoTestProject.Services.Services.Interfaces
{
    public interface IRegisterUserInfoService
    {
        Task<UserStatus> ReceivedUserInfo(UserInfoModel userModel);
        
    }
}
