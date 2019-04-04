using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWork;
using FrameWork.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using PlaceholderApiDemo.Models.DAL.Abstract;

namespace PlaceholderApiDemo.WebApi.Controllers
{
    public class BaseEntityController<TEntity> : BaseController
        where TEntity : class, IBaseObject, new()
    {
        protected IRepository<TEntity> repository;
        public BaseEntityController(ILogService _logService, 
                                    IRepository<TEntity> _repository) 
            : base(_logService) {
            repository = _repository;
        }
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> Get() {
            try {
                var res = await repository.GetAllAsync();
                return res;
            }
            catch(Exception e) {
                logService.LogFatal(e);
#if DEBUG
                throw e;
#endif
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> Get(int id) {
            try {
                var res = await repository.GetAsync(id);
                return res;
            }
            catch(Exception e) {
                logService.LogFatal(e);
#if DEBUG
                throw e;
#endif
            }
            return BadRequest();
        }
    }
}
