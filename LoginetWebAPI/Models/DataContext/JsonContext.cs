using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace LoginetWebAPI.Models
{
    public class JsonContext: IDataContext
    {

        internal Uri UsersUri = new Uri("https://my-json-server.typicode.com/Aydarbek/MyJSON/users");
        internal Uri AlbumsUri = new Uri("https://my-json-server.typicode.com/Aydarbek/MyJSON/albums");

        public IEnumerable<User> Users
        {
            get { return GetUsers().Result; }
        }

        public IEnumerable<Album> Albums
        {
            get { return GetAlbums().Result; }
        } 


        public async Task<IEnumerable<User>> GetUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                string usersJson = await client.GetStringAsync(UsersUri);
                IEnumerable<User> Users = JsonConvert.DeserializeObject<IEnumerable<User>>(usersJson);
                return Users;
            }
        }


        public async Task<IEnumerable<Album>> GetAlbums()
        {
            using (HttpClient client = new HttpClient())
            {
                string albumsJson = await client.GetStringAsync(AlbumsUri);
                IEnumerable<Album> Albums = JsonConvert.DeserializeObject<IEnumerable<Album>>(albumsJson);
                return Albums;
            }
        }

    }
}
