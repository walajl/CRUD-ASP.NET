using Microsoft.EntityFrameworkCore;
using GestionEmployees.Data;

namespace GestionEmployees.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GestionEmployeesContext(
                serviceProvider.GetRequiredService<DbContextOptions<GestionEmployeesContext>>()))
            {
                if (context == null || context.Employee == null) 
                {
                    throw new ArgumentNullException(nameof(context), "GestionEmployeesContext is null");
                }

                if (context.Employee.Any())
                {
                    return;
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        FullName = "Mohamed Ben Ali",
                        HireDate = new DateTime(2020, 6, 15),
                        Department = "IT",
                        Salary = 3500.00M,
                        Email = "mohamedbenali@gmail.com"
                    },
                    new Employee
                    {
                        FullName = "Amira Trabelsi",
                        HireDate = new DateTime(2019, 3, 10),
                        Department = "HR",
                        Salary = 2800.00M,
                        Email = "amiratrabelsi@gmail.com"
                    },
                    new Employee
                    {
                        FullName = "Karim Boukadi",
                        HireDate = new DateTime(2021, 1, 5),
                        Department = "Finance",
                        Salary = 4000.00M,
                        Email = "karimboukadi@gmail.com"
                    },
                    new Employee
                    {
                        FullName = "Leila Hammami",
                        HireDate = new DateTime(2018, 11, 20),
                        Department = "Marketing",
                        Salary = 1250.00M,
                        Email = "leilahammami@gmail.com"

                    }
                );

                context.SaveChanges();
            }
        }
    }
}

