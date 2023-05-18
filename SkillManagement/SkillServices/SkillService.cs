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

        public DataList<SkillListing> GetSkillList(int PageNo, int PageSize, string Status, string Sort, string Keyword)
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
                    SkillList = SkillList.OrderBy(skill => skill.CreatedAt);
                    break;
                case "New_to_Old":
                    SkillList = SkillList.OrderByDescending(skill => skill.CreatedAt);
                    break;
                default:
                    break;
            }

            DataList<SkillListing> Result = new();
            Result.TotalRecords = SkillList.Count();
            Result.Records = SkillList.Skip((PageNo - 1)* PageSize).Take(PageSize)
                .Select(skill=> new SkillListing()
                {
                    SkillId = skill.SkillId,
                    SkillName = skill.SkillName,
                    Status = skill.Status

                })
                .ToList();
            return Result;

        }
        public async Task<bool> AddSkill(AddSkill newSkill)
        {
            Skill skill = new Skill
            {
                SkillName = newSkill.SkillName,
                Status = newSkill.Status,
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
        public async Task<UpdateSkill> GetSkillById(long skillId)
        {
            Skill skill = await _skillGenRepo.GetByIdAsync(skillId);

            if (skill != null)
            {
                return new UpdateSkill()
                {
                    SkillId = skill.SkillId,
                    SkillName = skill.SkillName,
                    Status = skill.Status
                };
            }
            return new UpdateSkill();
        }

        public async Task<bool> UpdateSkill(UpdateSkill updateSkill)
        {
            Skill oldSkill = await _skillGenRepo.GetByIdAsync(updateSkill.SkillId);
            oldSkill.SkillName = updateSkill.SkillName;
            oldSkill.Status = updateSkill.Status;
            oldSkill.UpdatedAt = DateTime.Now;

            try
            {
                await _skillGenRepo.UpdateAsync(oldSkill);
                return true;
            }catch(Exception ex)
            {
                Log.Error(ex, "An error occurred while Updating a skill.");
                return false;
            }
        }

        public async Task<bool> DeleteSkill(long skillId)
        {
            try
            {
              Skill skill =  await _skillGenRepo.GetByIdAsync(skillId);
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
