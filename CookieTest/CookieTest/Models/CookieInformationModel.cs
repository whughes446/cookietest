using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieTest.Models
{
    public class CookieInformationModel
    {
        public bool CookieSet { get; set; }
        public SameSiteMode SameSite { get; set; }
        public string Name { get; set; }
        public bool isSecureSet { get; set; }
        public bool isHttpSet { get; set; }
    }
}