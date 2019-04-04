using PlaceholderApiDemo.Library.Models;
using PlaceholderApiDemo.Models.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderApiDemo.Library.Repositories.Abstract
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<List<Album>> GetAlbumsByUserId(int userId);
    }
}
