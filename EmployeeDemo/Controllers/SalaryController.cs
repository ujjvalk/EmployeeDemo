using EmployeeDemo.Models.CustomModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EmployeeDemo.Controllers
{
    public class SalaryController : Controller
    {
        Repository.SalaryRepo _context;

        public SalaryController()
        {
            _context = new Repository.SalaryRepo();
        }
        public ActionResult Salary(long id = 0)
        {
            if (id == 0)
            {
                var data = _context.GetSalaries();
                ViewBag.EmpList = new SelectList(_context.GetEmpSelectList(), "Value", "Text");
                return View(data);
            }
            else
            {
                SalaryModel salaryModel = _context.GetSalaries(id);
                ViewBag.EmpList = new SelectList(_context.GetEmpSelectList(), "Value", "Text", salaryModel.empId);
                return PartialView("P_Form", salaryModel);
            }
        }

        [HttpPost]
        public ActionResult Salary(SalaryModel model)
        {

            if (model.salaryId == 0)
            {
                _context.Add(model);
                ViewBag.Successmessage = "Record saved successfully.";
            }
            else
            {
                _context.Update(model);
                ViewBag.Successmessage = "Record updated successfully.";
            }


            return PartialView("P_List", _context.GetSalaries());
        }

        public ActionResult Delete(long id)
        {
            _context.delete(id);
            return PartialView("P_List", _context.GetSalaries());
        }
    }
}