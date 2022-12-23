using Newtonsoft.Json;
using RawsonbpoTestProject.Repository.Context;
using RawsonbpoTestProject.Repository.DataModel;
using RawsonbpoTestProject.Repository.Repositories.Interfaces;
using RawsonbpoTestProject.Shared.UserModel;
using System.Reflection;

namespace RawsonbpoTestProject.Repository.Repositories.Classes
{
    public class RegisterUserInfoRepository : IRegisterUserInfoRepository
    {

        public MyDBContext Context { get; set; }

        public RegisterUserInfoRepository(MyDBContext context) =>   Context = context;
        
        public async Task<bool> SaveUserInfoDataAsync(UserInfoModel userInfoModel)
        {
            try
            {              
                await Task.Run(() => {
                    Context.Add<UserInfo>(new UserInfo
                    {
                        Identification = userInfoModel?.Identification ?? 0,
                        Name = userInfoModel?.Name ?? "",
                        LastName = userInfoModel.LastName ?? "",
                        BirthDate = userInfoModel?.BirthDate ?? DateTime.Parse("1000-1-1"),
                        AddressOne = userInfoModel?.AddressOne ?? "",                       
                        AddressTwo = userInfoModel?.AddressTwo ?? "",
                        PhoneNumberOne = userInfoModel?.PhoneNumberOne ?? "0",
                        PhoneNumberTwo = userInfoModel?.PhoneNumberTwo ?? "0",
                        EmailOne = userInfoModel?.EmailOne ?? "0",
                        EmailTwo = userInfoModel?.EmailTwo ?? "0"
                    }) ;
                    Context.SaveChanges();
                });               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return false;
            }
            
            return true;
        }

        public async Task<bool> UpdateUserInfoData(UserInfoModel userInfoModel)
        {
            try
            {
                UserInfo? userInfo = await GetUserInfoByIdAsync(userInfoModel.Identification.Value);
                CheckChangesInUserInfo(userInfo, userInfoModel);                
                await Task.Run(() => {
                    Context.Entry<UserInfo>(userInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    Context.SaveChanges();
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.InnerException + "\n" + ex.StackTrace);
                return false;
            }
            return true;
        }

        public async Task<bool> UserExist(int userId)
        {
            UserInfo? userInfo = await GetUserInfoByIdAsync(userId);
            if (userInfo == null)
            {
                return false;
            }
            return true;
        }

        public async Task<UserInfo?> GetUserInfoByIdAsync(int userId)
        {
            UserInfo? userInfo = await Task.Run(() => Context.UserInfo.Find(userId));
            return userInfo;
        }

        private void CheckChangesInUserInfo(UserInfo? userInfo, UserInfoModel? userInfoModel)
        {            
            userInfo.Name = userInfoModel.Name != userInfo.Name ? userInfoModel?.Name ?? userInfo.Name : userInfo.Name;
            userInfo.LastName = userInfoModel.LastName != userInfo.LastName ? userInfoModel?.LastName ?? userInfo.LastName : userInfo.LastName;
            userInfo.BirthDate = userInfoModel.BirthDate != userInfo.BirthDate ? userInfoModel?.BirthDate ?? userInfo.BirthDate : userInfo.BirthDate;
            userInfo.PhoneNumberOne = userInfoModel.PhoneNumberOne != userInfo.PhoneNumberOne ? userInfoModel?.PhoneNumberOne ?? userInfo.PhoneNumberOne : userInfo.PhoneNumberOne;
            userInfo.PhoneNumberTwo = userInfoModel.PhoneNumberTwo != userInfo.PhoneNumberTwo ? userInfoModel?.PhoneNumberTwo ?? userInfo.PhoneNumberTwo : userInfo.PhoneNumberTwo;
            userInfo.AddressOne = userInfoModel.AddressOne != userInfo.AddressOne ? userInfoModel?.AddressOne ?? userInfo.AddressOne : userInfo.AddressOne;
            userInfo.AddressTwo = userInfoModel.AddressTwo != userInfo.AddressTwo ? userInfoModel?.AddressTwo ?? userInfo.AddressTwo : userInfo.AddressTwo;
            userInfo.EmailOne = userInfoModel.EmailOne != userInfo.EmailOne ? userInfoModel?.EmailOne ?? userInfo.EmailOne : userInfo.EmailOne;
            userInfo.EmailTwo = userInfoModel.EmailTwo != userInfo.EmailTwo ? userInfoModel?.EmailTwo ?? userInfo.EmailTwo : userInfo.EmailTwo;

        }
        
    }
}