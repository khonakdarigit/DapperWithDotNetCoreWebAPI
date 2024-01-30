using Azure.Core;
using DapperWithDotNetCoreWebAPI.Contract;
using DapperWithDotNetCoreWebAPI.Dto;
using DapperWithDotNetCoreWebAPI.Entitis;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperWithDotNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly ICompanyRepository _companyRepo;

        public CompaniesController(ILoggerManager logger, ICompanyRepository companyRepo)
        {
            _logger = logger;
            _companyRepo = companyRepo;
        }
        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInfo("Get All Companies");

            var companies = await _companyRepo.GetCompanies();
            return Ok(companies);

        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var company = await _companyRepo.GetCompany(id);
                if (company == null)
                    return NotFound();

                _logger.LogInfo($"Get Company {company.Id}");

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CompaniesController>/5
        [HttpGet("ByEmployeeId/{id}")]
        public async Task<IActionResult> ByEmployeeId(int id)
        {
            try
            {
                var company = await _companyRepo.GetCompanyByEmployeeId(id);
                if (company == null)
                    return NotFound();

                _logger.LogInfo($"Get Company ByEmployeeId cid: {company.Id} eid: {id}");

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyForCreationDto value)
        {
            var createdCompany = await _companyRepo.CreateCompany(value);

            _logger.LogInfo($"Insert Company {createdCompany.Id}");

            return Ok(createdCompany);
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CompanyForUpdateDto value)
        {
            try
            {
                var dbCompany = await _companyRepo.GetCompany(id);
                if (dbCompany == null)
                    return NotFound();
                await _companyRepo.UpdateCompany(id, value);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInfo($"Update Company fail\nError: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var dbCompany = await _companyRepo.GetCompany(id);
                if (dbCompany == null)
                    return NotFound();
                await _companyRepo.DeleteCompany(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInfo($"Delete Company fail\nError: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
