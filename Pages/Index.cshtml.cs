using GestionEmployees.Data;
using GestionEmployees.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
namespace GestionEmployees.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GestionEmployeesContext _context;


        public int TotalEmployees { get; set; }
        public Employee? LastAdded { get; set; }


        public IndexModel(ILogger<IndexModel> logger, GestionEmployeesContext context)
        {
            _logger = logger;
            _context = context;
        }


        public void OnGet()
        {

            TotalEmployees = _context.Employee.Count();
            LastAdded = _context.Employee.OrderByDescending(e => e.Id).FirstOrDefault();
        }
    }
}