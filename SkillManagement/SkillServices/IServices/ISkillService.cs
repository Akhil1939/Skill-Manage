using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillEntities.DTOs.Skill;

namespace SkillServices.IServices
{
    public interface ISkillService
    {
        DataList<SkillListing> GetSkillList(int PageNo, int PageSize, string Status, string Sort, string Keyword);
        Task<bool> AddSkill(AddSkill NewSkill);
        Task<bool> UpdateSkill(UpdateSkill UpdateSkill);
        Task<bool> DeleteSkill(long SkillId);

    }
}
