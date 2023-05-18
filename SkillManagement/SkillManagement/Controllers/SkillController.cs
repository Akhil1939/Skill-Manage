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
        public IActionResult SkillFilter([FromBody] SkillFilter Params)
        {
            DataList<SkillListing> SkillList = _skillService.GetSkillList(Params.PageNo, Params.PageSize, Params.Status, Params.Sort, Params.Keyword);
            return PartialView("Skill/_SkillListing", SkillList.Records);
        }

        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSkill(AddSkill NewSkill)
        {
            if (ModelState.IsValid)
            {

                bool IsSkillAdded = await _skillService.AddSkill(NewSkill);
                if (IsSkillAdded)
                {
                    return  RedirectToAction("Home");
                }
                else
                {
                    return View(NewSkill);
                }
            }
            else
            {
                return View(NewSkill);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSkill(UpdateSkill Skill)
        {
            if (ModelState.IsValid)
            {
                bool IsSkillUpdated = await _skillService.UpdateSkill(Skill);
                if (IsSkillUpdated)
                {
                    return View("Home");
                }
                else
                {
                    return View(Skill);
                }
            }
            else
            {
                return View(Skill);
            }
        }
    }
}
