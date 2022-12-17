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

        public void DeleteCompany(Company Company)
        {
            _context.Companies.Remove(Company);
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

        public IEnumerable<Company> GetCompanys()
        {
            return _context.Companies;
        }

        public void InsertCompany(Company Company)
        {
            _context.Companies.Add(Company);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCompany(Company Company)
        {
            _context.Entry(Company).State = EntityState.Modified;
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
