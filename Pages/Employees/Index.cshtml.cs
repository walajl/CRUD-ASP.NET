using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GestionEmployees.Data;
using GestionEmployees.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionEmployees.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly GestionEmployees.Data.GestionEmployeesContext _context;

        public IndexModel(GestionEmployees.Data.GestionEmployeesContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SelectedDepartment { get; set; }

        public SelectList? Departments { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> departmentQuery = from e in _context.Employee
                                                 orderby e.Department
                                                 select e.Department;

            // sélectionner tous les employés de la base de données
            var employees = from e in _context.Employee
                            select e;

            // Applique le filtre de recherche si nécessaire
            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(e => e.FullName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SelectedDepartment))
            {
                employees = employees.Where(e => e.Department == SelectedDepartment);
            }
            Departments = new SelectList(await departmentQuery.Distinct().ToListAsync());
            Employee = await employees.ToListAsync(); 

        }
    }
}
