using Practice.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Helpers;

namespace Practice.Web.CookieOps
{
    public class CookieValidator : ICookieValidator
    {
        public void Validate(HttpRequestMessage request, string formToken)
        {
            string getCookie = request.Headers.GetCookies("apiCookie")[0].ToString();
            AntiForgery.Validate(getCookie.Replace("apiCookie=", ""), formToken);

        }

        public void GetTokens(string oldCookieToken, out string newCookieToken, out string formToken)
        {
            AntiForgery.GetTokens(oldCookieToken, out newCookieToken, out formToken);
        }

        public List<CookieHeaderValue> CreateCookie(string cookieToken)
        {
            Cookie cookie = new Cookie
            {
                Name = "apiCookie",
                Value = cookieToken,
                Expires = DateTime.Now.AddHours(6)
            };

            List<CookieHeaderValue> chv = new List<CookieHeaderValue>();
            CookieHeaderValue chv2 = new CookieHeaderValue("apiCookie", cookie.Value);
            chv.Add(chv2);

            return chv;
        }
    }
}