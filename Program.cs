using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Repositories;
using EmployeeManagement.Services;

namespace EmployeeManagement
{
    class Program
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            Console.Write("Add an employee? (Type: A) or " +
                "Editing an existing employee? (Type E): " +
                "Lay Off Employee (Type L): "
                );
            char option = char.Parse(Console.ReadLine().ToUpper());

            if (option == 'A')
            {
                AddEmployee(employees);
            }
            else if (option == 'E')
            {
                EditEmployee(employees);
            }
            else
            {
                LayOffEmployee(employees);
            }

            static void AddEmployee(List<Employee> employees)
            {
                try
                {
                    // Name, Department, Seniority, Position and date of admission

                    Console.Write("Employee CPF: ");
                    string cpf = Console.ReadLine();

                    Console.Write("Employee's name: ");
                    string nameEmployee = Console.ReadLine();

                    Console.Write("Employee Department: ");
                    string departmentName = Console.ReadLine();
                    Department department = new Department(dptName: departmentName);

                    Console.Write("Employee Seniority (Trainee, Junior, Pleno, Senior): ");
                    string seniorityInput = Console.ReadLine().Trim();

                    Enum.TryParse<Seniority>(seniorityInput, out Seniority result);

                    Console.Write("What will the employee's position be? ");
                    string jobTitle = Console.ReadLine();
                    JobPosition joPosition = new JobPosition(jobTitle, department, result);

                    Console.Write("On what date was he admitted? ");
                    DateTime admissionDate = DateTime.Parse(Console.ReadLine(), new System.Globalization.CultureInfo("pt-br"));

                    // Repositorys and Service
                    EmployeeService employeeService = new EmployeeService(new EmployeeRepository());
                    employeeService.AddEmployee(cpf, nameEmployee, department, result, joPosition, admissionDate);

                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Employee created! ");
                }
            }

            static void EditEmployee(List<Employee> employees)
            {
                try
                {
                    // searching for CPF
                    Console.Write("What employee name will be edited? (search by CPF) ");
                    string cpf = Console.ReadLine();

                    Console.WriteLine("What will you edit? ");
                    Console.Write
                        (
                        " 1 - Department " +
                        " 2 - JobPosition " +
                        " 3 - Seniority: "
                        );

                    EmployeeService employeeService = new EmployeeService(new EmployeeRepository());
                    employeeService.EditEmployee(cpf);
                }
                catch (InvalidOperationException ex)
                {
                    // Exception LayOff and UserStatus
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Finished! ");
                }
            }
            // LayOff
            static void LayOffEmployee(List<Employee> employees)
            {
                try
                {
                    Console.Write("What is an employee (search by CPF): ");
                    string cpf = Console.ReadLine();

                    Console.Write("When was the employee laid off? ");
                    DateTime terminationDate = DateTime.Parse(Console.ReadLine(), new System.Globalization.CultureInfo("pt-br"));

                    Console.Write("Reason for Layoff: ");
                    string reason = Console.ReadLine();

                    EmployeeService employeeService = new EmployeeService(new EmployeeRepository());
                    employeeService.LayOffEmployee(cpf, terminationDate, reason);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.Write("Do you want any more operations? (Y) (N): ");
            char continueOption = char.Parse(Console.ReadLine().ToUpper());

            while (continueOption == 'Y')
            {
                Console.Write("What do you want to do? Edit(1) or Add(2) or Fired(3): ");
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        EditEmployee(employees);
                        break;
                    case 2:
                        AddEmployee(employees);
                        break;
                    case 3:
                        LayOffEmployee(employees);
                        break;
                }
                Console.Write("Do you want any more operations? (Y) (N): ");
                continueOption = char.Parse(Console.ReadLine().ToUpper());
            }

        }
    }

}