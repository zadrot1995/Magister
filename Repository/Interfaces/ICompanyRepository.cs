﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICompanyRepository : IDisposable
    {
        IQueryable<Company> GetCompanies();
        Company GetCompanyById(Guid id);
        Task<Company> GetCompanyByIdAsync(Guid id);
        void InsertCompany(Company company);
        System.Threading.Tasks.Task InsertCompanyAsync(Company company);
        void DeleteCompany(Company company);
        System.Threading.Tasks.Task UpdateCompany(Company company);
        void Save();
        System.Threading.Tasks.Task SaveAsync();
    }
}
