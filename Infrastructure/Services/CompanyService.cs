using Azure;
using Azure.Core;
using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> DeleteCompany(Guid id)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(id);
            if (company == null)
            {
                throw new HttpStatusException(HttpStatusCode.NotFound, "Company not found");
            }
            _companyRepository.DeleteCompany(company);
            await _companyRepository.SaveAsync();
            return true;
        }

        public Company GetCompanyById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetCompanyByIdAsync(Guid id) => await _companyRepository.GetCompanyByIdAsync(id);

        public IEnumerable<Company> GetCompanys() => _companyRepository.GetCompanys();

        public void InsertCompany(Company company)
        {
            if (company != null)
            {
                _companyRepository.InsertCompany(company);
                _companyRepository.Save();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Company cannot be null");
        }

        public async void InsertCompanyAsync(Company company)
        {
            if (company != null)
            {
                await _companyRepository.InsertCompanyAsync(company);
                await _companyRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Company cannot be null");
        }

        public async void UpdateCompany(Company company)
        {
            if (company != null)
            {
                _companyRepository.UpdateCompany(company);
                await _companyRepository.SaveAsync();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Company cannot be null");
        }
    }
}
