using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository
{
    public class PicasaRepository : IPicasaRepository
    {
        public string AddPicture()
        {
            var googleApi = Google.Apis.Http.
            
            return photoId;
        }

        public Task AddPictureSet()
        {
            throw new NotImplementedException();
        }

        public string GetPictures()
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
