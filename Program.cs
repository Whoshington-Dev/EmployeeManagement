using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;

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
                    string dptName = Console.ReadLine();
                    Department department = new Department(dptName: dptName);

                    Console.Write("Employee Seniority (Trainee, Junior, Pleno, Senior): ");
                    string snt = Console.ReadLine().Trim();

                    Enum.TryParse<Seniority>(snt, out Seniority result);

                    Console.Write("What will the employee's position be? ");
                    string post = Console.ReadLine();
                    JobPosition joPosition = new JobPosition(post, department, result);

                    Console.Write("On what date was he admitted? ");
                    DateTime admDate = DateTime.Parse(Console.ReadLine(), new System.Globalization.CultureInfo("pt-br"));

                    employees.Add(new Employee(cpf, nameEmployee, department, result, joPosition, admDate));

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
                    Console.Write("What employee name will be edited? (search by CPF) ");
                    string cpf = Console.ReadLine();

                    Employee found = employees.First(employees => employees.Cpf == cpf); // Usei um LINQ para verificar se um nome digitado existe na minha Lista. 

                    Console.WriteLine("What will you edit? ");
                    Console.Write
                        (
                        " 1 - Department " +
                        " 2 - JobPosition " +
                        " 3 - Seniority: "
                        );
                    int editing = int.Parse(Console.ReadLine());
                    switch (editing)
                    {
                        case 1:
                            Console.Write("New Department: ");
                            string newDpt = Console.ReadLine();
                            Department department = new Department(dptName: newDpt);
                            found.ChangeDepartment(department);
                            break;

                        case 2:
                            Console.Write("New Job Position: ");
                            string newJpt = Console.ReadLine();
                            JobPosition joPosition = new JobPosition(newJpt, found.Department, found.Seniority);
                            found.ChangeJobPosition(joPosition);
                            break;

                        case 3:
                            Console.Write("New seniority: ");
                            string snt = Console.ReadLine();
                            Enum.TryParse<Seniority>(snt, out Seniority result);

                            found.ChangeSeniority(result);
                            break;
                    }
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
                    Employee employee = employees.First(employees => employees.Cpf == cpf);

                    Console.Write("When was the employee laid off? ");
                    DateTime laidOff = DateTime.Parse(Console.ReadLine(), new System.Globalization.CultureInfo("pt-br"));

                    Console.Write("Reason for Layoff: ");
                    string reason = Console.ReadLine();

                    employee.LayOff(laidOff, reason);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.Write("Do you want any more operations? (Y) (N): ");
            char opt = char.Parse(Console.ReadLine().ToUpper());

            while (opt == 'Y')
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
                nopt = char.Parse(Console.ReadLine().ToUpper());
            }

        }
    }

}