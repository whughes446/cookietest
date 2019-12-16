using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieTest.Models
{
    public static class CookieInformationExtensionMethods
    {
        public static CookieInformationModel ToCookieInformationModel(this HttpCookie httpcookie)
            => new CookieInformationModel() { CookieSet = true, Name = httpcookie.Name, SameSite = httpcookie.SameSite, isSecureSet = httpcookie.Secure, isHttpSet = httpcookie.HttpOnly };
    }
}