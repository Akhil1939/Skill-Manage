using Microsoft.AspNetCore.Mvc;
using SkillEntities.DataModels;
using SkillEntities.DTOs;
using SkillEntities.DTOs.Skill;
using SkillServices.IServices;

namespace Skill_Management.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
            
        }

        #region SkillListing and filter

        /// <summary>
        /// Skill Listing 
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <param name="Status"></param>
        /// <param name="Sort"></param>
        /// <param name="Keyword"></param>
        /// <returns>Skill List view with data</returns>
        public IActionResult Home(SkillFilter param , string? authorize)
        {
            AuthenticationMessage(authorize);


            DataList<SkillListing> SkillList = _skillService.GetSkillList(param.PageNo, param.PageSize, param.Status, param.Sort, param.Keyword);

            return View(SkillList);
        }


        /// <summary>
        /// Apply filter on skill
        /// </summary>
        /// <param name="param"></param>
        /// <returns> skill listingpartial view with filtered skill</returns>
        [HttpPost]
        public IActionResult SkillFilter([FromBody] SkillFilter param)
        {
            DataList<SkillListing> SkillList = _skillService.GetSkillList(param.PageNo, param.PageSize, param.Status, param.Sort, param.Keyword);
            return PartialView("Skill/_SkillListing", SkillList);
        }
        #endregion

        #region Add Skill

        /// <summary>
        /// Add skill 
        /// </summary>
        /// <returns> form for adding skill</returns>
        public IActionResult AddSkill()
        {
            return View();
        }

        /// <summary>
        /// Add new skill
        /// </summary>
        /// <param name="newSkill"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSkill(AddSkill newSkill)
        {
            if (ModelState.IsValid)
            {
                Skill skill = new Skill
                {
                    SkillName = newSkill.SkillName,
                    Status = newSkill.Status,
                    CreatedAt = DateTime.Now,
                };
                await _skillService.Add(skill);

                TempData["SuccessMessage"] = "Skill Added Successfull";
                return RedirectToAction("Home");
            }
            else
            {
                TempData["ErrorMessage"] = "Fill Valid Data";
                return View(newSkill);
            }
        }
        #endregion

        #region Update Skill
        /// <summary>
        /// Update Skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns> form filled with skill data</returns>
        public async Task<IActionResult> UpdateSkill(long id)
        {
            Skill skill = await _skillService.GetById(id);
            if (skill != null)
            {
                SkillDTO skillModel = new SkillDTO()
                {
                    SkillId = skill.SkillId,
                    SkillName = skill.SkillName,
                    Status = skill.Status,

                };
                return View(skillModel);
            }
            return RedirectToAction("Home");

        }

        /// <summary>
        /// UpdateSkill
        /// </summary>
        /// <param name="skill"></param>
        /// <returns> redirect to skill listing with message</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateSkill(SkillDTO skill)
        {
            if (ModelState.IsValid)
            {
                Skill oldSkill = await _skillService.GetById(skill.SkillId);

                oldSkill.SkillName = skill.SkillName;
                oldSkill.Status = skill.Status;
                oldSkill.UpdatedAt = DateTime.Now;

                await _skillService.Update(oldSkill);

                TempData["SuccessMessage"] = "Skill Updated Successfull";
                return RedirectToAction("Home");

            }
            else
            {
                TempData["ErrorMessage"] = "Fill Valid Data";
                return View(skill);
            }
        }
        #endregion

        #region Delete Skill

        /// <summary>
        /// Delete skill
        /// </summary>
        /// <param name="id"></param>
        /// <returns> redirect to skill listing with message</returns>
        public async Task<IActionResult> DeleteSkill(long id)
        {
            Skill skill = await _skillService.GetById(id);
            if(skill != null)
            {
            await _skillService.Delete(skill);
            TempData["SuccessMessage"] = "Skill Deleted Successfull";
            }
            return RedirectToAction("Home");
        }
        #endregion

        public void AuthenticationMessage(string? authorize)
        {
            if (authorize != null && authorize == "false")
            {
                TempData["ErrorMessage"] = "You are not authorize to this action";
            }
        }
}
}
