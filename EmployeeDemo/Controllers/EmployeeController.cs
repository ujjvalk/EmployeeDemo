using EmployeeDemo.Models.CustomModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private List<SelectListItem> GetHobbyList(List<string> data = null)
        {
            if (data == null)
            {
                return new List<SelectListItem> { new SelectListItem { Text = "Cricket", Value = "Cricket" }, new SelectListItem { Text = "Music", Value = "Music" }, new SelectListItem { Text = "Games", Value = "Games" } };
            }
            else
            {
                var resultList = new List<SelectListItem> { new SelectListItem { Text = "Cricket", Value = "Cricket" }, new SelectListItem { Text = "Music", Value = "Music" }, new SelectListItem { Text = "Games", Value = "Games" } };
                foreach (var item in data)
                {
                    var selected = resultList.Where(e => e.Value == item).FirstOrDefault();
                    if (selected != null)
                    {
                        selected.Selected = true;
                    }
                }
                return resultList;
            }
        }
        Repository.EmployeRepo _context;
        public EmployeeController()
        {
            _context = new Repository.EmployeRepo();
        }
        // GET: Employee
        public ActionResult Employee(long id = 0)
        {
            //ViewBag.hobbyList = GetHobbyList(null);
            if (id == 0)
            {
                var data = _context.GetEmployee();
                data.hbList = GetHobbyList(null);
                return View(data);
            }
            else
            {
                EmpModel empModel = _context.GetEmployee(id);
                empModel.hbList = GetHobbyList(empModel?.hobby?.Split(',').ToList()??null);
                return PartialView("P_Form", empModel);
            }
        }
         
        [HttpPost]
        public ActionResult Employee(EmpModel model)
        {
            //ViewBag.hobbyList = GetHobbyList(null);
            foreach (var item in model.hbList)
            {
                if (item.Selected)
                    model.hobby += item.Value + ",";
            }
            model.hobby = model.hobby.TrimEnd(',');
            if (model.empId == 0)
            {
                _context.Add(model);
                ViewBag.Successmessage = "Record saved successfully.";
            }
            else
            {
                _context.Update(model);
                ViewBag.Successmessage = "Record updated successfully.";
            }

            return PartialView("P_List", _context.GetEmployee());
        }

        public ActionResult Delete(long id)
        {
            _context.delete(id);
            return PartialView("P_List", _context.GetEmployee());
        }
    }
}