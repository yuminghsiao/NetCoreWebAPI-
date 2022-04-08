using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIPractise.Model.Enum;
using WebAPIPractise.Service;
using WebAPIPractise.Service.User;
using WebAPIPractise.Service.User.Dto;

namespace WebAPI.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        { 
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("這是一個get請求!");
            return "這是get請求"; 
        }

        //用戶註冊
        [HttpPost]
        public ActionResult<UserDto> RegistUser([FromBody] InputUserDto input)
        {
            try
            {
                var res = _userService.AddUser(input);
                return res;
            }
            catch (Exception ex)
            {
                JsonResult result = new JsonResult(ex)
                {
                    StatusCode = 201,
                };
                return result;
            }
        }

        //權限判斷練習
        [HttpGet]
        [Authorize]//JWT驗證 program.cs可以看到jwt校驗
        public List<Courses> GetCoureses()
        {
            _logger.LogInformation("進入getcoureses");
            int userType = Convert.ToInt32(HttpContext.User.Claims.ToList()[3].Value);
            if (userType == (int)EnumUserType.VIP用戶)
            {
                return _userService.GetCourses();
            }
            return new List<Courses>();
        }
    }
}
