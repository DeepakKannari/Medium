using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Medium3
{
    class EmployeePromotion
    {
        private List<Employee> employeeRecord = new List<Employee>();
        
        private Dictionary<int,Employee> employees = new Dictionary<int,Employee>();
             
        public void CreateEmployeeRecord()
        {          
            bool flag = true;
            do
            {
                Employee employee = new Employee();
                employee.TakeEmployeeDetailsFromUser();
                if (!employees.ContainsKey(employee.Id))
                {
                    employees.Add(employee.Id, employee);
                }
                else
                {
                    Console.WriteLine("Employee with {0} already exist", employee.Id);
                    goto Exit;
                }


            Exit: Console.WriteLine("To continue entering employee details enter 1, to exit enter 0");
                string value = Console.ReadLine();
                if (value == "1")
                { }
                else if (value == "0")
                { flag = false; }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    goto Exit;
                }

            } while (flag);
        }
               
        public void SortAndPrintEmployees()
        {
            foreach (Employee employee in employees.Values)
            {
                employeeRecord.Add(employee);
            }

            employeeRecord.Sort();

            Console.WriteLine("The sorted employee list");
            foreach (Employee employee in employeeRecord)
            {
                Console.WriteLine(employee);
                Console.WriteLine("------------------------------------");
            }
        }
               
        public void FindEmployees()
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            Regex rgx_name = new Regex(@"^[a-zA-Z]+\s*[a-zA-Z]*$");

          ReadName:Console.WriteLine("Please enter the employee name");

            string name = Console.ReadLine();
            if (isValid(name, rgx_name))
            {
                var employeeFound = employeeRecord.Where(s => s.Name == myTI.ToTitleCase(name));
                if (employeeFound.Any())
                {
                    foreach (var employee in employeeFound)
                    {
                        Console.WriteLine(employee);
                        Console.WriteLine("------------------------------------");
                    }
                    
                }
                else
                {
                    Console.WriteLine("No employee with the Name {0} found", name);
                }
            }
            else
            {
                Console.WriteLine("Invalid Name");
                goto ReadName;
            }
            Console.Read();

        }
        private bool isValid(string value, Regex regex)
        {
            if (string.IsNullOrEmpty(value) || !regex.IsMatch(value))                        
            {
                Console.WriteLine("Invalid value please enter a valid value");
                return false;
            }
            return true; 
        }
    }
}
