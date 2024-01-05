using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly ApplicationDbContext _userContext;

        public OptionController(ApplicationDbContext userContext)
        {
            _userContext = userContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IGrouping<OptionContextType, Option>>>> Get()
        {
            var result = await _userContext.Options.GroupBy(x => x.OptionContext).ToListAsync();
            return result;
        }
    }
}
