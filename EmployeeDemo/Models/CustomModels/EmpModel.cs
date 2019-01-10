using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDemo.Models.CustomModels
{
    public class EmpModel
    {

        public long empId { get; set; }
        public string fName { get; set; }
        public string mName { get; set; }
        public string lName { get; set; }
        public short? age { get; set; }
        public DateTime? birthdate { get; set; }
        public short? gender { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string hobby { get; set; }
        public List<SelectListItem> hbList { get; set; }
        public List<EmpModel> empList { get; set; }
        public decimal sal { get; set; }
        public EmpModel()
        {
            empList = new List<EmpModel>();
        }
    }

}