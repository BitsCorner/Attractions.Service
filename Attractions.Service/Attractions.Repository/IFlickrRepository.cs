using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository
{
    public interface IFlickrRepository
    {
        Task AddPicture();
        Task UpdatePicture();
        Task GetPictures();
        Task AddPictureSet();
    }
}
