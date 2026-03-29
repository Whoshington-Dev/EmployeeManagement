using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;

namespace MainProgram
{
     class Program 
    {
        public static void Main() 
        {
            List<Employee> employees = new List<Employee>();

                if (option == 'A')
                {

                    // Nome, Departamento, Senioridade, Cargo e a data de admissão

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
                    DateTime admDate = DateTime.Parse(Console.ReadLine());

                    employees.Add(new Employee(nameEmployee, department, result, joPosition, admDate));
                }

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



                    Console.WriteLine("What will you edit? ");
                
                            found.ChangeDepartment(department);
                            break;
                        case 2:
                            found.ChangeJobPosition(joPosition);
                            break;
                        case 3:
                            found.ChangeSeniority(result);
                            break;
            }


        }
            }
            catch (InvalidOperationException ex)
            {
                // Exception LayOff and UserStatus
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Employee edited! ");
            }
        }

    }
}