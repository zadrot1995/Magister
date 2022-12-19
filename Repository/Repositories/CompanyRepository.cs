using Domain.Models;
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

        public IEnumerable<Company> GetCompanys()
        {
            return _context.Companies;
        }

        public void InsertCompany(Company company)
        {
            _context.Companies.Add(company);
        }
        public async void InsertCompanyAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async void SaveAsync()
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
