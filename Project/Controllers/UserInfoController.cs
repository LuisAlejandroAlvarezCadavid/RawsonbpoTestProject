using Microsoft.AspNetCore.Mvc;
using RawsonbpoTestProject.Directories;
using RawsonbpoTestProject.Services.Services.Interfaces;
using RawsonbpoTestProject.Shared.Constants;
using RawsonbpoTestProject.Shared.HttpResponseModels;
using RawsonbpoTestProject.Shared.UserModel;
using System.Net;

namespace RawsonbpoTestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : Controller
    {
        IRegisterUserInfoService _registerUserInfoService;
       
        public UserInfoController(IRegisterUserInfoService registerUserInfoService)
        {
            this._registerUserInfoService = registerUserInfoService;
        }
       
        // GET: UserInfoController1cs
        public ActionResult Index()
        {
            return View();
        }

        

        
        [HttpPost]
        [Route("LoadDataUser")]
        public async Task<ActionResult> Create(UserInfoModel userInfoModel)
        {
            try
            {
                var status = await _registerUserInfoService.ReceivedUserInfo(userInfoModel);
                if(status == null) 
                {
                    return new JsonResult(new RespnoseModel { Message = status?.UserStatausMessage ?? HttpReturnMessage.HtttpReturnUnSuccess, StatusCode = HttpStatusCode.InternalServerError});
                } 
                if(status._UserStatus == UserStatusConstants.USER_HAS_THROBLE)
                {
                    return new JsonResult(new RespnoseModel { Message = status?.UserStatausMessage ?? HttpReturnMessage.HtttpReturnUnSuccess, StatusCode = HttpStatusCode.InternalServerError });
                }
                return new JsonResult(new RespnoseModel { Message = HttpReturnMessage.HttpReturnSuccess, StatusCode = HttpStatusCode.OK });
            }
            catch(Exception ex)
            {
                return new JsonResult(new RespnoseModel { Message = ex.Message, StatusCode = HttpStatusCode.BadRequest });
            }
            finally
            {
                
            }
        }
        
       
    }
}
