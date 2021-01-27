using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium2
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeePromotion employeePromotion = new EmployeePromotion();
            employeePromotion.CreateEmployeeRecord();
            employeePromotion.SortAndPrintEmployees();
            employeePromotion.PrintEmployee();
        }

    }
}
