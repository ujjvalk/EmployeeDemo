using EmployeeDemo.Models;
using EmployeeDemo.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeDemo.Repository
{
    public class SalaryRepo
    {
        private readonly EmployeeDemoEntities _db;

        public SalaryRepo()
        {
            _db = new EmployeeDemoEntities();
        }

        public List<SelectListItem> GetEmpSelectList()
        {
            return (from e in _db.Employees select new SelectListItem { Text = e.fName + " " + e.mName + " " + e.lName, Value = e.empId.ToString() }).Distinct().ToList();
        }

        public SalaryModel GetSalaries(long id = 0)
        {
            var result = new SalaryModel();
            try
            {
                if (id > 0)
                {
                    var data = _db.Salaries.Find(id);
                    if (data != null)
                    {
                        result.date = data.date;
                        result.sal = data.sal;
                        result.empId = data.empId;
                        result.salaryId = data.salaryId;
                    }
                    else
                    {
                        result.salaryId = 0;
                    }
                }
                else
                {
                    var data = _db.Salaries.ToList();
                    if (data != null)
                    {
                        result.salList = (from e in data
                                          join s in _db.Employees on e.empId equals s.empId into esm
                                          from ss in esm.DefaultIfEmpty()
                                          select new SalaryModel { salaryId = e.salaryId, sal = e.sal, date = e.date, empId = e.empId, fName = ss?.fName ?? "", mName = ss?.mName ?? "", lName = ss?.lName, salList = null }).ToList();
                    }
                    else
                    {
                        result.salList = new List<SalaryModel>();
                    }
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public bool Add(SalaryModel model)
        {
            try
            {
                Salary salary = new Salary
                {
                    date = model.date,
                    empId = model.empId,
                    sal = model.sal,
                };
                _db.Salaries.Add(salary);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exp)
            {

            }
            return false;
        }

        public bool Update(SalaryModel model)
        {
            try
            {
                var sal = _db.Salaries.Find(model.salaryId);
                if (sal != null)
                {
                    sal.date = model.date;
                    sal.sal = model.sal;
                    sal.empId = model.empId;
                }
                _db.Entry(sal).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception exp)
            {

            }
            return false;
        }

        public bool delete(long id)
        {
            try
            {
                var sal = _db.Salaries.Find(id);
                if (sal != null)
                {
                    _db.Salaries.Remove(sal);
                    _db.SaveChanges();
                    return true;
                }
            }
            catch (Exception exp)
            {

            }
            return false;
        }
    }
}