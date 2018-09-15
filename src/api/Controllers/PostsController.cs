using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Scraffold;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        public PostsController(IContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
        }

        // GET api/values
        [HttpGet]
        public List<PostsModel> Get()
        {
            var Posts = new List<PostsModel>();
            Posts = RestornaPostsList();

            return Posts;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private List<PostsModel> RestornaPostsList()
        {
            return MemoryCache.GetOrCreate("posts", entry =>
                                  {
                                      entry.AbsoluteExpiration = DateTime.UtcNow.AddDays(1);
                                      return Context.Posts
                                  .Select(x => new PostsModel
                                      {
                                          Id = x.Id,
                                          Titulo = x.Titulo,
                                          Descricao = x.Descricao,
                                          DataCreate = x.DataCreate
                                      }).ToList();
                                  });
        }
    }
}
