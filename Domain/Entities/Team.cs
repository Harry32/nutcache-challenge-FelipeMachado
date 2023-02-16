using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Employees = new List<Employee>();
        }

        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}