using CSBC.Core.Models;
using CSBC.Core;
using CSBC.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSBC.Core.Data;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace Csbc.Admin.WebControllers
{
    //[EnableCorsAttribute("http://localhost:44605","*","*")]
    public class WebContentController : ApiController
    {
        [EnableQuery]
		public IEnumerable<WebContent> Get()
        {
            var repo = new WebContentRepository(new CSBCDbContext());
            return repo.GetAll(1);
        }

        [EnableQuery]
		public WebContent Get(int id)
        {
            WebContent content;
            var repo = new WebContentRepository(new CSBCDbContext());
            if (id > 0)
            {
                content = repo.GetById(id);
            }
            else
            {
                content = new WebContent();
            }
            return content;
        }
		public void Post([FromBody]WebContent content)
		{
			var repo = new WebContentRepository(new CSBCDbContext());
			var newProduct = repo.Insert(content);
		}

		// PUT: api/Products/5
		public void Put(int id, [FromBody]WebContent content)
		{
			var repo = new WebContentRepository(new CSBCDbContext());
			repo.Update(content);
		}
	}
}
