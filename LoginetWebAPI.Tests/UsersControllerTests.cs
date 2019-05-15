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
    public class UsersControllerTests
    {

        [Fact]
        public void GetAllUsersListTest()
        {

            //Setup
            Mock<IDataContext> mock = new Mock<IDataContext>();
            mock.Setup(context => context.Users).Returns(GetUsersList());
            UsersController usersController = new UsersController(mock.Object);

            //Action
            IActionResult result = usersController.GetAll();

            //Assert
            var status = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(status.Value);
            Assert.Equal(GetUsersList().Count(), model.Count());

        }

        [Fact]
        public void GetOneUserTest()
        {
            //Setup
            Mock<IDataContext> mock = new Mock<IDataContext>();
            mock.Setup(context => context.Users).Returns(GetUsersList());
            UsersController usersController = new UsersController(mock.Object);

            //Action
            IActionResult result = usersController.Get(5);

            //Assert            
            var status = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<User>(status.Value);
            Assert.Equal(5, model.Id);
            Assert.Equal("TestUser5@email.com", model.Email);
            Assert.Null(model.LastName);
        }

        [Fact]
        public void GetNotExistedUserTest()
        {
            //Setup
            Mock<IDataContext> mock = new Mock<IDataContext>();
            mock.Setup(context => context.Users).Returns(GetUsersList());
            UsersController usersController = new UsersController(mock.Object);

            //Action
            IActionResult result = usersController.Get(6);

            //Assert            
            var status = Assert.IsType<NotFoundResult>(result);
        }


        private IEnumerable<User> GetUsersList()
        {
            IEnumerable<User> Users = new List<User>
            {
                new User {Id = 1, Account = "Account1", Email = "TestUser1@email.com", FirstName = "Billy", LastName = "Bons", Occupation = "NA"},
                new User {Id = 2, Account = "Account2", Email = "TestUser2@email.com", FirstName = "Edward", LastName = "Zons", Occupation = "DA"},
                new User {Id = 3, Account = "Account3", Email = "TestUser3@email.com", FirstName = "Billy", LastName = "Bons", Occupation = "Zabb"},
                new User {Id = 4, Account = "Account4", Email = "TestUser4@email.com", FirstName = "Ivan", LastName = "Dark", Occupation = "Manager"},
                new User {Id = 5, Account = "Account5", Email = "TestUser5@email.com", FirstName = "Willy", LastName = null, Occupation = null}

            };
            return Users;
        }
    }
}
