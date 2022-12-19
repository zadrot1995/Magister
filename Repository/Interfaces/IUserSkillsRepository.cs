using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserSkillsRepository : IDisposable
    {
        IEnumerable<UserSkill> GetUserSkills();
        UserSkill GetUserSkillById(Guid id);
        Task<UserSkill> GetUserSkillByIdAsync(Guid id);
        void InsertUserSkill(UserSkill userSkill);
        void InsertUserSkillAsync(UserSkill userSkill);
        void DeleteUserSkill(UserSkill userSkill);
        void UpdateUserSkill(UserSkill userSkill);
        void Save();
        void SaveAsync();
    }
}
