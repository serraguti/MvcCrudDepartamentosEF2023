using Microsoft.EntityFrameworkCore;
using MvcCrudDepartamentosEF2023.Models;

namespace MvcCrudDepartamentosEF2023.Data
{
    public class DepartamentosContext: DbContext
    {
        public DepartamentosContext
            (DbContextOptions<DepartamentosContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
