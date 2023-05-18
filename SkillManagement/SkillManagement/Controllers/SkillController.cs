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
        public IActionResult Home(int PageNo = 1, int PageSize = 5, string Status = "All", string? Sort = "New_to_Old", string? Keyword = "")
        {
            DataList<SkillListing> SkillList = _skillService.GetSkillList(PageNo, PageSize, Status, Sort, Keyword);

            return View(SkillList);
        }

        [HttpPost]
        public IActionResult SkillFilter([FromBody]SkillFilter param)
        {
            DataList<SkillListing> SkillList = _skillService.GetSkillList(param.PageNo, param.PageSize, param.Status, param.Sort, param.Keyword);
            return PartialView("Skill/_SkillListing", SkillList.Records);
        }

        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSkill(AddSkill newSkill)
        {
            if (ModelState.IsValid)
            {

                bool IsSkillAdded = await _skillService.AddSkill(newSkill);
                if (IsSkillAdded)
                {
                    TempData["SuccessMessage"] = "Skill Added Successfull";
                    return  RedirectToAction("Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Adding Skill";
                    return View(newSkill);
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Fill Valid Data";
                return View(newSkill);
            }
        }
        public async Task<IActionResult> UpdateSkill(long id)
        {
            UpdateSkill skill = await _skillService.GetSkillById(id);
            if(skill!= null)
            {
                return View(skill);
            }
            return RedirectToAction("Home");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateSkill(UpdateSkill skill)
        {
            if (ModelState.IsValid)
            {
                bool IsSkillUpdated = await _skillService.UpdateSkill(skill);
                if (IsSkillUpdated)
                {
                    TempData["SuccessMessage"] = "Skill Updated Successfull";
                    return RedirectToAction("Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Updating Skill";
                    return View(skill);
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Fill Valid Data";
                return View(skill);
            }
        }

        public async Task<IActionResult> DeleteSkill(long id)
        {
            bool isSkillDeleted = await _skillService.DeleteSkill(id);
            if (isSkillDeleted)
            {
                TempData["SuccessMessage"] = "Skill Deleted Successfull";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in Deleting Skill";
            }
            return RedirectToAction("Home");
        }
    }
}
