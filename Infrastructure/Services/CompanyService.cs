using Azure;
using Azure.Core;
using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
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

        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            var result = await _companyRepository.GetCompanyByIdAsync(id);
            if (result != null)
            {
                return result;
            }
            throw new HttpStatusException(HttpStatusCode.NotFound, "Company not found");
        }

        private void ThreadProc(int start, int end, out List<Company> companies)
        {
            Range range = new Range(start, end);
            companies = _companyRepository.GetCompanies().Take(range).ToList();
        }

        public IQueryable<Company> GetCompanies() => _companyRepository.GetCompanies();

        public void InsertCompany(Company company)
        {
            if (company != null)
            {
                _companyRepository.InsertCompany(company);
                _companyRepository.Save();
            }
            throw new HttpStatusException(HttpStatusCode.BadRequest, "Company cannot be null");
        }

        public async Task<Company> InsertCompanyAsync(Company company)
        {
            if (company != null)
            {
                await _companyRepository.InsertCompanyAsync(company);
                await _companyRepository.SaveAsync();
                return company;
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
