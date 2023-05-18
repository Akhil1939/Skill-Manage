using Serilog;
using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillEntities.DTOs.Skill;
using SkillRepositories.Interfaces;
using SkillServices.IServices;

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
        public async Task<bool> AddSkill(AddSkill NewSkill)
        {
            Skill skill = new Skill
            {
                SkillName = NewSkill.SkillName,
                Status = NewSkill.Status,
                CreatedAt = DateTime.Now,
            };

            try
            {
                await _skillGenRepo.AddAsync(skill);
                return true;
            }catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while adding a skill.");
                return false;
            }

            
        }

        public async Task<bool> UpdateSkill(UpdateSkill UpdateSkill)
        {
            Skill skill = new Skill
            {
                SkillId = UpdateSkill.SkillId,
                SkillName = UpdateSkill.SkillName,
                Status = UpdateSkill.Status,
                UpdatedAt = DateTime.Now,
            };

            try
            {
                await _skillGenRepo.DeleteAsync(skill);
                return true;
            }catch(Exception ex)
            {
                Log.Error(ex, "An error occurred while Updating a skill.");
                return false;
            }
        }

        public async Task<bool> DeleteSkill(long SkillId)
        {
            try
            {
              Skill skill =  await _skillGenRepo.GetByIdAsync(SkillId);
                if(skill != null)
                {
                    await _skillGenRepo.DeleteAsync(skill);
                    return true;
                }
                else
                {
                    throw new Exception("Skill not Found");
                }
            }catch(Exception ex)
            {
                Log.Error(ex, "An error occurred while Deleting a skill.");
                return false;
            }
        }


    }
}
