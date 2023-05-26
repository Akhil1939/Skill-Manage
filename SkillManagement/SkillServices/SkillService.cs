using Serilog;
using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillEntities.DTOs.Skill;
using SkillRepositories.Interfaces;
using SkillServices.IServices;

namespace SkillServices
{
    public class SkillService :Service<Skill>, ISkillService
    {
        
        private readonly ISkillRepository _skillRepo;

        public SkillService( ISkillRepository skillRepository):base(skillRepository)
        {
           
            _skillRepo = skillRepository;

        }

        #region Get Skill List
        /// <summary>
        /// Get skill list
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <param name="Status"></param>
        /// <param name="Sort"></param>
        /// <param name="Keyword"></param>
        /// <returns>List of Skill filtered by given params</returns>
        public DataList<SkillListing> GetSkillList(int PageNo, int PageSize, string Status, string Sort, string Keyword)
        {
            IQueryable<Skill> SkillList = _skillRepo.GetAll();

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
            Result.TotalPages = Math.Ceiling((decimal)SkillList.Count() / PageSize);
            Result.Records = SkillList.Skip((PageNo - 1) * PageSize).Take(PageSize)
                .Select(skill => new SkillListing()
                {
                    SkillId = skill.SkillId,
                    SkillName = skill.SkillName,
                    Status = skill.Status

                })
                .ToList();
            return Result;

        }
        #endregion

      

        

       

        

    }
}
