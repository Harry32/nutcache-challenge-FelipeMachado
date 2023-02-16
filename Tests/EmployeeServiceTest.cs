using Microsoft.Extensions.Configuration;
using NSubstitute;
using Domain.Services;
using Domain.Interfaces.Repositories;

namespace Tests
{
    public class EmployeeServiceTest
    {
        private EmployeeService employeeService;

        [SetUp]
        public void Setup()
        {
            var employeeRepository = Substitute.For<IEmployeeRepository>();

            employeeService = Substitute.For<EmployeeService>(employeeRepository);
        }
    }
}