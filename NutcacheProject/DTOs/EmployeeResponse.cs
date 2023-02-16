using System.ComponentModel.DataAnnotations;

namespace NutcacheProject.DTOs
{
    public class EmployeeResponse
    {
        public Guid? Id { get; set; }
        public Guid IdTeam { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(11)]
        [MinLength(11)]
        public string CPF { get; set; }
        public DateTime StartDate { get; set; }

        public Team Team { get; set; }
    }
}