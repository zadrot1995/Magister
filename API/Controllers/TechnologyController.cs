using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TechnologyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technology>>> Get()
        {
            return await _dbContext.Technologies.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Technology technology)
        {
            if(technology == null) 
            {
                return BadRequest();
            }
            await _dbContext.Technologies.AddAsync(technology);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
