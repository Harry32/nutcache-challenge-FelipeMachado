using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository) { }
    }
}