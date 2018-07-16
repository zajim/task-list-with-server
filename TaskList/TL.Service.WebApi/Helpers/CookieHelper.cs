using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using TL.Abstraction.Common;

namespace TL.Service.WebApi.Helpers
{
    public class CookieHelper : ICookieHelperAdapter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Get(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="days">expiration time</param>  
        public void Set(string key, string value, DateTime expireTime)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = expireTime;

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
    }
}
