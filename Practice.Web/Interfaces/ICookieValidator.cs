using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Practice.Web.Interfaces
{
    public interface ICookieValidator
    {
        void Validate(HttpRequestMessage request, string formToken);
        void GetTokens(string oldCookieToken, out string newCookieToken, out string formToken);
        List<CookieHeaderValue> CreateCookie(string cookieToken);
    }
}
