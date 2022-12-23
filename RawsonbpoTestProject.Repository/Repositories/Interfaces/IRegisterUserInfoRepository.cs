using RawsonbpoTestProject.Repository.DataModel;
using RawsonbpoTestProject.Shared.UserModel;

namespace RawsonbpoTestProject.Repository.Repositories.Interfaces
{
    public interface IRegisterUserInfoRepository
    {
        Task<bool> SaveUserInfoDataAsync(UserInfoModel userInfoModel);
        Task<bool> UpdateUserInfoData(UserInfoModel userInfoModel);
        Task<bool> UserExist(int userId);
        Task<UserInfo?> GetUserInfoByIdAsync(int userId);
    }
}
