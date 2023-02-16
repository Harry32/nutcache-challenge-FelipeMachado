using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Employee
    {
        [Column("id")]
        public Guid Id { get; set; }
        [ForeignKey("Team")]
        [Column("id_team")]
        public Guid IdTeam { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("birthday")]
        public DateTime BirthDate { get; set; }
        [Column("gender")]
        public char Gender { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("cpf")]
        public string CPF { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        
        public Team Team { get; set; }
    }
}