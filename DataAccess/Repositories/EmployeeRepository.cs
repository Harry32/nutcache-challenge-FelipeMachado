using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext dataContext) : base(dataContext) { }

        public override async Task<List<Employee>> GetAll() => await dataContext.Set<Employee>()
                                                                                .Include("Team")
                                                                                .ToListAsync();

        public override async Task<Employee> Get(Guid id) => await dataContext.Set<Employee>()
                                                                              .Include("Team")
                                                                              .Where(e => e.Id == id)
                                                                              .SingleOrDefaultAsync();
    }
}