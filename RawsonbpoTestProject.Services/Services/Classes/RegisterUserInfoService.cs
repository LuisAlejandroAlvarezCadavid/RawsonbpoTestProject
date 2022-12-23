
using RawsonbpoTestProject.Repository.DataModel;
using RawsonbpoTestProject.Repository.Repositories.Interfaces;
using RawsonbpoTestProject.Services.Services.Interfaces;
using RawsonbpoTestProject.Shared.Constants;
using RawsonbpoTestProject.Shared.Exeptions;
using RawsonbpoTestProject.Shared.UserModel;
using System.Text.RegularExpressions;

namespace RawsonbpoTestProject.Services.Services.Classes
{
    public class RegisterUserInfoService : IRegisterUserInfoService
    {
        IRegisterUserInfoRepository _registerUserInfoRepository;
        public RegisterUserInfoService(IRegisterUserInfoRepository registerUserInfoRepository) 
        {
            this._registerUserInfoRepository = registerUserInfoRepository;
        }

        public async Task<UserStatus> ReceivedUserInfo(UserInfoModel userModel)
        {           
            if (await this._registerUserInfoRepository.UserExist( userModel?.Identification ?? 0 ))
            {
                if (await ValidateDataToUpdate(userModel))
                {
                    if( await _registerUserInfoRepository.UpdateUserInfoData(userModel))
                        return new UserStatus { UserStatausMessage = Messages.UserStatusMessageUpdateData, _UserStatus = UserStatusConstants.USER_EXIST };
                    else
                        return new UserStatus { UserStatausMessage = Messages.UserSaveInfoHaveAThroble, _UserStatus = UserStatusConstants.USER_HAS_THROBLE };
                }
                    
                else
                    return new UserStatus { UserStatausMessage = Messages.UserSaveInfoHaveAThroble, _UserStatus = UserStatusConstants.USER_HAS_THROBLE};
            }
                
            if (ValidateUserInfoData(userModel))
            {
                if( await this._registerUserInfoRepository.SaveUserInfoDataAsync(userModel))
                {
                    return new UserStatus { UserStatausMessage = Messages.UserStatusMessageSaveData, _UserStatus = UserStatusConstants.USER_NOT_EXIST };
                }
                else
                    return new UserStatus { UserStatausMessage = Messages.UserSaveInfoHaveAThroble, _UserStatus = UserStatusConstants.USER_HAS_THROBLE };
            }
            return null;
        }

        private bool ValidateUserInfoData(UserInfoModel userModel)
        {
            bool? validation = null;
            DateTime birthDate = DateTime.MinValue;
            if(userModel == null || userModel?.Identification == null || userModel?.Name == null || userModel?.LastName == null || userModel?.BirthDate == null )
            {
                if(userModel == null) throw new UserInfoDataExeption(Messages.ClassNull, this.GetType());
                if (userModel?.Identification == null) throw new UserInfoDataExeption(Messages.Identification, this.GetType());
                if (userModel?.Name == null) throw new UserInfoDataExeption(Messages.Name, this.GetType());
                if (userModel?.LastName == null) throw new UserInfoDataExeption(Messages.Name, this.GetType());
                if (userModel?.BirthDate == null) throw new UserInfoDataExeption(Messages.BirthDate, this.GetType());                
            }            
            if (!Regex.IsMatch(userModel.Name, @"^(([a-zA-Z]+\s*[a-zA-Z]+)|([a-zA-Z]+\s*))$"))
            {
                throw new UserInfoDataExeption(Messages.NameError, this.GetType());                
            }
            if (!Regex.IsMatch(userModel.LastName, @"^(([a-zA-Z]+\s*[a-zA-Z]+)|([a-zA-Z]+\s*))$"))
            {
                throw new UserInfoDataExeption(Messages.LastNameError, this.GetType());                
            }            
            if (userModel.BirthDate == null)
            {
                throw new UserInfoDataExeption(Messages.BirthDateError, this.GetType());                
            }
            
            if(string.IsNullOrEmpty(userModel.AddressOne) && string.IsNullOrEmpty(userModel.AddressTwo) && string.IsNullOrEmpty(userModel.EmailOne) && string.IsNullOrEmpty(userModel.EmailTwo))
                throw new UserInfoDataExeption(Messages.ContactInformationError, this.GetType());

            return validation ??= true;
        }

        private async Task<bool> ValidateDataToUpdate(UserInfoModel userModel)
        {
            
            if (!string.IsNullOrEmpty(userModel?.Name))
            {
                if(!Regex.IsMatch(@"'[(\b[a-zA-Z]+)\s+]|(\b[a-zA-Z]+)\s*", userModel.Name))
                        throw new UserInfoDataExeption(Messages.NameError, this.GetType());
            }

            if (!string.IsNullOrEmpty(userModel?.LastName))
            {
                if (!Regex.IsMatch(@"'[(\b[a-zA-Z]+)\s+]|(\b[a-zA-Z]+)\s*", userModel.LastName))
                {
                    throw new UserInfoDataExeption(Messages.LastNameError, this.GetType());
                }
            }            
            return true;
        }       
    }
}
