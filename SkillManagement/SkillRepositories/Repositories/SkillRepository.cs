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
    public class SkillRepository : Repository<Skill>, ISkillRepository 
    {

        private readonly ManagementContext _dbContext;
        public SkillRepository(ManagementContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        
    }
}
