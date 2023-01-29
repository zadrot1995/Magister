using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICompanyService
    {
        IQueryable<Company> GetCompanies();
        Company GetCompanyById(Guid id);
        Task<Company> GetCompanyByIdAsync(Guid id);
        void InsertCompany(Company company);
        System.Threading.Tasks.Task<bool> InsertCompanyAsync(Company company);
        Task<bool> DeleteCompany(Guid id);
        void UpdateCompany(Company company);
    }
}
