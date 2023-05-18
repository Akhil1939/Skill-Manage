using SkillEntities.DataModels;
using SkillEntities.DTOs;


namespace SkillServices.IServices
{
    public interface ISkillService
    {
        DataList<Skill> GetSkillList(int PageNo, int PageSize, string Status, string Sort, string Keyword);
    }
}
