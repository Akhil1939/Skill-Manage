using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRepositories.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        public Task<List<Skill>> GetSkillList(int PageNo, int PageSize, string Sort, string Keyword)
        {
            throw new NotImplementedException();
        }
    }
}
