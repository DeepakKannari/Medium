using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Medium4
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

        private bool isValid(string value, Regex regex)
        {
            if (string.IsNullOrEmpty(value) || !regex.IsMatch(value))                       
            {
                Console.WriteLine("Invalid value please enter a valid value");
                return false;
            }
            return true; 
        }

        public void GenerateEmployeeList()
        {
            foreach (Employee employee in employees.Values)
            {
                employeeRecord.Add(employee);
            }
                      
        }

        public void OlderEmployees()
        {
            Regex rgx_id = new Regex(@"^[0-9]+$");

          ReadId:  Console.WriteLine("Please enter the employee ID");

            string id = Console.ReadLine();
            if (isValid(id, rgx_id))
            {
                if (employees.ContainsKey(Convert.ToInt32(id)))
                {
                    int age = employees[Convert.ToInt32(id)].Age;
                    var employeeFound = employeeRecord.Where(s => s.Age > age);
                    if (employeeFound.Any())
                    {
                        foreach (var employee in employeeFound)
                        {
                            Console.WriteLine(employee);
                            Console.WriteLine("----------------------------------");
                        }
                        Console.Read();
                    }
                    else
                    {
                        Console.WriteLine("No employee(s) older then the {0} found",(id));
                        Console.Read();
                    }
                }
                else
                {
                    Console.WriteLine("No employee with the Employee id:{0} found", id);
                }
                
            }
            else
            {
                Console.WriteLine("Invalid Id");
                goto ReadId;
            }


        }

        
    }
}
