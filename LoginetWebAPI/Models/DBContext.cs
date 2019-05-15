using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LoginetWebAPI.Models
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }


        public async Task<UserModel>  GetUser(int id)
        {
            User user = await Users.FindAsync(id);
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

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            IEnumerable<UserModel> usersModel = await Users.Select(u => new UserModel {
                Id = u.Id,
                Account = u.Account,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Occupation = u.Occupation
            }).ToListAsync<UserModel>();

            return usersModel;
        }

        public async Task<IEnumerable<AlbumModel>> GetAllAlbums()
        {
            IEnumerable<AlbumModel> albumsModel = await Albums.Select(a => new AlbumModel
            {
                Id = a.Id,
                UserId = a.UserId,
                AlbumName = a.AlbumName,
                Description = a.Description
            }).ToListAsync();

            return albumsModel;
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
