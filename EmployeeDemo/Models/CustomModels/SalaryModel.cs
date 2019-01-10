using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDemo.Models.CustomModels
{
    public class SalaryModel
    {
        public long salaryId { get; set; }
        public long empId { get; set; }
        public System.DateTime date { get; set; }
        public decimal sal { get; set; }
        public string fName { get; set; }
        public string mName { get; set; }
        public string lName { get; set; }
        public List<SalaryModel> salList { get; set; }

        public SalaryModel()
        {
            salList = new List<SalaryModel>();
        }
    }
}