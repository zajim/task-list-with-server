using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TL.Abstraction.Business;
using TL.Abstraction.Common;
using TL.Model.Web;

namespace TL.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly ICookieHelperAdapter _cookieHelperAdapter;

        public AuthController(IUserBusiness userBusiness, ICookieHelperAdapter cookieHelperAdapter)
        {
            _userBusiness = userBusiness;
            _cookieHelperAdapter = cookieHelperAdapter;
        }

        [HttpPost]
        public async Task<JsonResult> Login(LoginViewModel loginData)
        {
            UserLoginViewModel userLoginData = await _userBusiness.Login(loginData).ConfigureAwait(false);
            if (userLoginData != null && !string.IsNullOrEmpty(userLoginData.Token))
            {
                JsonResult jsonResult = new JsonResult(userLoginData);
                _cookieHelperAdapter.Set("userLoginData", JsonConvert.SerializeObject(userLoginData), userLoginData.TokenExpire);
                return jsonResult;
            }

            return null;
        }
    }
}