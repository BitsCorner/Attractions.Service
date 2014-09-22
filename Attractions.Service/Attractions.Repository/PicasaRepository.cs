using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository
{
    public class PicasaRepository : IPicasaRepository
    {

        private string userId = "aramkoukia@gmail.com";
        IHttpClientHelper httpClient;
        public PicasaRepository(IHttpClientHelper httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> AddPicture(string Title, string Summary, Stream fileBinary)
        {
            var albumId = 1;
            /*

            Content-Type: multipart/related; boundary="END_OF_PART"
            Content-Length: 423478347
            MIME-version: 1.0

            Media multipart posting
            --END_OF_PART
            Content-Type: application/atom+xml
            Slug: plz-to-love-realcat.jpg
            
            <entry xmlns='http://www.w3.org/2005/Atom'>
              <title>plz-to-love-realcat.jpg</title>
              <summary>Real cat wants attention too.</summary>
              <category scheme="http://schemas.google.com/g/2005#kind"
                term="http://schemas.google.com/photos/2007#photo"/>
            </entry>
            --END_OF_PART
            Content-Type: image/jpeg

            ...binary image data...
            --END_OF_PART--
            */

            var metaData = "<entry xmlns=\'http://www.w3.org/2005/Atom\'>" +
                              "<title>" + Title + "</title>" +
                              "<summary>" + Summary + "</summary>" +
                              "<category scheme=\"http://schemas.google.com/g/2005#kind" +
                                "term=\"http://schemas.google.com/photos/2007#photo\"/>" +
                            "</entry>";

            var url =string.Format("https://picasaweb.google.com/data/feed/api/user/{0}/albumid/{1}", userId, albumId);
            var content = new StringContent(metaData, Encoding.UTF8, "application/atom+xml");

            var result = await this.httpClient.CallHttpClientPost(url, content);

            return result.Content.ToString();

        }

        public string GetPictures()
        {
            
            var url = string.Format("https://picasaweb.google.com/data/feed/api/user/{0}/",userId);
            var result = this.httpClient.CallHttpClientGet(url).Result;
            var content = result.Content.ReadAsStringAsync().Result;
            try
            {
                var locations = content;
                return locations;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
