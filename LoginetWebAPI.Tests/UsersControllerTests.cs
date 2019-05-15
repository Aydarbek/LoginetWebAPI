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
        public async Task GetAllUsersListTest()
        {
            //Setup
            var mock = new Mock<IDataContext>();
            mock.Setup(context => context.GetAllUsers()).Returns(GetUsersList());
            var userController = new UsersController(mock.Object);

            //Action
            IActionResult result = await userController.GetAll();

            //Assert
            var status = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserModel>>(status.Value);
            Assert.Equal(GetUsersList().Result.Count(), model.Count());


        }

        [Fact]
        public async Task GetUserTest()
        {
            //Setup
            var mock = new Mock<IDataContext>();
            mock.Setup(context => context.GetAllUsers()).Returns(GetUsersList());
            var userController = new UsersController(mock.Object);

            //Action
            IActionResult result = await userController.Get(2);

            //Assert
            var status = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<UserModel>(status.Value);

        }






        private async Task<IEnumerable<UserModel>> GetUsersList()
        {
            IEnumerable<UserModel> Users = new List<UserModel>
            {
                new UserModel {Id = 1, Account = "Account1", Email = "TestUser1@email.com", FirstName = "Billy", LastName = "Bons", Occupation = "NA"},
                new UserModel {Id = 2, Account = "Account2", Email = "TestUser2@email.com", FirstName = "Edward", LastName = "Zons", Occupation = "DA"},
                new UserModel {Id = 3, Account = "Account3", Email = "TestUser3@email.com", FirstName = "Billy", LastName = "Bons", Occupation = "Zabb"},
                new UserModel {Id = 4, Account = "Account4", Email = "TestUser4@email.com", FirstName = "Ivan", LastName = "Dark", Occupation = "Manager"},
                new UserModel {Id = 5, Account = "Account5", Email = "TestUser5@email.com", FirstName = "Willy", LastName = "", Occupation = ""}

            };
            return Users;
        }
    }
}
