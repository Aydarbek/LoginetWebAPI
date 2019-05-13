using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoginetWebAPI.Models
{
    public class JsonContext : IDataContext
    {
        readonly Uri UsersUri = new Uri("https://my-json-server.typicode.com/Aydarbek/MyJSON/users");
        readonly Uri AlbumsUri = new Uri("https://my-json-server.typicode.com/Aydarbek/MyJSON/albums");


        public Task<AlbumModel> GetAlbum(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumModel>> GetAlbumsOfUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumModel>> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
