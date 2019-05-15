using System;
using Xunit;
using LoginetWebAPI.Controllers;
using LoginetWebAPI.Models;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;

namespace LoginetWebAPI.Tests
{
    public class AlbumsControllerTests
    {
        [Fact]
        public void GetAllAlbumsListTest()
        {

            //Setup
            Mock<IDataContext> mock = new Mock<IDataContext>();
            mock.Setup(context => context.Albums).Returns(GetAlbumsList());
            AlbumsController albumsController = new AlbumsController(mock.Object);

            //Action
            IActionResult result = albumsController.GetAll();

            //Assert
            var status = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<AlbumModel>>(status.Value);
            Assert.Equal(GetAlbumsList().Count(), model.Count());

        }

        [Fact]
        public void GetOneAlbumTest()
        {
            //Setup
            Mock<IDataContext> mock = new Mock<IDataContext>();
            mock.Setup(context => context.Albums).Returns(GetAlbumsList());
            AlbumsController albumsController = new AlbumsController(mock.Object);

            //Action
            IActionResult result = albumsController.Get(1);

            //Assert
            var status = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<AlbumModel>(status.Value);
            Assert.Equal(1, model.Id);
            Assert.Equal("TestName1", model.AlbumName);
        }

        [Fact]
        public void GetNotExistingAlbumTest()
        {
            //Setup
            Mock<IDataContext> mock = new Mock<IDataContext>();
            mock.Setup(context => context.Albums).Returns(GetAlbumsList());
            AlbumsController albumsController = new AlbumsController(mock.Object);

            //Action
            IActionResult result = albumsController.Get(10);

            //Assert
            var status = Assert.IsType<NotFoundResult>(result);
        }



        [Fact]
        public void GetAlbumsOfSomeUserTest()
        {
            //Setup
            Mock<IDataContext> mock = new Mock<IDataContext>();
            mock.Setup(context => context.Albums).Returns(GetAlbumsList());
            AlbumsController albumsController = new AlbumsController(mock.Object);

            //Action
            IActionResult result = albumsController.OfUser(1);

            //Assert
            var status = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<AlbumModel>>(status.Value);

            Assert.True(model.All(a => a.UserId == 1));
        }

        [Fact]
        public void GetAlbumsOfNotExistingUserTest()
        {
            //Setup
            Mock<IDataContext> mock = new Mock<IDataContext>();
            mock.Setup(context => context.Albums).Returns(GetAlbumsList());
            AlbumsController albumsController = new AlbumsController(mock.Object);

            //Action
            IActionResult result = albumsController.OfUser(10);

            //Assert
            var status = Assert.IsType<NotFoundResult>(result);
        }


        private IEnumerable<Album> GetAlbumsList()
        {
            IEnumerable<Album> Albums = new List<Album>
            {
                new Album {Id = 1, UserId = 1, AlbumName = "TestName1", Description = "SomeDescription1" },
                new Album {Id = 2, UserId = 1, AlbumName = "TestName2", Description = "SomeDescription2" },
                new Album {Id = 3, UserId = 2, AlbumName = "TestName3", Description = "SomeDescription3" },
                new Album {Id = 4, UserId = 2, AlbumName = "TestName4", Description = "SomeDescription4" },
                new Album {Id = 5, UserId = 3, AlbumName = "TestName5", Description = "SomeDescription5" }

            };
            return Albums;
        }

    }
}
