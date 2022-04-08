using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Utility;
using WebAPIPractise.Common;
using WebAPIPractise.Service.User;
using WebAPIPractise.Service.User.Dto;

namespace WebAPI.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;
        private ICustomJWTService _iJWTService;
        public LoginController(IUserService userService,ICustomJWTService iJWTService)
        {
            _userService = userService;
            _iJWTService = iJWTService;
        }


        //驗證碼
        [HttpGet]
        public IActionResult GetValidateCodeImages(string t)
        {
            System.Console.WriteLine(t);
            var validateCodeString = Tools.CreateValidateString();
            //將驗證碼記入緩存中
            MemoryHelper.SetMemory(t, validateCodeString, 1);

            //接收圖片返回的二進制流
            byte[] buffer = Tools.CreateValidateCodeBuffer(validateCodeString);
            return File(buffer, @"image/jpeg");
        }

        //登入
        [HttpGet("{qq}/{pwd}/{validateKey}/{validateCode}")]
        public string CheckLogin(string qq, string pwd, string validateKey, string validateCode)
        {
            var currCode = MemoryHelper.GetMemory(validateKey);
            if (currCode == null)
            {
                return "";
            }
            if (currCode.ToString() == validateCode)
            {
                LoginDto loginDto = new LoginDto();
                loginDto.QQ = qq;
                loginDto.PassWord = pwd;
                var user = _userService.CheckLogin(loginDto).Result;
                if (user != null)
                {
                    return _iJWTService.GetToken(user);
                }
                else
                {
                    return "";
                }

            }
            else return "";
        }
    }

    
}
