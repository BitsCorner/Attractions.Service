using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository
{
    public class FlickrRepository : IFlickrRepository
    {
        public string AddPicture(Stream stream, string fileName, string title, string description, string tags, bool isPublic, bool isFamily, bool isFriend)
        {
            var f = FlickrManager.GetInstance();

            //var requestToken = f.OAuthGetRequestToken("oob");

            //string url = f.OAuthCalculateAuthorizationUrl(requestToken.Token, FlickrNet.AuthLevel.Write);

            //System.Diagnostics.Process.Start(url);
            //var accessToken = f.OAuthGetAccessToken(requestToken, "353-675-162");

            //f.OAuthAccessToken = accessToken.Token;
            //f.OAuthAccessTokenSecret = accessToken.TokenSecret;

            f.OAuthAccessToken = "72157647663770865-93c55b9d31c01948";
            f.OAuthAccessTokenSecret = "3416dcf1a2760389";

            string photoId = f.UploadPicture(stream, fileName, title, description, tags, isPublic, isFamily, isFriend, FlickrNet.ContentType.Photo, FlickrNet.SafetyLevel.Safe, FlickrNet.HiddenFromSearch.Visible);
            return photoId;
        }

        public Task AddPictureSet()
        {
            throw new NotImplementedException();
        }

        public FlickrNet.PhotoInfo GetPictures()
        {
            var f = FlickrManager.GetInstance();
            f.OAuthAccessToken = "72157647663770865-93c55b9d31c01948";
            f.OAuthAccessTokenSecret = "3416dcf1a2760389";

            var info = f.PhotosGetInfo("15067750889");
            return info;
        }

        public Task UpdatePicture()
        {
            throw new NotImplementedException();
        }
    }
}
