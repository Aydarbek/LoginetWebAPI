using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginetWebAPI.Models
{
    public interface IDataContext
    {
        Task<UserModel> GetUser(int id);
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<IEnumerable<AlbumModel>> GetAllAlbums();
        Task<AlbumModel> GetAlbum(int id);
        Task<IEnumerable<AlbumModel>> GetAlbumsOfUser(int id);
    }
}
