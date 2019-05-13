using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoginetWebAPI.Models
{
    public class DBContext : DbContext, IDataContext
    {
        public DBContext (DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }


        public async Task<User>  GetUser(int id)
        {
            User User = await Users.FindAsync(id);
            return User;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            IEnumerable<User> users = await Users.ToListAsync<User>();
            return Users;
        }

        public async Task<IEnumerable<AlbumModel>> GetAllAlbums()
        {
            IEnumerable<AlbumModel> albums = await Albums.Select(a => new AlbumModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AlbumName = a.AlbumName,
                Description = a.Description
            }).ToListAsync();

            return albums;
        }


        public async Task<AlbumModel> GetAlbum(int id)
        {
            Album album = await Albums.FindAsync(id);
            AlbumModel albumModel = new AlbumModel
            {
                Id = album.Id,
                UserId = album.UserId,
                AlbumName = album.AlbumName,
                Description = album.Description
            };

            return albumModel;
        }


        public async Task<IEnumerable<AlbumModel>> GetAlbumsOfUser(int id)
        {
            IEnumerable<AlbumModel> albumsModel = await Albums.Where(a => a.UserId == id).Select(a => new AlbumModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AlbumName = a.AlbumName,
                Description = a.Description
            }).ToListAsync();

            return albumsModel;
        }


    }
}
