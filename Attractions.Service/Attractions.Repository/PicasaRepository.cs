using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.GData.Client;
using Google.GData.Photos;

namespace Attractions.Repository
{
    public class PicasaRepository : IPicasaRepository
    {
        private Service service;
        private string authToken;
        private PicasaService picasaService;
        private PicasaFeed photoFeed;

        public string AddPicture()
        {
            service = new Service();
            this.service.setUserCredentials("aramkoukia", "AramP@ssw0rd");
            this.authToken = this.service.QueryClientLoginToken();


            System.IO.FileInfo fileInfo = new System.IO.FileInfo("d:\\1.jpg");
            System.IO.FileStream fileStream = fileInfo.OpenRead();

            PicasaEntry entry = new PhotoEntry();

            UserState ut = new UserState();
            ut.opType = UserState.OperationType.upload;
            entry.MediaSource = new Google.GData.Client.MediaFileSource(fileStream, "1.jpg" , "image/jpeg");
            this.picasaService = new PicasaService("");
            var atom = this.picasaService.Insert(new Uri(this.photoFeed.Post), entry);
            return atom.Id.ToString();

        }

        public Task AddPictureSet()
        {
            throw new NotImplementedException();
        }

    }

    public class UserState
    {
        public enum OperationType
        {
            upload,
            download,
            downloadList,
            query,
            queryForBackup
        }

        public string filename;
        public OperationType opType;
        public PicasaFeed feed;
        public int counter = 0;
        public string foldername;

    }


}
