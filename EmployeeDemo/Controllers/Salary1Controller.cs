using EmployeeDemo.Models.CustomModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeDemo.Controllers
{
    public class Salary1Controller : Controller
    {
        Repository.SalaryRepo _context;
        public Salary1Controller()
        {
            _context = new Repository.SalaryRepo();
        }

        public ActionResult Salary(long id = 0)
        {
            //ViewBag.hobbyList = GetHobbyList(null);
            if (id == 0)
            {
                var data = _context.GetSalaries();
                return View(data);
            }
            else
            {
                EmpModel empModel = _context.GetEmployee(id);
                empModel.hbList = GetHobbyList(empModel?.hobby?.Split(',').ToList() ?? null);
                return PartialView("P_Form", empModel);
            }
        }
    }
}
