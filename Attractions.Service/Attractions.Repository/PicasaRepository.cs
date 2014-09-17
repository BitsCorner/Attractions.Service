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

        IHttpClientHelper httpClient;
        public PicasaRepository(IHttpClientHelper httpClient)
        {
            this.httpClient = httpClient;
        }

        public string AddPicture()
        {
            return "";
        }

        public string GetPictures()
        {
            var userId = "aramkoukia@gmail.com";
            var url = string.Format("https://picasaweb.google.com/data/feed/api/user/{0}/",userId);
            var result = this.httpClient.CallHttpClientGet(url).Result;
            var content = result.Content.ReadAsStringAsync().Result;
            try
            {
                var locations = content;
                return locations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
