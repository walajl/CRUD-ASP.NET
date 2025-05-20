using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionEmployees.Models;

namespace GestionEmployees.Data
{
    public class GestionEmployeesContext : DbContext
    {
        public GestionEmployeesContext (DbContextOptions<GestionEmployeesContext> options)
            : base(options)
        {
        }

        public DbSet<GestionEmployees.Models.Employee> Employee { get; set; } = default!;
    }
}
