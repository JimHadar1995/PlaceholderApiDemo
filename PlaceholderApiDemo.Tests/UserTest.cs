using FrameWork;
using PlaceholderApiDemo.Library.Repositories.Abstract;
using PlaceholderApiDemo.Library.Repositories.Concrete;
using PlaceholderApiDemo.Library.Services;
using PlaceholderApiDemo.WebApi.App_Code;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace PlaceholderApiDemo.Tests
{
    public class UserTest
    {
        private IUserRepository GetUserRepository() {
            var logService = new NLogLoggerService();
            var httpClient = new HttpClient();
            ApiQueryService apiService = new ApiQueryService(logService, httpClient);
            var userRep = new UserRepository(apiService);
            return userRep;
        }
        [Fact]
        public async void UserList() {
            
            var userRep = GetUserRepository();
            
            var users = await userRep.GetAllAsync();
            
            Assert.NotEmpty(users);
        }
        [Fact]
        public async void UserById() {

            var userRep = GetUserRepository();

            var user = await userRep.GetAsync(1);

            Assert.NotNull(user);
        }
    }
}
