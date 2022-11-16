using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.BusinessLayer.ValidationRules;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            var values = _memberService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            MemberValidator validationRules = new MemberValidator();
            ValidationResult result = validationRules.Validate(member);
            if (result.IsValid)
            {
                _memberService.TInsert(member);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteMember(int id)
        {
            var values = _memberService.TGetByID(id);
            _memberService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateMember(int id)
        {
            var values = _memberService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateMember(Member member)
        {
            _memberService.TUpdate(member);
            return RedirectToAction("Index");
        }
    }
}
