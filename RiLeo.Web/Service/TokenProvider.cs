using Newtonsoft.Json.Linq;
using RiLeo.Web.Service.IService;
using RiLeo.Web.Utility;
using static System.Formats.Asn1.AsnWriter;
using System.Net;
using static System.Net.WebRequestMethods;

namespace RiLeo.Web.Service
{
    public class TokenProvider : ITokenProvider
    { 
        private readonly IHttpContextAccessor _contextAccessor;
        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public void ClearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public string? GetToken()
        {
           string? token = null;

            //This line tries to read a cookie from the incoming HTTP request and checks if it exists. Request.Cookies is a dictionary-like collection of all cookies sent by the client.
            //TryGetValue attempts to get the cookie value by name. true → cookie exists, and its value is saved in token || false → cookie does NOT exist, and token = null/default
            //If HttpContext exists and cookie exists → store its value in token and set hasToken = true
            bool? hasToken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookie, out token);


            // hasToken is a nullable bool (bool?) So it can have 3 possible values:
            // true	Cookie exists
            // false   Cookie does NOT exist
            // null    HttpContext was null(not in real HTTP request)
            return hasToken is true ? token : null;  
        }

        public void SetToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }
    }
}
