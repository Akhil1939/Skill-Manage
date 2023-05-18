using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillRepositories.Interfaces;
using SkillServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillServices
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _skillGenRepo;

        public SkillService(IRepository<Skill> skillGenRepo)
        {
            _skillGenRepo = skillGenRepo;
        }

       
        public DataList<Skill> GetSkillList(int PageNo, int PageSize, string Status, string Sort, string Keyword)
        {
            IQueryable<Skill> SkillList = _skillGenRepo.GetAll();

            switch (Status)
            {
                case "All":
                    break;
                case "Active":
                    SkillList = SkillList.Where(skill => skill.Status == 1);
                    break;
                case "Inactive":
                    SkillList = SkillList.Where(skill => skill.Status == 0);
                    break;
            }


            if (!string.IsNullOrEmpty(Keyword))
            {
                SkillList = SkillList.Where(skill => skill.SkillName!.ToLower().Contains(Keyword.ToLower()));
            }

            switch (Sort)
            {
                case "A_to_Z":
                    SkillList = SkillList.OrderBy(skill => skill.SkillName);
                    break;
                case "Z_to_A":
                    SkillList = SkillList.OrderByDescending(skill => skill.SkillName);
                    break;
                case "Old_to_New":
                    SkillList = SkillList.OrderByDescending(skill => skill.CreatedAt);
                    break;
                case "New_to_Old":
                    SkillList = SkillList.OrderBy(skill => skill.CreatedAt);
                    break;
                default:
                    break;
            }

            DataList<Skill> Result = new();
            Result.TotalRecords = SkillList.Count();
            Result.Records = SkillList.Skip((PageNo - 1)* PageSize).Take(PageSize).ToList();
            return Result;

        }
    }
}
