using PlaceholderApiDemo.Library.Models;
using PlaceholderApiDemo.Library.Repositories.Abstract;
using PlaceholderApiDemo.Library.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderApiDemo.Library.Repositories.Concrete
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ApiQueryService _apiService) 
            : base(_apiService, "https://jsonplaceholder.typicode.com/albums/") {
        }

        public async Task<List<Album>> GetAlbumsByUserId(int userId) {
            return await apiService.GetAsync<List<Album>>($"{baseUrl}?{nameof(userId)}={userId}");
        }
    }
}
