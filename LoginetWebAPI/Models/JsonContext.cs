using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

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

        public async Task<IEnumerable<AlbumModel>> GetAllAlbums()
        {
            using (HttpClient client = new HttpClient())
            {
                string AlbumsJson = await client.GetStringAsync(AlbumsUri);
                IEnumerable<AlbumModel> AlbumsModel = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<AlbumModel>>(AlbumsJson));

                return AlbumsModel;
            }
        }


        public async Task<AlbumModel> GetAlbum(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string AlbumsJson = await client.GetStringAsync(AlbumsUri);
                AlbumModel AlbumModel = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<AlbumModel>>(AlbumsJson).FirstOrDefault(u => u.Id == id));

                return AlbumModel;
            }
        }

        public async Task<IEnumerable<AlbumModel>> GetAlbumsOfUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string AlbumsJson = await client.GetStringAsync(AlbumsUri);

                IEnumerable<AlbumModel> AlbumsModel = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<AlbumModel>>(AlbumsJson)
                    .Where(a => a.UserId == id).ToList<AlbumModel>());

                return AlbumsModel;
            }
        }



 

    }
}
