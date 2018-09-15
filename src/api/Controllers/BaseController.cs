using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Interfaces;

namespace api.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IContext Context;
        protected readonly IMemoryCache MemoryCache;

        public BaseController(IContext context, IMemoryCache memoryCache)
        {
            Context = context;
            MemoryCache = memoryCache;
        }
    }
}