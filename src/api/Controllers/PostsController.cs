using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Scraffold;
using Swashbuckle.AspNetCore.SwaggerGen;

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
        [SwaggerResponse(201)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        public ListaPaginada<PostsModel> Get([FromQuery] ParametrosPaginacao model)
        {
            var posts = new List<PostsModel>();
            posts = RestornaPostsList();
            if (posts == null)
            {
                posts = posts.Where(x => x.Titulo.ToLower().Contains(model.buscaTermo.ToLower())).ToList();
            }
            var listaPaginada = new ListaPaginada<PostsModel>(model.PageNumber, model.PageSize);
            return listaPaginada.Carregar(posts);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [SwaggerResponse(201)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]

        public ActionResult<PostsModel> Get(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                return Ok(RestornaPostsList().Find(x => x.Id == id));
            }
            return Ok(new { Response = "Nenhum Resultado Encontrado" });
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
