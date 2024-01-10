using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            var result = await _companyService.GetCompanies().ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(Guid id)
        {
            var result = await _companyService.GetCompanyByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> InsertCompany([FromBody] Company company) 
        {
            return Ok(await _companyService.InsertCompanyAsync(company));
        }

        [HttpPut]
        public async Task<ActionResult<Company>> Update([FromBody] Company company)
        {
            return Ok(await _companyService.UpdateCompany(company));
        }

    }
}
