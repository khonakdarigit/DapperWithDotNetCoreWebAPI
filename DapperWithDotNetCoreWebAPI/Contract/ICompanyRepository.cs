using DapperWithDotNetCoreWebAPI.Dto;
using DapperWithDotNetCoreWebAPI.Entitis;

namespace DapperWithDotNetCoreWebAPI.Contract
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetCompanies();
        public Task<Company> GetCompany(int id);
        public Task<Company> CreateCompany(CompanyForCreationDto company);
        public Task CreateMultipleCompanies(List<CompanyForCreationDto> company);
        public Task UpdateCompany(int id, CompanyForUpdateDto company);
        public Task DeleteCompany(int id);
        public Task<Company?> GetCompanyByEmployeeId(int id);
        public Task<Company?> GetCompanyEmployeesMultipleResults(int id);
        public Task<List<Company>> GetCompaniesEmployeesMultipleMapping();
    }
}
