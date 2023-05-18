using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillEntities.DTOs.Skill;

namespace SkillServices.IServices
{
    public interface ISkillService
    {
        DataList<SkillListing> GetSkillList(int PageNo, int PageSize, string Status, string Sort, string Keyword);
        Task<UpdateSkill> GetSkillById(long skillId);
        Task<bool> AddSkill(AddSkill newSkill);
        Task<bool> UpdateSkill(UpdateSkill updateSkill);
        Task<bool> DeleteSkill(long skillId);

    }
}
