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
    public class AlbumTest
    {
        private IAlbumRepository GetAlbumRepository() {
            var logService = new NLogLoggerService();
            var httpClient = new HttpClient();
            ApiQueryService apiService = new ApiQueryService(logService, httpClient);
            var userRep = new AlbumRepository(apiService);
            return userRep;
        }

        [Fact]
        public async void AlbumList() {

            var albumRep = GetAlbumRepository();

            var albums = await albumRep.GetAllAsync();

            Assert.NotEmpty(albums);
        }
        [Fact]
        public async void AlbumById() {

            var albumRep = GetAlbumRepository();

            var album = await albumRep.GetAsync(1);

            Assert.NotNull(album);
        }
        [Fact]
        public async void AlbumListByUserId() {

            var albumRep = GetAlbumRepository();

            var albums = await albumRep.GetAlbumsByUserId(1);

            Assert.NotEmpty(albums);
        }
    }
}
