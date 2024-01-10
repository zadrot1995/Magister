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

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CompanyRepository(ApplicationDbContext context, UserManager<User> userManager)
        {
            this._context = context;
            _userManager = userManager;
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

            var user = await _userManager.Users.Where(x => x.Id == company.OwnerId).FirstOrDefaultAsync();
            user.CompanyId = company.Id;

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

        public async System.Threading.Tasks.Task UpdateCompany(Company company)
        {
            var companyToUpdate = await _context.Companies
                .Include(x => x.Category)
                .Include(x => x.ManagementSystem)
                .Include(x => x.Type)
                .Include(x => x.Workers)
                .Include(x => x.Technologies)
                .Include(x => x.Projects)
                .Where(x => x.Id == company.Id)
                .FirstOrDefaultAsync();


            if (company != null)
            {
                if (company.ManagementSystem != null)
                {
                    var options = await _context.Options.Where(x => company.ManagementSystem.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                    companyToUpdate.ManagementSystem = options;
                }
                if (company.Type != null)
                {
                    var options = await _context.Options.Where(x => company.Type.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                    companyToUpdate.Type = options;
                }
                if (company.Category != null)
                {
                    var options = await _context.Options
                        .Where(x => company.Category.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                    companyToUpdate.Category = options;
                }
                if(company.Workers != null)
                {
                    IEnumerable<User> workers = await _context.Users
                        .Where(x => company.Workers.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                    companyToUpdate.Workers = workers;
                }
                //if (company.Projects != null)
                //{
                //    IEnumerable<Project> projects = await _context.Projects
                //        .Where(x => company.Projects.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                //    companyToUpdate.Projects = projects;
                //}
                if (company.Technologies != null)
                {
                    IEnumerable<Technology> technologies = await _context.Technologies
                        .Where(x => company.Technologies.Select(y => y.Id).Contains(x.Id)).ToListAsync();
                    companyToUpdate.Technologies = technologies;
                }

                companyToUpdate.ImageUrl = company.ImageUrl;
                companyToUpdate.Description = company.Description;
                companyToUpdate.Name = company.Name;

                _context.Entry(companyToUpdate).State = EntityState.Modified;
            }
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
