using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;

namespace MainProgram
{
     class Program 
    {
        public static void Main() 
        {
            List<Employee> employees = new List<Employee>();

            int e = int.Parse(Console.ReadLine());
            for(int i = 1; i <= e; i++)
            {
                Console.WriteLine(i);

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Department: ");
                Department department = Enum.Parse<Department>(Console.ReadLine());
                Console.Write("Seniority: ");
                Seniority seniority = Enum.Parse<Seniority>(Console.ReadLine());
                Console.Write("Seniority: ");
                EmployeeStatus employeeStatus = Enum.Parse<EmployeeStatus>(Console.ReadLine());
                Console.Write("Job Position: ");

                employees.Add(new Employee(name, department, seniority, employeeStatus));
                
            }


        }
    }

}