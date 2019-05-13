using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginetWebAPI.Models
{
    public interface IDataContext
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<AlbumModel>> GetAllAlbums();
        Task<AlbumModel> GetAlbum(int id);
        Task<IEnumerable<AlbumModel>> GetAlbumsOfUser(int id);
    }
}
