using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.DbContexts;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CompanyRepository : ICompanyRepository, IDisposable
    {
        private bool disposed = false;
        private readonly IHttpContextAccessor _httpContextAccessor;


        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            this._context = context;

        }

        public void DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Company GetCompanyById(Guid id)
        {
            return _context.Companies.Find(id);
        }
        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public IQueryable<Company> GetCompanies()
        {
            return _context.Companies.AsQueryable();
        }

        public void InsertCompany(Company company)
        {
            _context.Companies.Add(company);
        }
        public async System.Threading.Tasks.Task InsertCompanyAsync(Company company)
        {
            if(company.ManagementSystem != null)
            {
                
                var options = await _context.Options.Where(x => company.ManagementSystem.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                company.ManagementSystem = options;
            }
            if (company.Type != null)
            {
                var options = await _context.Options.Where(x => company.Type.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                company.Type = options;
            }
            if (company.Category != null)
            {
                var options = await _context.Options.Where(x => company.Category.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                company.Category = options;
            }

            await _context.Companies.AddAsync(company);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateCompany(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
