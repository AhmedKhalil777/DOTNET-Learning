using Learning.OData.Models;
using Learning.OData.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Learning.OData.Controllers
{
    public class CatalogsController : ODataController
    {

        private readonly AppDbContext _context;

        public CatalogsController(AppDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public ActionResult<IQueryable<Catalog>> Get()
        {
            return Ok(_context.Catalogs.Include(x=> x.Images));
        }

        [EnableQuery]
        public ActionResult<Catalog> Get([FromRoute] int key)
        {
            var item = _context.Catalogs.SingleOrDefault(d => d.Id.Equals(key));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
