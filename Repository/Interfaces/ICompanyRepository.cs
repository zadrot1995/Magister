using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICompanyRepository : IDisposable
    {
        IEnumerable<Company> GetCompanys();
        Company GetCompanyById(Guid id);
        Task<Company> GetCompanyByIdAsync(Guid id);
        void InsertCompany(Company company);
        void InsertCompanyAsync(Company company);
        void DeleteCompany(Company company);
        void UpdateCompany(Company Company);
        void Save();
        void SaveAsync();
    }
}
