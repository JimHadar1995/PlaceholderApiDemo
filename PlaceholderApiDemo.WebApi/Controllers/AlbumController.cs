using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaceholderApiDemo.Library.Models;
using PlaceholderApiDemo.Library.Repositories.Abstract;
using PlaceholderApiDemo.Models.DAL.Abstract;

namespace PlaceholderApiDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : BaseEntityController<Album>
    {
        public AlbumController(ILogService _logService, IAlbumRepository _repository) 
            : base(_logService, _repository) {
        }
    }
}