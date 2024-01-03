using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITechnologyRepository : IDisposable
    {
        IEnumerable<Technology> Get();
        Technology Get(Guid id);
        Task<Technology> GetAsync(Guid id);
        void Insert(Technology userSkill);
        void InsertAsync(Technology userSkill);
        void Delete(Technology userSkill);
        void Update(Technology userSkill);
        void Save();
        void SaveAsync();
    }
}
