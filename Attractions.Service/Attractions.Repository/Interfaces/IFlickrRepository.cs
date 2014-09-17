using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Attractions.Repository
{
    public interface IFlickrRepository
    {
        string AddPicture(Stream stream, string fileName, string title, string description, string tags, bool isPublic, bool isFamily, bool isFriend);
        FlickrNet.PhotoInfo GetPictures();
        Task AddPictureSet();
    }
}
