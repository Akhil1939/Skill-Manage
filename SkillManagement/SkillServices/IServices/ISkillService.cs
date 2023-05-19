using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillEntities.DTOs.Skill;

namespace SkillServices.IServices
{
    public interface ISkillService
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

        /// <summary>
        /// get skill by id
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns>Single skill entity </returns>
        Task<SkillEntities.DTOs.Skill.Skill> GetSkillById(long skillId);

        /// <summary>
        /// Add new skill
        /// </summary>
        /// <param name="newSkill"></param>
        /// <returns>boolean response</returns>
        Task<bool> AddSkill(AddSkill newSkill);

        /// <summary>
        /// Update skill
        /// </summary>
        /// <param name="updateSkill"></param>
        /// <returns>boolean response</returns>
        Task<bool> UpdateSkill(SkillEntities.DTOs.Skill.Skill updateSkill);

        /// <summary>
        /// Delete Skill
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns>boolean response</returns>
        Task<bool> DeleteSkill(long skillId);

    }
}
