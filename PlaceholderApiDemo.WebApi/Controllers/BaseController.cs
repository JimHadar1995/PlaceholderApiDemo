using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameWork;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlaceholderApiDemo.WebApi.Controllers {

    public class BaseController : Controller {
        protected ILogService logService;
        public BaseController(ILogService _logService) {
            logService = _logService;
        }
    }
}
