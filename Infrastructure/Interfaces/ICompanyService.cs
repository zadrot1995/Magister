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
        IEnumerable<Company> GetCompanies();
        Company GetCompanyById(Guid id);
        Task<Company> GetCompanyByIdAsync(Guid id);
        void InsertCompany(Company company);
        void InsertCompanyAsync(Company company);
        Task<bool> DeleteCompany(Guid id);
        void UpdateCompany(Company company);
    }
}
