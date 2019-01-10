using EmployeeDemo.Models;
using EmployeeDemo.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDemo.Repository
{
    public class EmployeRepo
    {
        private readonly EmployeeDemoEntities _db;
        public EmployeRepo()
        {
            _db = new EmployeeDemoEntities();
        }
         

        public EmpModel GetEmployee(long id = 0)
        {
            var result = new EmpModel();
            try
            {
                if (id > 0)
                {
                    var data = _db.Employees.Find(id);
                    if(data != null)
                    {
                        result.address = data.address;
                        result.age = data.age;
                        result.birthdate = data.birthdate;
                        result.email = data.email;
                        result.empId = data.empId;
                        result.fName = data.fName;
                        result.gender = data.gender;
                        result.hobby = data.hobby;
                        result.lName = data.lName;
                        result.mName = data.mName;
                    }
                    else
                    {
                        result.empId = 0;
                    }
                }
                else
                {
                    var data = _db.Employees.ToList();
                    if (data != null)
                    {
                        //var emptotalSal = (from s in _db.Salaries group s.sal by s.empId into g
                        //                  select new {empId = g.Key,sal = g.Sum(a=>a) }).ToList();
                        result.empList = (from e in data
                                          join s in (from s in _db.Salaries
                                                     group s.sal by s.empId into g
                                                     select new { empId = g.Key, sal = g.Sum(a => a) }).ToList() on e.empId equals s.empId into sa
                                          from se in sa.DefaultIfEmpty()
                                          select new EmpModel { age = e.age, address = e.address, birthdate = e.birthdate, email = e.email, empId = e.empId, fName = e.fName, gender = e.gender, hobby = e.hobby, lName = e.lName, mName = e.mName,sal = se?.sal??0 ,empList = null }).ToList();

                    }
                    else
                    {
                        result.empList = new List<EmpModel>();
                    }
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }

        public bool Add(EmpModel model)
        {
            try
            {
                Employee emp = new Employee
                {
                    address = model.address,
                    age = model.age,
                    birthdate = model.birthdate,
                    email = model.email,
                    fName = model.fName,
                    gender = model.gender,
                    hobby = model.hobby,
                    lName = model.lName,
                    mName = model.mName
                };
                _db.Employees.Add(emp);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exp)
            {
                
            }
            return false;
        }

        public bool Update(EmpModel model)
        {
            try
            {
                var emp = _db.Employees.Find(model.empId);
                if(emp != null)
                {
                    emp.address = model.address;
                    emp.age = model.age;
                    emp.birthdate = model.birthdate;
                    emp.email = model.email;
                    emp.fName = model.fName;
                    emp.gender = model.gender;
                    emp.hobby = model.hobby;
                    emp.lName = model.lName;
                    emp.mName = model.mName;
                }
                _db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
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
                var emp = _db.Employees.Find(id);
                if (emp != null)
                {
                    _db.Employees.Remove(emp);
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