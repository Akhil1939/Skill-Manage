using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillEntities.DTOs.Skill;

namespace SkillServices.IServices
{
    public interface ISkillService : IService<Skill>
    {
        /// <summary>
        /// get list of skill filtered with given params
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <param name="Status"></param>
        /// <param name="Sort"></param>
        /// <param name="Keyword"></param>
        /// <returns> list of skill</returns>
        DataList<SkillListing> GetSkillList(int PageNo, int PageSize, string Status, string Sort, string Keyword);

        

        
        

        

    }
}
