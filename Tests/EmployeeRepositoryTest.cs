using DataAccess;
using DataAccess.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System.Data.Entity.Infrastructure;
using Tests.Auxiliaries;

namespace Tests
{
    public class Tests
    {
        private EmployeeRepository employeeRepository;

        [SetUp]
        public void Setup()
        {
            var configurationSection = Substitute.For<IConfigurationSection>();
            configurationSection.Value.Returns("");

            var configuration = Substitute.For<IConfiguration>();
            configuration.GetSection(Arg.Any<string>()).Returns(configurationSection);

            var mockContext = Substitute.For<DataContext>(configuration);
            var mockSet = PrepareData();
            
            mockContext.Employees = mockSet;

            employeeRepository = new EmployeeRepository(mockContext);
        }

        [Test]
        public void Test1()
        {
            
        }

        private DbSet<Employee> PrepareData()
        {
            var mockSet = Substitute.For<DbSet<Employee>, IQueryable<Employee>, IDbAsyncEnumerable<Employee>>();

            Team team = new Team { Id = Guid.NewGuid(), Name = "Backend" };

            var employees = new List<Employee>
            {
                new Employee { Id = Guid.NewGuid(), IdTeam = team.Id, Name= "Test", BirthDate = new DateTime(1989, 2, 15), Gender = 'f', Email = "test@email.com", CPF = "54773147628", StartDate = new DateTime(2020, 10, 10), Team = team },
                new Employee { Id = Guid.NewGuid(), Name= "Test", BirthDate = new DateTime(1989, 2, 15), Gender = 'f', Email = "test@email.com", CPF = "54773147628", StartDate = new DateTime(2020, 10, 10) },
            }.AsQueryable();

            ((IDbAsyncEnumerable<Employee>)mockSet).GetAsyncEnumerator().Returns(new TestDbAsyncEnumerator<Employee>(employees.GetEnumerator()));
            ((IQueryable<Employee>)mockSet).Provider.Returns(new TestDbAsyncQueryProvider<Employee>(employees.Provider));
            ((IQueryable<Employee>)mockSet).Expression.Returns(employees.Expression);
            ((IQueryable<Employee>)mockSet).ElementType.Returns(employees.ElementType);
            ((IQueryable<Employee>)mockSet).GetEnumerator().Returns(employees.GetEnumerator());

            return mockSet;
        }
    }
}