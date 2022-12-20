using Domain.Models;
using Infrastructure.Interfaces;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async void DeleteCompany(Guid id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);
            if (company != null)
            {
                _companyRepository.DeleteCompany(company);
                await _companyRepository.SaveAsync();
            }
        }

        public Company GetCompanyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetCompanyByIdAsync(Guid id) => await _companyRepository.GetCompanyByIdAsync(id);

        public IEnumerable<Company> GetCompanys() => _companyRepository.GetCompanys();

        public void InsertCompany(Company company)
        {
            if(company != null)
            {
                _companyRepository.InsertCompany(company);
                _companyRepository.Save();
            }
        }

        public async void InsertCompanyAsync(Company company)
        {
            if(company != null)
            {
                await _companyRepository.InsertCompanyAsync(company);
                await _companyRepository.SaveAsync();
            }
        }

        public async void UpdateCompany(Company company)
        {
            if (company != null)
            {
                _companyRepository.UpdateCompany(company);
                await _companyRepository.SaveAsync();
            }
        }
    }
}
