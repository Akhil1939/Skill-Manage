using Microsoft.AspNetCore.Mvc;
using SkillEntities.DataModels;
using SkillEntities.DTOs;
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
        public IActionResult Home(int PageNo=1, int PageSize=5,string Status="All", string? Sort="A_to_Z", string? Keyword= "")
        {
            DataList<Skill> SkillList = _skillService.GetSkillList(PageNo, PageSize, Status, Sort, Keyword);

            return View(SkillList);
        }
    }
}
