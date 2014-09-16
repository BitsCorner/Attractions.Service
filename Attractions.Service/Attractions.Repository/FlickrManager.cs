using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository
{
    public class FlickrManager
    {
        public const string ApiKey = "81bc973400e23dc8453fe79eb69a6250";
        public const string SharedSecret = "06c3086edefa2cb2";

        public static Flickr GetInstance()
        {
            return new Flickr(ApiKey, SharedSecret);
        }

        public static Flickr GetAuthInstance()
        {
            var f = new Flickr(ApiKey, SharedSecret);
            if (OAuthToken != null)
            {
                f.OAuthAccessToken = OAuthToken.Token;
                f.OAuthAccessTokenSecret = OAuthToken.TokenSecret;
            }
            return f;
        }

        public static OAuthAccessToken OAuthToken
        {
            get
            {
                //if (HttpContext.Current.Request.Cookies["OAuthToken"] == null)
                //{
                    return null;
                //}
                //var values = HttpContext.Current.Request.Cookies["OAuthToken"].Values;
                //return new OAuthAccessToken
                //{
                //    FullName = values["FullName"],
                //    Token = values["Token"],
                //    TokenSecret = values["TokenSecret"],
                //    UserId = values["UserId"],
                //    Username = values["Username"]
                //};
            }
            set
            {
                //var cookie = new HttpCookie("OAuthToken")
                //{
                //    Expires = DateTime.UtcNow.AddDays(1),
                //};
                //cookie.Values["FullName"] = value.FullName;
                //cookie.Values["Token"] = value.Token;
                //cookie.Values["TokenSecret"] = value.TokenSecret;
                //cookie.Values["UserId"] = value.UserId;
                //cookie.Values["Username"] = value.Username;
                //HttpContext.Current.Response.AppendCookie(cookie);
            }
        }
    }
}
