using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace LoginetWebAPI.Models
{
    public class JsonContext : IDataContext
    {
        readonly Uri UsersUri = new Uri("https://my-json-server.typicode.com/Aydarbek/MyJSON/users");
        readonly Uri AlbumsUri = new Uri("https://my-json-server.typicode.com/Aydarbek/MyJSON/albums");


        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                string UsersJson = await client.GetStringAsync(UsersUri);
                IEnumerable<UserModel> UsersModel = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<UserModel>>(UsersJson));
                return UsersModel;
            }
        }

        public async Task<UserModel> GetUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {            
                string UsersJson = await client.GetStringAsync(UsersUri);
                User user = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<User>>(UsersJson).FirstOrDefault(u => u.Id == id));
                UserModel userModel = new UserModel
                {
                    Id = user.Id,
                    Account = user.Account,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Occupation = user.Occupation
                };
                return userModel;
            }
        }

        public Task<IEnumerable<AlbumModel>> GetAllAlbums()
        {
            throw new NotImplementedException();
        }


        public Task<AlbumModel> GetAlbum(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumModel>> GetAlbumsOfUser(int id)
        {
            throw new NotImplementedException();
        }



 

    }
}
