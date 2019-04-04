using PlaceholderApiDemo.Library.Models;
using PlaceholderApiDemo.Library.Repositories.Abstract;
using PlaceholderApiDemo.Library.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceholderApiDemo.Library.Repositories.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApiQueryService _apiService) 
            : base(_apiService, "https://jsonplaceholder.typicode.com/users/") {
        }
    }
}
