using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Medium5
{
    class EmployeePromotion
    {
        private List<Employee> employeeRecord = new List<Employee>();
        
        private Dictionary<int,Employee> employees = new Dictionary<int,Employee>();
        public void CreateEmployeeRecord()
        {
            //Regex rgx_name = new Regex(@"^[a-zA-Z]+\s*[a-zA-Z]*$");
            //Regex rgx_id = new Regex(@"^[0-9]+$");
            //Regex rgx_age= new Regex(@"^[1-9][0-9]{1,2}$");
            //Regex rgx_salary =  new Regex(@"^[1-9][0-9]*$");

            bool flag = true;

            
          //  employee.TakeEmployeeDetailsFromUser();
            // bool valid = true;

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
                  if(value == "1") 
                    { }
                  else if(value == "0") 
                    { flag = false;}

            } while (flag);
        }

        public void getById()
        {
            Regex rgx_id = new Regex(@"^[0-9]+$");

        ReadId: Console.WriteLine("Please enter the employee ID");
            string id = Console.ReadLine();                                                    // check for id already present 

            if (isValid(id, rgx_id))
            {

                if (!employees.ContainsKey(Convert.ToInt32(id)))
                {
                    Console.WriteLine("The {0} does not exist",id);
                }
                else
                {
                    Console.WriteLine(employees[Convert.ToInt32(id)]);
                    
                }
            }
            else
            {
                goto ReadId;
            }
            Console.Read();



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

        //public void SortAndPrintEmployees()
        //{
        //    foreach (Employee employee in employees.Values)
        //    {
        //        employeeRecord.Add(employee);
        //    }
        //}
    }
}
