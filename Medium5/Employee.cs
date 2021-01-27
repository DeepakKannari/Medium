using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Medium5
{
    class Employee
    {
        int id, age;
        string name;
        double salary;
        private TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

        public int Id { get => id; set => id = value; }
        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public double Salary { get => salary; set => salary = value; }

        public Employee()
        {
        }

        public Employee(int id, int age, string name, double salary)
        {
            this.id = id;
            this.age = age;
            this.name = name;
            this.salary = salary;
        }

        public void TakeEmployeeDetailsFromUser()
        {
            Regex rgx_name = new Regex(@"^[a-zA-Z]+\s*[a-zA-Z]*$");
            Regex rgx_id = new Regex(@"^[0-9]+$");
            Regex rgx_age = new Regex(@"^[1-9][0-9]{1,2}$");
            Regex rgx_salary = new Regex(@"^[1-9][0-9]*$");
        //Console.WriteLine("Please enter the employee ID");
        //id = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Please enter the employee name");
        //name = Console.ReadLine();
        //Console.WriteLine("Please enter the employee age");
        //age = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Please enter the employee salary");
        //salary = Convert.ToDouble(Console.ReadLine());
        ReadId: Console.WriteLine("Please enter the employee ID");
            string id = Console.ReadLine();
            if (isValid(id, rgx_id))
            {
                this.Id = Convert.ToInt32(id);
            }
            else
            {
                goto ReadId;
            }
        //ReadId: Console.WriteLine("Please enter the employee ID");
        //    string id = Console.ReadLine();                                                    // check for id already present 

        //    if (isValid(id, rgx_id))
        //    {

        //        if (!employees.ContainsKey(Convert.ToInt32(id)))
        //        {
        //            this.Id = Convert.ToInt32(id);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Employee Id already exist");
        //            goto Exit;
        //        }
        //    }
        //    else
        //    {
        //        goto ReadId;
        //    }

        ReadName: Console.WriteLine("Please enter the employee name");
            string name = Console.ReadLine();
            if (isValid(name, rgx_name))
            {
                this.Name = name;
            }
            else
            {
                goto ReadName;
            }

        ReadAge: Console.WriteLine("Please enter the employee age");
            string age = Console.ReadLine();
            if (isValid(age, rgx_age))
            {
                this.Age = Convert.ToInt32(age);
            }
            else
            {
                goto ReadAge;
            }
        ReadSalary: Console.WriteLine("Please enter the employee salary");
            string salary = Console.ReadLine();

            if (isValid(salary, rgx_salary))
            {
                this.Salary = Convert.ToInt32(salary);
            }
            else
            {
                goto ReadSalary;
            }

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

        public override string ToString()
        {
            return "Employee ID : " + id + "\nName : " + name + "\nAge : " + age + "\nSalary : " + salary;
        }

       
    }

}

