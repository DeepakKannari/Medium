using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Medium2
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

        private bool isValid(string vlaue, Regex regex)
        {
            if (string.IsNullOrEmpty(vlaue) || !regex.IsMatch(vlaue))                        // create and call isvalid with para rgx and string value if invalid go to the start
            {
                Console.WriteLine("Invalid value please enter a valid value");
                return false;
            }
            return true; 
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

        public void PrintEmployee()
        {
            Regex rgx_id = new Regex(@"^[0-9]+$");

          ReadId: Console.WriteLine("Please enter the employee ID");

            string id=Console.ReadLine();
            if (isValid(id, rgx_id))
            {
                var employeeFound = employeeRecord.Where(s => s.Id == Convert.ToInt32(id));
                if (employeeFound.Any())
                {
                    Console.WriteLine("The employee details:");
                    foreach (var employee in employeeFound)
                    {
                        Console.WriteLine(employee);
                    }
                    
                }
                else
                {
                    Console.WriteLine("No employee with the {0} found", id);
                    
                }
            }
            else
            {
                Console.WriteLine("Invalid Id");
                goto ReadId;
            }
            Console.Read();
            
        }
    }
}
