using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NutcacheProject.DTOs
{
    public class EmployeeRequest
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
    }
}